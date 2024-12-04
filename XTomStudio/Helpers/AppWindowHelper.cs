using System;
using Microsoft.Maui.Controls;

namespace XTomStudio.Helpers;
internal class AppWindowHelper
{
    public static void MaximizeAppWindow()
    {
        var window = Application.Current.MainPage.Window;
        if (window != null)
        {
            window.Width = DeviceDisplay.MainDisplayInfo.Width;
            window.Height = DeviceDisplay.MainDisplayInfo.Height;
        }
    }
}
