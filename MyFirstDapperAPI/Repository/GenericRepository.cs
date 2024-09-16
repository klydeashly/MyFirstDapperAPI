using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace MyFirstDapperAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        IDbConnection _connection;
        readonly string connectionString = "Server = DESKTOP-C6BKFH5\\SQLEXPRESS; Database = MyDapperAPIDatabase; Trusted_Connection = true; Encrypt = false";
        public GenericRepository()
        {
            _connection = new SqlConnection(connectionString);
        }
        public T GetById(int id)
        {
            return null;
        }

        public bool Add(T entity)
        {
            string tableName = GetTableName();
            string columns = GetColumnNames(excludeKey: true);
            string values = GetColumnValues(excludeKey: true);
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";


            int affectedRows = 0;

            affectedRows = _connection.Execute(query, entity);

            return affectedRows == 1;
        }
       public bool Update(T entity)
        {
            int rowsEffected = 0;
            try
            {
                string? tableName = GetTableName();
                string? keyColumn = GetKeyColumnName();
                string? keyProperty = GetKeyPropertyName();

                StringBuilder query = new StringBuilder();
                query.Append($"UPDATE {tableName} SET ");

                foreach (var property in GetProperties(true))
                {
                    var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();

                    string propertyName = property.Name;
                    string columnName = columnAttribute?.Name ?? "";

                    query.Append($"{columnName} = @{propertyName},");
                }

                query.Remove(query.Length - 1, 1);

                query.Append($" WHERE {keyColumn} = @{keyProperty}");

                rowsEffected = _connection.Execute(query.ToString(), entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating a record in db: ${ex.Message}");
                rowsEffected = -1;
            }
            finally
            {
                _connection.Close();
            }

            return rowsEffected == 1;
        }

        public bool Delete(T entity)
        {
            int rowsEffected = 0;
            try
            {
                string? tableName = GetTableName();
                string? keyColumn = GetKeyColumnName();
                string? keyProperty = GetKeyPropertyName();
                string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";

                rowsEffected = _connection.Execute(query, entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting a record in db: ${ex.Message}");
                rowsEffected = -1;
            }
            finally
            {
                _connection.Close();
            }

            return rowsEffected == 1;
        }



        public string GetTableName()
        {
            string tableName = "";
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;

            }

            return tableName;
        }
        public string GetColumnNames(bool excludeKey = false)
        {
            string columnNames = "";
            var type = typeof(T);
            var columns = string.Join(", ", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttr != null ? columnAttr.Name : p.Name;

                }
                ));
            return columns;
        }
        public string GetColumnValues(bool excludeKey = false)
        {
            var columnValues = typeof(T).GetProperties()
            .Where(p => !excludeKey || p.GetCustomAttribute(typeof(KeyAttribute)) == null);
            var values = string.Join(", ", columnValues.Select(p =>
            {
                return $"@{p.Name}";
            }));

            return values;

        }

        private string? GetKeyPropertyName()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() != null).ToList();

            if (properties.Any())
                return properties?.FirstOrDefault()?.Name ?? null;

            return null;
        }

        private static string? GetKeyColumnName()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object[] keyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

                if (keyAttributes != null && keyAttributes.Length > 0)
                {
                    object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (columnAttributes != null && columnAttributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];
                        return columnAttribute?.Name ?? "";
                    }
                    else
                    {
                        return property.Name;
                    }
                }
            }

            return null;
        }

        private IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            return properties;
        }
    }
}
