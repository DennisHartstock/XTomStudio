﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using XTomStudio.Contracts.Dialogs;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Primitives;

namespace XTomStudio.Dialogs;

public class Connect2XTomServerViewModel : ObservableRecipient
{
    private readonly IRemoteChannel _RemoteChannel;
    private readonly CancellationTokenSource _Cts = new();
    private readonly CancellationToken token = CancellationToken.None;
    private bool _Connecting;
    private bool _HasError;
    private string _ActionText = string.Empty;
    private string _ExplanationText = string.Empty;
    private string _PrimaryButtonText = string.Empty;
    

    public event EventHandler<ConnectionEstablishedEventargs>? ConnectionEstablished;

    public ICommand ConnectToServerCommand { get; }

    public bool Connecting
    {
        get => _Connecting;
        private set => SetProperty(ref _Connecting, value);
    }

    public bool HasError
    {
        get => _HasError;
        private set => SetProperty(ref _HasError, value);
    }

    public string ActionText
    {
        get => _ActionText;
        private set => SetProperty(ref _ActionText, value);
    }

    public string ExplanationText
    {
        get => _ExplanationText;
        private set => SetProperty(ref _ExplanationText, value);
    }

    public string PrimaryButtonText
    {
        get => _PrimaryButtonText;
        private set => SetProperty(ref _PrimaryButtonText, value);
    }

    public Connect2XTomServerViewModel(IRemoteChannel remoteChannel)
    {
        _RemoteChannel = remoteChannel;
        ConnectToServerCommand = new RelayCommand(async () => await ConnectToServer());
        token = _Cts.Token;
    }

    public Connect2XTomServerViewModel()
    {
    }

    private async Task ConnectToServer()
    {
        UpdateConnectionState(RemoteConnectionState.Connecting);
        ExplanationText = string.Empty;

        if (!_RemoteChannel.IsConnected)
        {
            try
            {
                await _RemoteChannel.ConnectAsyncCommand.Execute(CancellationToken.None);

                UpdateConnectionState(RemoteConnectionState.Connected);
                ConnectionEstablished?.Invoke(this, new ConnectionEstablishedEventargs());
            }
            catch (Exception ex)
            {
                HasError = true;
                ExplanationText = ex.Message;
                UpdateConnectionState(RemoteConnectionState.DisConnected);
            }
        }
        else
        {
            UpdateConnectionState(RemoteConnectionState.Connected);
        }
    }

    private void ConnectionStateMonitor_MonitorValueChanged(object? sender, MonitorValueChangedEventArgs<RemoteConnectionState> e)
    {
        MainThread.BeginInvokeOnMainThread(() => UpdateConnectionState(e.NewValue));
    }

    private void UpdateConnectionState(RemoteConnectionState state)
    {
        switch (state)
        {
            case RemoteConnectionState.DisConnected:
                ActionText = "Disconnected";
                PrimaryButtonText = "Retry";
                Connecting = false;
                break;
            case RemoteConnectionState.Connecting:
                ActionText = "Connecting...";
                PrimaryButtonText = string.Empty;
                Connecting = true;
                break;
            case RemoteConnectionState.Disconnecting:
                ActionText = "Disconnecting...";
                PrimaryButtonText = string.Empty;
                Connecting = false;
                break;
            case RemoteConnectionState.Connected:
                ActionText = "Connected";
                PrimaryButtonText = string.Empty;
                Connecting = false;
                break;
            default:
                ActionText = string.Empty;
                PrimaryButtonText = string.Empty;
                Connecting = false;
                break;
        }
    }
}
