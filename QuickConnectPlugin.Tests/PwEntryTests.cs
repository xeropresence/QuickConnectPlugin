﻿using System;
using System.IO;
using KeePassLib;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using NUnit.Framework;

namespace QuickConnectPlugin.Tests {

    [TestFixture]
    public class PwEntryTests {

        private readonly string databasePath = Path.GetFullPath(@"..\..\..\QuickConnectPlugin.Tests.Resources\sample.kdbx");
        private readonly string databasePassword = "12345678";

        private PwDatabase pwDatabase;


        [SetUp]
        public void Setup() {
            Assert.IsTrue(File.Exists(databasePath));
            var ioConnectionInfo = new IOConnectionInfo() {
                Path = databasePath
            };

            var key = new CompositeKey();
            key.AddUserKey(new KcpPassword(databasePassword));

            this.pwDatabase = new PwDatabase();
            this.pwDatabase.Open(ioConnectionInfo, key, null);
        }

        [TearDown]
        public void Cleanup() {
            if (this.pwDatabase != null) {
                this.pwDatabase.Close();
            }
        }

        [Test]
        public void PwEntry() {
            Assert.AreEqual(
                String.Empty,
                PwDatabaseUtils.FindEntryByTitle(this.pwDatabase, "Windows host sample", true).Strings.ReadSafe("")
            );
        }
    }
}
