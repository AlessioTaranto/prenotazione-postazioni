﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace test_db
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.InitialCatalog = "master";
            connBuilder.DataSource = "DESKTOP-B8G3449";
            connBuilder.IntegratedSecurity = true;

            string db = "[prenotazioni-impostazioni].dbo";
            string query = "SELECT descRuolo FROM "+db+".Ruoli;";

            //Insert example: INSEùRT INTO "+db+ ".Ruoli (idRuolo, descRuolo, accessoImpostazioni) VALUES ("+0+",'Amministratore',"+0+")

            using (SqlConnection conn = new SqlConnection(connBuilder.ToString())) {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var test = cmd.ExecuteScalar();

                conn.Close();
            }


            /*aefvbaeruiaerhin*/

        }
    }
}