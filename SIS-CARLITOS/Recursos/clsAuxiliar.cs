using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace SIS_CARLITOS.Recursos
{
    public class ClsAuxiliar
        {
        public static DataTable ConvertToDataTable<T>(IList<T> list) where T : class
        {
            try
            {
                DataTable table = CreateDataTable<T>();
                Type objType = typeof(T);
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objType);
                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor property in properties)
                    {
                        if (!CanUseType(property.PropertyType)) continue;
                        row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                    }

                    table.Rows.Add(row);
                }
                return table;
            }
            catch (DataException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static DataTable CreateDataTable<T>() where T : class
        {
            Type objType = typeof(T);
            DataTable table = new DataTable(objType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objType);
            foreach (PropertyDescriptor property in properties)
            {
                Type propertyType = property.PropertyType;
                if (!CanUseType(propertyType)) continue;

                //nullables must use underlying types
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                //enums also need special treatment
                if (propertyType.IsEnum)
                    propertyType = Enum.GetUnderlyingType(propertyType);
                table.Columns.Add(property.Name, propertyType);
            }
            return table;
        }

        public static bool CanUseType(Type propertyType)
        {
            //only strings and value types
            if (propertyType.IsArray) return false;
            if (!propertyType.IsValueType && propertyType != typeof(string)) return false;
            return true;
        }

    }
    
}