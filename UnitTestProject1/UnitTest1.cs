using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Subject;
using UnitTestProject1.BaseClasses;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConnectionWithUsingStatement();

            Assert.IsTrue(ApplicationDataConnector
                              .SqlServerConnections
                              .Instance
                              .Connection(ConnectionString).State == ConnectionState.Open);

            var table = new DataTable();

            ConnectionWithUsingStatement();

            ApplicationDataConnector.SqlServerConnections.Instance.Connection(ConnectionString).Close();

            Assert.IsTrue(ApplicationDataConnector
                              .SqlServerConnections
                              .Instance
                              .Connection(ConnectionString).State == ConnectionState.Open);

            ResetConnection();

            Assert.IsTrue(ApplicationDataConnector
                              .SqlServerConnections
                              .Instance
                              .Connection(ConnectionString).State == ConnectionState.Open);



            CustomersWithError2(out table);
            
            Assert.IsTrue(ApplicationDataConnector
                              .SqlServerConnections
                              .Instance
                              .Connection(ConnectionString).State == ConnectionState.Open);

            Assert.IsTrue(table.Rows.Count == 0);
            Assert.IsTrue(LastExceptionMessage == "Invalid column name 'CustomerIdentifer'.");

        }

        [TestMethod]
        public void ValidateSubjectIncrementerTest()
        {
            var actualList = new List<string>();
            var expectedCount = 89;
            var actualCount = 0;

            for (var index = 1; index < 90; index++)
            {
                actualList.Add(ReferenceIncrementer.Instance.GetReferenceValue());
                actualCount = index;
            }

            Assert.IsTrue(actualCount == expectedCount,
                $"Expected count {expectedCount} but was {actualCount}");
        }
    }
}
