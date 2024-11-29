using System;
using Microsoft.Maui.Controls;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Models;

namespace XTomStudio.Controls
{
    public class XTomBaseControl : ContentView
    {
        protected IRemoteClient RemoteClient { get; }

        public XTomBaseControl()
        {
            RemoteClient = App.GetService<IRemoteClient>();
            RemoteClient.ConfigurationChanged += RemoteClient_ConfigurationChanged;
            OnConfigurationChanged(RemoteClient.RemoteCtConfiguration);
        }

        private void RemoteClient_ConfigurationChanged(object? sender, Core.Primitives.ConfigurationChangedEventArgs e)
            => OnConfigurationChanged(e.RemoteCtConfiguration);

        protected virtual void OnConfigurationChanged(RemoteCtConfiguration? configuration)
        {
            // Implement your logic here
        }
    }
}
