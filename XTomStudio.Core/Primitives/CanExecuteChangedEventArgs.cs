using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTomStudio.Core.Primitives;
public class CanExecuteChangedEventArgs
{
    public bool Locked { get; }

    public CanExecuteChangedEventArgs(bool locked)
    {
        Locked = locked;
    }
}
