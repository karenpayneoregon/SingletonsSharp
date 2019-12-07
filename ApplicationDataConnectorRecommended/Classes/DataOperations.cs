using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ApplicationDataConnectorRecommended.Properties;
using BaseConnectionLibrary.ConnectionClasses;

namespace ApplicationDataConnectorRecommended.Classes
{
    public class DataOperations : SqlServerConnection
    {
        public DataOperations()
        {
            DatabaseServer = ConfigurationManager.AppSettings["DatabaseServer"];
            DefaultCatalog = ConfigurationManager.AppSettings["DatabaseCatalog"];
            MainConnectionString = Settings.Default.MainConnectionString;
        }

        public string MainConnectionString { get; set; }

        public DataTable ConnectionUsingAppSettings() 
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection() {ConnectionString = ConnectionString})
            {
                mHasException = false;

                const string selectStatement =
                    "SELECT cust.CustomerIdentifier,cust.CompanyName,cust.ContactName,ct.ContactTitle, " +
                    "cust.[Address] AS street,cust.City,ISNULL(cust.PostalCode,''),cust.Country,cust.Phone, " +
                    "cust.ContactTypeIdentifier FROM dbo.Customers AS cust " +
                    "INNER JOIN ContactType AS ct ON cust.ContactTypeIdentifier = ct.ContactTypeIdentifier;";

                using (var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement })
                {
                    try
                    {
                        cn.Open();
                        dt.Load(cmd.ExecuteReader());
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }

            }

            return dt;
        }
        public DataTable ConnectionUsingProjectSetting() 
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection() { ConnectionString = MainConnectionString })
            {
                mHasException = false;

                const string selectStatement =
                    "SELECT cust.CustomerIdentifier,cust.CompanyName,cust.ContactName,ct.ContactTitle, " +
                    "cust.[Address] AS street,cust.City,ISNULL(cust.PostalCode,''),cust.Country,cust.Phone, " +
                    "cust.ContactTypeIdentifier FROM dbo.Customers AS cust " +
                    "INNER JOIN ContactType AS ct ON cust.ContactTypeIdentifier = ct.ContactTypeIdentifier;";

                using (var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement })
                {
                    try
                    {
                        cn.Open();
                        dt.Load(cmd.ExecuteReader());
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }

            }

            return dt;
        }
    }
}
