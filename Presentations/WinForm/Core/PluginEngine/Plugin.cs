﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLife.Core.PluginEngine
{
    /// <summary>
    /// 借鉴来自WW里的代码，实现插件机制
    /// Base class to be derived by all plugins (loaded by PluginCompiler)
    /// Keep as light-weight as possible to keep plugin simple to write.
    /// </summary>
    public abstract class Plugin
    {
        /// <summary>
        /// Handle to the object
        /// </summary>
        protected MainApplication m_Application;

        /// <summary>
        /// The directory from which this plugin was loaded.
        /// </summary>
        protected string m_PluginDirectory;

        /// <summary>
        /// Plugin running flag (true while running, reset when exiting plugin)
        /// </summary>
        protected bool m_isLoaded;

        /// <summary>
        /// Reference to the World Wind main application object.  
        /// Deprecated: Use ParentApplication property instead!  
        /// TODO: Remove this to avoid name collision
        /// </summary>
        public virtual MainApplication Application
        {
            get
            {
                return m_Application;
            }
        }

        /// <summary>
        /// Reference to the World Wind main application object.
        /// </summary>
        public virtual MainApplication ParentApplication
        {
            get
            {
                return m_Application;
            }
        }

        /// <summary>
        /// The location this plugin was loaded from.
        /// </summary>
        public virtual string PluginDirectory
        {
            get
            {
                return m_PluginDirectory;
            }
        }

        /// <summary>
        /// Whether the plugin is currently running.
        /// </summary>
        public virtual bool IsLoaded
        {
            get
            {
                return m_isLoaded;
            }
        }

        /// <summary>
        /// Load the plugin.  This is the plugin entry point.
        /// </summary>
        public virtual void Load()
        {
            this.m_isLoaded = true;
            // Override with plugin initialization code.
        }

        /// <summary>
        /// Unload the plugin. Plugins that modify World Wind or 
        /// runs in background should override this method.
        /// </summary>
        public virtual void Unload()
        {
            this.m_isLoaded = false;
            // Override with plugin dispose code.
        }

        /// <summary>
        /// Base class load, calls Load. 
        /// </summary>
        /// <param name="parent"></param>
        public virtual void PluginLoad(MainApplication parent, string pluginDirectory)
        {
            if (m_isLoaded)
                // Already loaded
                return;

            m_Application = parent;
            m_PluginDirectory = pluginDirectory;
            Load();
            m_isLoaded = true;
        }

        /// <summary>
        /// Base class unload, calls Unload. 
        /// </summary>
        public virtual void PluginUnload()
        {
            Unload();
            m_isLoaded = false;
        }
    }
}
