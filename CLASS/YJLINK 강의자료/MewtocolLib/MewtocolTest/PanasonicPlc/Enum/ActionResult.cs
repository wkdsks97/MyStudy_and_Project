using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanasonicPlc
{
    public enum ActionResult
    {
        SUCCESS, FAIL, PENDING, TIMEOUT, ERROR, STOP, ABNORMAL,
    }
}
