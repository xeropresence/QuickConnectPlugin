﻿using System;
using NUnit.Framework;
using QuickConnectPlugin.Tests;

namespace QuickConnectPlugin.ArgumentsFormatters.Tests {

    [TestFixture]
    public class CmdKeyUnregisterArgumentsFormatterTests {

        [TestCase]
        public void Format() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            CmdKeyUnregisterArgumentsFormatter argumentsFormatter = new CmdKeyUnregisterArgumentsFormatter();
            Assert.AreEqual("/delete:TERMSRV/127.0.0.1", argumentsFormatter.Format(pwEntry));
        }

        [TestCase]
        public void FormatWithPath() {
            InMemoryHostPwEntry pwEntry = new InMemoryHostPwEntry() {
                Username = "admin",
                Password = "12345678",
                IPAddress = "127.0.0.1"
            };
            pwEntry.ConnectionMethods.Add(ConnectionMethodType.RemoteDesktop);

            CmdKeyUnregisterArgumentsFormatter argumentsFormatter = new CmdKeyUnregisterArgumentsFormatter() {
                IncludePath = true
            };
            Assert.AreEqual(String.Format("\"{0}\" /delete:TERMSRV/127.0.0.1", CmdKeyRegisterArgumentsFormatter.CmdKeyPath), argumentsFormatter.Format(pwEntry));
        }
    }
}