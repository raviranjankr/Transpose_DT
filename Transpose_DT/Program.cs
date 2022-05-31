using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Transpose_DT
{
    internal class Program
    {
        public static DataTable TransposeRowsCol(DataTable dt)
        {
            DataTable dtNew = new DataTable();

            //adding columns    
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                dtNew.Columns.Add(i.ToString());
            }
            //Changing Column Captions: 
            //dtNew.Columns[0].ColumnName = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //For dateTime columns use like below
                dtNew.Columns[i + 1].ColumnName = dt.Rows[i].ItemArray[0].ToString();
                //Else just assign the ItermArry[0] to the columnName prooperty
            }

            //Adding Row Data
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                DataRow r = dtNew.NewRow();
                r[0] = dt.Columns[k].ToString();
                for (int j = 1; j <= dt.Rows.Count; j++)
                    r[j] = dt.Rows[j - 1][k];
                dtNew.Rows.Add(r);
            }
            return dtNew;
        }
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Col1", typeof(string));
            dt.Columns.Add("Col2", typeof(string));
            dt.Columns.Add("Col3", typeof(string));
            dt.Rows.Clear();
            dt.Rows.Add("A1", "B1", "C1");
            dt.Rows.Add("A2", "B2", "C2");
            dt.Rows.Add("A3", "B3", "C3");
            dt.AcceptChanges();

            dt = Program.TransposeRowsCol(dt);
            Console.ReadKey();
        }
    }
}
