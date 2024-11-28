using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Controls.DataModels;
public class AxisDisplayInfo
{
    public string PositionMonitor { get; }

    public string StageStateMonitor { get; }

    public string Unit { get; }

    public string StringFormat { get; }

    public string Text { get; }

    public AxisDisplayInfo(string axisId, string unit, string stringFormat, string text)
    {
        PositionMonitor = axisId + ".PositionMonitor";
        StageStateMonitor = axisId + ".StageStateMonitor";
        Unit = unit;
        StringFormat = stringFormat;
        Text = text;
    }
}
