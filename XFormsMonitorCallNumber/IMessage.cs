using System;
using System.Collections.Generic;
using System.Text;

namespace XFormsMonitorCallNumber
{
    public interface IMessage
    {
        void LongTime(string message);
        void ShortTime(string message);
    }
}
