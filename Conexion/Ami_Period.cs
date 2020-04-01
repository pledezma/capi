using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace model
{
    public class Ami_Period
    {
        public int id { get; set; }
        public int status { get; set; }
        public DateTime emissionDate { get; set; }
        public DateTime endDate { get; set; }
        public int monthDate { get; set; }
        public int yearDate { get; set; }
        public string idPeriodRead { get; set; }

        public static readonly int activo = 1;
        public static readonly int inactivo = 2;


        public Ami_Period[] getData (string q) {
            model.cnx cnx = new cnx();
            DataTable dataTable = new DataTable();
            Ami_Period p = null;
            Ami_Period[] parr = null;            
            dataTable = cnx.hacerSelect(q);
            int cantidad = dataTable.Rows.Count;
            if (dataTable != null && cantidad > 0)
            {
                parr = new Ami_Period[cantidad];
                for (int i = 0; i < cantidad; i++)
                {
                    p = new Ami_Period();
                    p.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    p.status = int.Parse(dataTable.Rows[i]["status"].ToString());
                    p.emissionDate = Convert.ToDateTime(dataTable.Rows[i]["emissionDate"].ToString());
                    p.endDate = Convert.ToDateTime(dataTable.Rows[i]["endDate"].ToString());
                    p.monthDate = int.Parse(dataTable.Rows[i]["monthDate"].ToString());
                    p.yearDate = int.Parse(dataTable.Rows[i]["yearDate"].ToString());
                    p.idPeriodRead = dataTable.Rows[i]["idPeriodRead"].ToString();
                    parr[i] = p;
                }
            }
            
            return parr;
        }
        public Ami_Period[] getLastPeriod()
        {
            Ami_Period[] parr = null;
            string q = "select top(1)* from Ami_period where status = 1 order by id desc;";
            parr = getData(q);
            return parr;
        }
             
    }
}
