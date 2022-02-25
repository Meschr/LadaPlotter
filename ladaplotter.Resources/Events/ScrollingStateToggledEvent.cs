using System;
using System.Collections.Generic;
using System.Text;

namespace ladaplotter.Resources.Events
{
    public class ScrollingStateToggledEvent
    {
        public ScrollingStateToggledEvent(bool state)
        {
            ToggleSwitchState = state;
        }
        public bool ToggleSwitchState { get; }
    }
}
