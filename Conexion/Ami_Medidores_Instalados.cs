using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace model
{
    public class Ami_Medidores_Instalados
    {
        public List<string> lisMeters = new List<string>();
        public List<string> lisToken = new List<string>();
        public int ID { get; set; }
        public string COD_MEDIDOR { get; set; }
        public string COD_INTERNO { get; set; }
        public string RUTA { get; set; }
        public string ESN { get; set; }
        public void arrayMeterTest()
        {
            lisMeters.Add("15367");
            lisMeters.Add("15424");
            lisMeters.Add("14320");
        }
        public Ami_Medidores_Instalados()
        {
            arrayMeterTest();
        }
        private Ami_Medidores_Instalados[] getData(string q)
        {
            model.cnx cnx = new cnx();
            DataTable dataTable = new DataTable();
            Ami_Medidores_Instalados t = null;
            Ami_Medidores_Instalados[] tarr = null;
            dataTable = cnx.hacerSelect(q);
            int cantidad = dataTable.Rows.Count;
            if (dataTable != null && cantidad > 0)
            {
                tarr = new Ami_Medidores_Instalados[cantidad];
                for (int i = 0; i < cantidad; i++)
                {
                    t = new Ami_Medidores_Instalados();
                    t.ID = int.Parse(dataTable.Rows[i]["ID"].ToString());
                    t.COD_MEDIDOR = dataTable.Rows[i]["COD_MEDIDOR"].ToString();
                    t.COD_INTERNO = dataTable.Rows[i]["COD_INTERNO"].ToString();
                    t.RUTA = dataTable.Rows[i]["RUTA"].ToString();
                    t.ESN = dataTable.Rows[i]["ESN"].ToString();
                    tarr[i] = t;
                }
            }

            return tarr;
        }
        public Ami_Medidores_Instalados[] getAllMeters()
        {
            Ami_Medidores_Instalados[] tarr = null;
            string q = "select top(10)* from Ami_Medidores_Instalados ami order by id desc;"; 
            
            tarr = getData(q); ;
            return tarr;
        }
    
 
        public Ami_Medidores_Instalados[] getAllMetersDisconect()
        {
            Ami_Medidores_Instalados[] tarr = null;
            //string q = "select top(10)* from Ami_Medidores_Instalados ami order by id desc;";
            string q =
                "SELECT mi.* " +
                "FROM AMI.dbo.Ami_Medidores_Instalados mi " +
                "JOIN CAR.dbo.FAC_DetFact det " +
                "ON mi.COD_MEDIDOR = det.CodMedSoc " +
                "WHERE (det.IdFact = 225 AND det.Pagado = 'N') and(mi.COD_INTERNO  in ('11208','13194','13378','13518','13519','13718','13731','13752','13758','14002','14004','14438','14472','14562','14584','14669','15567','15579','15629','15644','15662','15688','15744','15835','15884','15885','15887','15942','16076','16179','16335'));"; ;
            tarr = getData(q); ;
            return tarr;
        }
        public Ami_Medidores_Instalados[] getAllMetersReconect()
        { 
        Ami_Medidores_Instalados[] tarr = null;
            //string q = "select top(10)* from Ami_Medidores_Instalados ami order by id desc;";
            string q =
                "SELECT mi.*  " +
                "FROM AMI.dbo.Ami_Medidores_Instalados mi  " +
                "JOIN CAR.dbo.FAC_DetFact det  " +
                "ON mi.COD_MEDIDOR = det.CodMedSoc  " +
                "JOIN AMI.dbo.Ami_Token tok  " +
                "ON mi.COD_INTERNO = tok.meter  " +
                "WHERE det.IdFact = 225 AND det.Pagado = 'S' AND det.FchPago >= 20200401 AND tok.tokenType = 'DisconnectMeter' AND tok.status = 3;  ";
            tarr = getData(q); ;
            return tarr;
        }
        public Ami_Medidores_Instalados[] getAllMeterss()
        {
            Ami_Medidores_Instalados[] tarr = null;
            string q = "select top(5)* from Ami_Medidores_Instalados ami order by id desc;";
            tarr = getData(q); ;
            return tarr;
        }
       
    }
}
