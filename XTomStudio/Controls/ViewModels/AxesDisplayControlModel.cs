using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using XTomStudio.Controls.DataModels;
using XTomStudio.Core.Backbone;
using XTomStudio.Core.Contracts.Communication;
using XTomStudio.Core.Models;

namespace XTomStudio.Controls.ViewModels;
public class AxesDisplayControlModel : RemoteBaseViewModel
{
    private ObservableCollection<AxisDisplayInfo> _axesDisplayInfo;

    public ObservableCollection<AxisDisplayInfo> AxesDisplayInfo
    {
        get => _axesDisplayInfo;
        private set => SetProperty(ref _axesDisplayInfo, value);
    }

    public AxesDisplayControlModel(IRemoteClient remoteClient) : base(remoteClient)
    {
        _axesDisplayInfo = new ObservableCollection<AxisDisplayInfo>();
    }

    protected override void OnConfigurationChanged(RemoteCtConfiguration? configuration)
    {
        if (configuration == null)
            return;

        if (AxesDisplayInfo.Any())
            AxesDisplayInfo = new ObservableCollection<AxisDisplayInfo>();

        foreach (var axis in configuration.AxisConfigurations.Values)
        {
            switch (axis.DeviceId)
            {
                case "Spec_TransZ":
                    AxesDisplayInfo.Add(new AxisDisplayInfo(axis.DeviceId, "mm", "N3", "FOD"));
                    break;
                case "Det_TransZ":
                    AxesDisplayInfo.Add(new AxisDisplayInfo(axis.DeviceId, "mm", "N3", "FDD"));
                    break;
                case "Spec_TransY":
                    AxesDisplayInfo.Add(new AxisDisplayInfo(axis.DeviceId, "mm", "N3", "Y-Pos"));
                    break;
                case "Spec_RotY":
                    AxesDisplayInfo.Add(new AxisDisplayInfo(axis.DeviceId, "°", "N3", "Y-Rot"));
                    break;
                case "Spec_RotY_TransX":
                    AxesDisplayInfo.Add(new AxisDisplayInfo(axis.DeviceId, "mm", "N3", "X-Cen"));
                    break;
                case "Spec_RotY_TransZ":
                    AxesDisplayInfo.Add(new AxisDisplayInfo(axis.DeviceId, "mm", "N3", "Z-Cen"));
                    break;
                default:
                    break;
            }
        }
    }
}
