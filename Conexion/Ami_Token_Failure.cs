using System;
using System.Collections.Generic;
using System.Text;

namespace model
{
    /*
        create table Ami_Token_Failure(
        id int identity, 
        token varchar(200) ,
        reason varchar(250) ,
        description varchar(250),
        jsonData text,
        executedDate dateTime
        primary key(id)
        )
    */
    public class Ami_Token_Failure
    {
        public int id { get; set; } 
        public string token { get; set; }        
        public string reason { get; set; }
        public string description { get; set; }
        public string jsonData { get; set; }
        public DateTime executedDate { get; set; }



        public bool insert()
        {
            bool r = false;

            string q =
               "INSERT INTO AMI.dbo.Ami_Token_Failure " +
               "(token, reason, description,jsonData,executedDate) " +
               "VALUES('" + token + "', '" + reason + "','" + description + "', '" + jsonData + "', GETDATE()); ";
            r = setData(q);
            return r;
        }
        public string qInsert()
        { 
            string q =
               "INSERT INTO AMI.dbo.Ami_Token_Failure " +
               "(token, reason, description,jsonData,executedDate) " +
               "VALUES('" + token + "', '" + reason + "','" + description + "', '" + jsonData + "', GETDATE()); ";
         
            return q;
        }
        public bool setData(string q)
        {
            bool r = false;

            cnx cnx = new cnx();

            if (cnx.abrir())
            {
                r = cnx.hacerHit(q);
            }
            return r;
        }

    }
}
