using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Windowing;

namespace XTomStudio.Helpers;
internal class AppWindowHelper
{
    public static void MaximizeAppWindow()
    {
        IntPtr hWnd = WindowNative.GetWindowHandle(App.MainWindow);
        WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
        AppWindow appWindow = AppWindow.GetFromWindowId(wndId);
        appWindow?.SetPresenter(AppWindowPresenterKind.Overlapped);
        (appWindow?.Presenter as OverlappedPresenter)?.Maximize();
    }
}
