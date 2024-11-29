using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Helpers;
public static class MonitorValueConverters
{
    public static string CalcPower(double kVoltage, double uAmpere, string format) => (kVoltage * uAmpere / 1000.0d).ToString(format, CultureInfo.InvariantCulture);
}
