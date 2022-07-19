﻿
using System;
using System.Text;
using Microsoft.Data.SqlClient;
using prenotazioni_postazioni_api.Utilities;
using Newtonsoft.Json;
using prenotazioni_postazioni_api.Exceptions;

namespace prenotazioni_postazioni_api.Repositories.Database
{
    public class DatabaseManager<T>
    {
        public static string DatabaseName { get; } = "[prenotazioni-impostazioni].dbo";
        public static string DefaultInitialCatalog { get; } = "prenotazioni-impostazioni";
        public static string DefaultDataSource { get; } = "LTP036";
        public readonly static string DEFAULT_DATABASE_NAME_STRING = "[prenotazioni - impostazioni].dbo";

        private SqlConnection? _conn;
        private ILogger<DatabaseManager<T>> logger;

        /// <summary>
        /// Costruttore vuoto per creare istanze
        /// </summary>
        private DatabaseManager()
        {

        }
        public DatabaseManager(ILogger<DatabaseManager<T>> logger)
        {
            this.logger = logger;
        }


        public T MakeQueryOneResult(string query)
        {
            logger.LogInformation("Mi connetto al database...");
            CreateConnectionToDatabase(null, null, true);
            logger.LogInformation("faccio una query al db");
            T value = JsonConvert.DeserializeObject<T>(GetAllResults(query));
            logger.LogInformation("Ho prelevato tutte le informazioni dal db con successo!");
            logger.LogInformation("mi disconnetto dal db");
            DeleteConnection();
            return value;
        }

        public T MakeQueryMoreResults(string query)
        {
            logger.LogInformation("Mi connetto al database...");
            CreateConnectionToDatabase(null, null, true);
            logger.LogInformation("faccio una query al db");
            T value = JsonConvert.DeserializeObject<T>(GetOneResult(query));
            logger.LogInformation("Ho prelevato tutte le informazioni dal db con successo!");
            logger.LogInformation("mi disconnetto dal db");
            DeleteConnection();
            return value;
        }

        public void MakeQueryNoResult(string query)
        {
            logger.LogInformation("Mi connetto al database...");
            CreateConnectionToDatabase(null, null, true);
            logger.LogInformation("faccio una query al db");
            GetNoneResult(query);
            logger.LogInformation("mi disconnetto dal db");
            DeleteConnection();
        }


        public static DatabaseManager<T> GetInstance()
        {
            return new DatabaseManager<T>();
        }

        /// <summary>
        /// Instaura una connesione al database
        /// </summary>
        /// <param name="initialCatalog">Nome del database</param>
        /// <param name="datasource">Nome del server sql</param>
        /// <param name="integratedSecurity">integrated security</param>
        private void CreateConnectionToDatabase(string? initialCatalog, string? datasource, bool integratedSecurity)
        {
            //significa che _conn ha gia un'istanza di SqlConnection
            if(checkConnectionDatabase())
            {
                return;
            }
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.TrustServerCertificate = true;
            connBuilder.InitialCatalog = initialCatalog ?? DefaultInitialCatalog;
            connBuilder.DataSource = datasource ?? DefaultDataSource;
            connBuilder.IntegratedSecurity = true;
            _conn = new SqlConnection(connBuilder.ToString());
        }

        private void DeleteConnection()
        {
            _conn = null;
        }

        /// <summary>
        /// Viene usato per restituire la prima colonna trovata
        /// </summary>
        /// <param name="query">la query al db</param>
        /// <returns>Json con il dato trovato</returns>
        private T GetOneResult(string query)
        {
            if (!checkConnectionDatabase())
            {
                throw new DatabaseException("Database connection not set");
            }
            using (var conn = _conn)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                Dictionary<string, object> result = new Dictionary<string, object>();
                int i = 0;
                while (reader.Read())
                {
                    result.Add(reader.GetName(i), reader[i]);
                    i++;
                }
                conn.Close();
                T value = result.ToObject<dynamic>();
                return value;
            }
        }

        protected IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        protected Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                        SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }

        /// <summary>
        /// Viene usato per restituire tutte le colonne trovate
        /// </summary>
        /// <param name="query">La query al db</param>
        /// <returns></returns>
        private string? GetAllResults(string query)
        {
            if (!checkConnectionDatabase())
            {
                throw new DatabaseException("Database connection not set");
            }
            using (var conn = _conn)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var values = new List<Dictionary<string, object>>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            var fieldValues = new Dictionary<string, object>();              
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                fieldValues.Add(reader.GetName(i), reader[i]);
                            }
                            values.Add(fieldValues);
                        }
                    } while (reader.NextResult());
                }
                conn.Close();
                var json = JsonConvert.SerializeObject(values);
                Console.WriteLine(json);
                return json;
               
            }
        }

        /// <summary>
        /// Viene usato quando la query non prevede nessun dato in ritorno
        /// </summary>
        /// <param name="query">La query al db</param>
        private void GetNoneResult(string query)
        {
            if (!checkConnectionDatabase())
            {
                throw new DatabaseException("Database connection not set");
            }
            using (var conn = _conn)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private bool checkConnectionDatabase()
        {
            if(_conn == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
