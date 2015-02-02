using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.SilverlightMediaFramework.Core.Request
{
    public enum RequestState
    {
        Initialize = 0, 
        Play = 1,
        Stop = 2,
        Leave = 3, 
    }
}
