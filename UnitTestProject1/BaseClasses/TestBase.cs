using System;
using System.Data;
using System.Data.SqlClient;
using ApplicationDataConnector;
using BaseConnectionLibrary.ConnectionClasses;

namespace UnitTestProject1.BaseClasses
{
    public class TestBase : SqlServerConnection
    {
        public TestBase()
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "NorthWindAzure";
        }

        protected void ResetConnection()
        {
            SqlServerConnections.Instance.Reset(ConnectionString);
        }

        protected DataTable ConnectionWithUsingStatement()
        {
            var dt = new DataTable();

            using (var cn = SqlServerConnections.Instance.Connection(ConnectionString))
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

        public bool CustomersWithError2(out DataTable dtCustomers)
        {
            mHasException = false; 

            dtCustomers = new DataTable();

            // using a invalid field name
            const string selectStatement =
                "SELECT cust.CustomerIdentifer,cust.CompanyName,cust.ContactName,ct.ContactTitle, " +
                "cust.[Address] AS street,cust.City,ISNULL(cust.PostalCode,''),cust.Country,cust.Phone, " +
                "cust.ContactTypeIdentifier FROM dbo.Customers AS cust " +
                "INNER JOIN ContactType AS ct ON cust.ContactTypeIdentifier = ct.ContactTypeIdentifier;";

            using (var cn = SqlServerConnections.Instance.Connection(ConnectionString))
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement })
                {
                    try
                    {
                        dtCustomers.Load(cmd.ExecuteReader());
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }
    }
}
