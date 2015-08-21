using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Reflection;

namespace SoftEmpenios.Clases
{
    public class LinqToDataTable
    {

            // Methods
            public DataTable ObtenerDataTable(IEnumerable ien)
            {
                
                DataTable table = new DataTable();
                foreach (object obj2 in ien)
                {
                    PropertyInfo[] properties = obj2.GetType().GetProperties();
                    if (table.Columns.Count == 0)
                    {
                        foreach (PropertyInfo info in properties)
                        {
                            table.Columns.Add(info.Name, (info.PropertyType != Type.GetType("System.Nullable1")) ? info.PropertyType : Type.GetType("System.Decimal"));
                        }
                    }
                    DataRow row = table.NewRow();
                    foreach (PropertyInfo info in properties)
                    {
                        object obj3 = info.GetValue(obj2, null);
                        row[info.Name] = obj3;
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
        //metodo dos
            public DataTable ObtenerDataTable2<T>(IEnumerable<T> varlist)
            {
                DataTable dtReturn = new DataTable();

                // column names 
                PropertyInfo[] oProps = null;

                if (varlist == null) return dtReturn;

                foreach (T rec in varlist)
                {
                    // Use reflection to get property names, to create table, Only first time, others 
                    //will follow 
                    if (oProps == null)
                    {
                        oProps = ((Type)rec.GetType()).GetProperties();
                        foreach (PropertyInfo pi in oProps)
                        {
                            Type colType = pi.PropertyType;

                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                            == typeof(Nullable<>)))
                            {
                                colType = colType.GetGenericArguments()[0];
                            }

                            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                        }
                    }

                    DataRow dr = dtReturn.NewRow();

                    foreach (PropertyInfo pi in oProps)
                    {
                        dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                        (rec, null);
                    }

                    dtReturn.Rows.Add(dr);
                }
                return dtReturn;
            }
      
    }
}
