using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Database
{
    public class DalCustomLogics
    {
        public static string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            JSONString = JsonConvert.SerializeObject(table, settings);
            return JSONString;
        }

        public static List<T> DataTableToList<T>(DataTable table, Func<T> factoryMethod)
        {
            List<T> list = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                T entity = factoryMethod();

                foreach (DataColumn col in table.Columns)
                {
                    PropertyInfo prop = typeof(T).GetProperty(col.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null && row[col] != DBNull.Value)
                    {
                        prop.SetValue(entity, Convert.ChangeType(row[col], prop.PropertyType), null);
                    }
                }

                list.Add(entity);
            }

            return list;
        }



    }
}