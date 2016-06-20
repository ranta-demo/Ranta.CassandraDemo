using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using FluentCassandra.Connections;
using Common;

namespace FluentCassandra.Test
{
    [TestClass]
    public class FluentCassandraTest
    {
        [TestMethod]
        public void ConnectTest()
        {
            string ConnString = string.Format(Constant.ConnectionString, Constant.Keyspace);

            CassandraContext Db = new CassandraContext(new ConnectionBuilder(ConnString));

            Assert.AreEqual(true, Db.KeyspaceExists(Constant.Keyspace));
        }

        [TestMethod]
        public void KeyspaceTest()
        {
            string keyspaceName = Guid.NewGuid().ToString().Replace("-", string.Empty);

            string ConnString = string.Format(Constant.ConnectionString, keyspaceName);

            CassandraContext Db = new CassandraContext(new ConnectionBuilder(ConnString));

            Assert.AreEqual(false, Db.KeyspaceExists(keyspaceName));

            //创建Keyspace
            Db.Keyspace.TryCreateSelf();

            Assert.AreEqual(true, Db.KeyspaceExists(keyspaceName));

            //删除Keyspace
            Db.TryDropKeyspace(keyspaceName);

            Assert.AreEqual(false, Db.KeyspaceExists(keyspaceName));
        }

        [TestMethod]
        public void ColumnFamilyTest()
        {
            string keyspaceName = Guid.NewGuid().ToString().Replace("-", string.Empty);

            string ConnString = string.Format(Constant.ConnectionString, keyspaceName);

            CassandraContext Db = new CassandraContext(new ConnectionBuilder(ConnString));

            //创建Keyspace
            Db.Keyspace.TryCreateSelf();

            string familyName = Guid.NewGuid().ToString().Replace("-", string.Empty);

            //创建Column Family
            Db.AddColumnFamily(new Apache.Cassandra.CfDef
            {
                Name = familyName,
                Keyspace = keyspaceName
            });
            //或者使用 Keyspace.TryCreateColumnFamily(new CassandraColumnFamilySchema(type.Name));

            Assert.AreEqual(true, Db.ColumnFamilyExists(familyName));

            //删除 Column Family
            Db.TryDropColumnFamily(familyName);

            Assert.AreEqual(false, Db.ColumnFamilyExists(familyName));

            Db.TryDropKeyspace(keyspaceName);

            Assert.AreEqual(false, Db.KeyspaceExists(keyspaceName));
        }

        [TestMethod]
        public void DataTest()
        {
        }
    }
}
