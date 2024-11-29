using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Models;
public class SettingsModel
{

}

public class Settings : INotifyPropertyChanged
{
    private string _XTomServerConnectionString = "https://localhost:7199";

    public string XTomServerConnectionString
    {
        get { return _XTomServerConnectionString; }

        set
        {
            _XTomServerConnectionString = value;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
