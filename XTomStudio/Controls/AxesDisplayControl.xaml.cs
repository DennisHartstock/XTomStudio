using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using XTomStudio.Controls.ViewModels;
using XTomStudio.Controls.DataModels;

namespace XTomStudio.Controls;
public sealed partial class AxesDisplayControl : UserControl
{
    public AxesDisplayControlModel ViewModel
    {
        get;
    }

    public AxesDisplayControl()
    {
        ViewModel = App.GetService<AxesDisplayControlModel>();
        this.InitializeComponent();
    }
}
