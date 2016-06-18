﻿using System;
using KeePass.Plugins;
using QuickConnectPlugin.KeePass;

namespace QuickConnectPlugin {

    public class QuickConnectPluginSettings : IQuickConnectPluginSettings {

        public bool Enabled { get; set; }
        public bool CompatibleMode { get; set; }
        public String SSHClientPath { get; set; }
        public string WinScpPath { get; set; }
        public String HostAddressMapFieldName { get; set; }
        public String ConnectionMethodMapFieldName { get; set; }
        public string AdditionalOptionsMapFieldName { get; set; }

        private ICustomConfigPropertyNameFormatter formatter;
        private IPluginHost plugin;

        public static QuickConnectPluginSettings Load(IPluginHost pluginHost, ICustomConfigPropertyNameFormatter propertyNameFormatter) {
            QuickConnectPluginSettings options = new QuickConnectPluginSettings(pluginHost, propertyNameFormatter);
            options.Load();
            return options;
        }

        private QuickConnectPluginSettings(IPluginHost pluginHost, ICustomConfigPropertyNameFormatter propertyNameFormatter) {
            this.plugin = pluginHost;
            this.formatter = propertyNameFormatter;
        }

        /// <summary>
        /// Loads the plugin settings from the KeePass configuration file.
        /// </summary>
        public void Load() {
            this.Enabled = this.plugin.CustomConfig.GetBool(this.formatter.Format("Enabled"), true);
            this.CompatibleMode = this.plugin.CustomConfig.GetBool(this.formatter.Format("CompatibleMode"), false);
            this.SSHClientPath = this.plugin.CustomConfig.GetString(this.formatter.Format("SSHClientPath"), String.Empty);
            this.WinScpPath = this.plugin.CustomConfig.GetString(this.formatter.Format("WinScpPath"), String.Empty);
            this.HostAddressMapFieldName = this.plugin.CustomConfig.GetString(this.formatter.Format("HostAddressMapFieldName"), String.Empty);
            this.ConnectionMethodMapFieldName = this.plugin.CustomConfig.GetString(this.formatter.Format("ConnectionMethodMapFieldName"), String.Empty);
            this.AdditionalOptionsMapFieldName = this.plugin.CustomConfig.GetString(this.formatter.Format("AdditionalOptionsMapFieldName"), String.Empty);
        }

        /// <summary>
        /// Saves the plugin settings to the KeePass configuration file.
        /// </summary>
        public void Save() {

            this.plugin.CustomConfig.SetBool(this.formatter.Format("Enabled"), this.Enabled);
            this.plugin.CustomConfig.SetBool(this.formatter.Format("CompatibleMode"), this.CompatibleMode);
            this.plugin.CustomConfig.SetString(this.formatter.Format("SSHClientPath"), this.SSHClientPath);
            this.plugin.CustomConfig.SetString(this.formatter.Format("WinScpPath"), this.WinScpPath);
            this.plugin.CustomConfig.SetString(this.formatter.Format("HostAddressMapFieldName"), this.HostAddressMapFieldName);
            this.plugin.CustomConfig.SetString(this.formatter.Format("ConnectionMethodMapFieldName"), this.ConnectionMethodMapFieldName);
            this.plugin.CustomConfig.SetString(this.formatter.Format("AdditionalOptionsMapFieldName"), this.AdditionalOptionsMapFieldName);
        }
    }
}
