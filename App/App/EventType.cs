using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public enum EventType
    {
        ROTATE_CW = 1,
        ROTATE_CCW = 2,
        SINGLE_CLICK = 4,
        DOUBLE_CLICK = 5,
        TRIPLE_CLICK = 6,
        INVALID = -1
    }
}
