using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace NLife.Core.Settings
{

    /// <summary>
    /// MainSettings persisted settings.
    /// </summary>
    public class MainSettings : SettingsBase
    {

        public MainSettings()
            : base()
        {

        }

        #region Plugin

        private System.Collections.ArrayList pluginsLoadedOnStartup = new System.Collections.ArrayList();

        [Browsable(true), Category("Plugin")]
        [Description("List of plugins loaded at startup.")]
        public System.Collections.ArrayList PluginsLoadedOnStartup
        {
            get
            {
                return pluginsLoadedOnStartup;
            }
        }

        #endregion

        #region File System Settings

        // File system settings
        private string configPath = "Config";
        private string dataPath = "Data";
        private bool validateXML = false;

        [Browsable(true), Category("FileSystem")]
        [Description("Location where configuration files are stored.")]
        public string ConfigPath
        {
            get
            {
                if (!Path.IsPathRooted(configPath))
                    return Path.Combine(MainDirectory, configPath);
                return configPath;
            }
            set
            {
                configPath = value;
            }
        }

        [Browsable(true), Category("FileSystem")]
        [Description("Location where data files are stored.")]
        public string DataPath
        {
            get
            {
                if (!Path.IsPathRooted(dataPath))
                    return Path.Combine(MainDirectory, dataPath);
                return dataPath;
            }
            set
            {
                dataPath = value;
            }
        }

        [Browsable(true), Category("FileSystem")]
        [Description("Validate XML Data on load.")]
        public bool ValidateXML
        {
            get
            {
                return validateXML;
            }
            set
            {
                validateXML = value;
            }
        }

        /// <summary>
        /// World Wind application base directory ("C:\Program Files\NASA\Worldwind v1.2\") 
        /// </summary>
        public readonly string MainDirectory = Path.GetDirectoryName(Application.ExecutablePath);

        #endregion

        // comment out ToString() to have namespace+class name being used as filename
        public override string ToString()
        {
            return "MainApplication";
        }
    }
}
