using System;
using System.Collections.Generic;
using System.Text;

namespace model
{
    /*
        create table Ami_Control (
        id int identity,
        status varchar(100),
        token varchar(200) ,
        meter varchar(200) ,
        jsonData text,
        executedDate dateTime
        primary key(id)
        );
    */
    public class Ami_Control
    {
        public int id { get; set; }
        public string status { get; set; }
        public string token { get; set; }
        public string meter { get; set; }
        public string jsonData { get; set; }
        public DateTime executedDate { get; set; }
        public bool insert()
        {
            bool r = false;
            string q =
                "INSERT INTO AMI.dbo.Ami_Control " +
                "(status, token, meter, jsonData) " +
                "VALUES( '" + status + "', '"+ token + "', '" + meter + "', '" + jsonData + "', GETDATE()); ";
                
                
            cnx cnx = new cnx();

            if (cnx.abrir())
            {
                r = cnx.hacerHit(q);
            }
            return r;
        }
        public string qInsert()
        { 
            string q =
                "INSERT INTO AMI.dbo.Ami_Control " +
                "(status, token, meter, jsonData) " +
                "VALUES( '" + status + "', '" + token + "', '" + meter + "', '" + jsonData + "', GETDATE()); ";
             
            return q;
        }
        public bool transaction(List<string> tranList)
        {
            bool r = false;
            cnx cnx = new cnx();
            r = cnx.do_transaction(tranList);
            return r;
        }
    }
}
