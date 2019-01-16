using System;
using System.Collections.Generic;

namespace Responsible.Handler.Winforms.Progressors
{
    public class TextProgress
    {
        public bool ShowCombineMessages { get; set; }
        internal readonly List<string> Messages = new List<string>();
        
        public virtual void Report(string message)
        {
            Messages.Add(message);
        }
    }
}