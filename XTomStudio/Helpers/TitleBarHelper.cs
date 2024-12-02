//using System.Runtime.InteropServices;

//using Microsoft.Maui.Controls;
//using Microsoft.Maui.Graphics;
//using XTomStudio.WinUI;

//namespace XTomStudio.Helpers;

//internal class TitleBarHelper
//{
//    private const int WAINACTIVE = 0x00;
//    private const int WAACTIVE = 0x01;
//    private const int WMACTIVATE = 0x0006;

//    [DllImport("user32.dll")]
//    private static extern IntPtr GetActiveWindow();

//    [DllImport("user32.dll", CharSet = CharSet.Auto)]
//    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

//    public static void UpdateTitleBar(ElementTheme theme)
//    {
//        var appWindow = App.Current.Windows[0].Handler.PlatformView as Microsoft.UI.Xaml.Window;
//        if (appWindow.ExtendsContentIntoTitleBar)
//        {
//            if (theme != ElementTheme.Default)
//            {
//                Application.Current.Resources["WindowCaptionForeground"] = theme switch
//                {
//                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
//                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
//                    _ => new SolidColorBrush(Colors.Transparent)
//                };

//                Application.Current.Resources["WindowCaptionForegroundDisabled"] = theme switch
//                {
//                    ElementTheme.Dark => new SolidColorBrush(Color.FromRgba(0x66, 0xFF, 0xFF, 0xFF)),
//                    ElementTheme.Light => new SolidColorBrush(Color.FromRgba(0x66, 0x00, 0x00, 0x00)),
//                    _ => new SolidColorBrush(Colors.Transparent)
//                };

//                Application.Current.Resources["WindowCaptionButtonBackgroundPointerOver"] = theme switch
//                {
//                    ElementTheme.Dark => new SolidColorBrush(Color.FromRgba(0x33, 0xFF, 0xFF, 0xFF)),
//                    ElementTheme.Light => new SolidColorBrush(Color.FromRgba(0x33, 0x00, 0x00, 0x00)),
//                    _ => new SolidColorBrush(Colors.Transparent)
//                };

//                Application.Current.Resources["WindowCaptionButtonBackgroundPressed"] = theme switch
//                {
//                    ElementTheme.Dark => new SolidColorBrush(Color.FromRgba(0x66, 0xFF, 0xFF, 0xFF)),
//                    ElementTheme.Light => new SolidColorBrush(Color.FromRgba(0x66, 0x00, 0x00, 0x00)),
//                    _ => new SolidColorBrush(Colors.Transparent)
//                };

//                Application.Current.Resources["WindowCaptionButtonStrokePointerOver"] = theme switch
//                {
//                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
//                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
//                    _ => new SolidColorBrush(Colors.Transparent)
//                };

//                Application.Current.Resources["WindowCaptionButtonStrokePressed"] = theme switch
//                {
//                    ElementTheme.Dark => new SolidColorBrush(Colors.White),
//                    ElementTheme.Light => new SolidColorBrush(Colors.Black),
//                    _ => new SolidColorBrush(Colors.Transparent)
//                };
//            }

//            Application.Current.Resources["WindowCaptionBackground"] = new SolidColorBrush(Colors.Transparent);
//            Application.Current.Resources["WindowCaptionBackgroundDisabled"] = new SolidColorBrush(Colors.Transparent);

//            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
//            if (hwnd == GetActiveWindow())
//            {
//                SendMessage(hwnd, WMACTIVATE, WAINACTIVE, IntPtr.Zero);
//                SendMessage(hwnd, WMACTIVATE, WAACTIVE, IntPtr.Zero);
//            }
//            else
//            {
//                SendMessage(hwnd, WMACTIVATE, WAACTIVE, IntPtr.Zero);
//                SendMessage(hwnd, WMACTIVATE, WAINACTIVE, IntPtr.Zero);
//            }
//        }
//    }

//    public static void ApplySystemThemeToCaptionButtons()
//    {
//        var res = Application.Current.Resources;
//        var frame = App.AppTitlebar as FrameworkElement;
//        if (frame != null)
//        {
//            if (frame.ActualTheme == ElementTheme.Dark)
//            {
//                res["WindowCaptionForeground"] = Colors.White;
//            }
//            else
//            {
//                res["WindowCaptionForeground"] = Colors.Black;
//            }

//            UpdateTitleBar(frame.ActualTheme);
//        }
//    }
//}
