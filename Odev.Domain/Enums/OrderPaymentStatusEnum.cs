using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Enums
{
    public enum OrderPaymentStatusEnum : int
    {
        /// <summary> The parent. </summary>
        Parent = 1001,

        /// <summary> The pending. </summary>
        Pending = 100110,

        /// <summary> The waiting. </summary>
        Waiting = 100120,

        /// <summary> The completed. </summary>
        Completed = 100130,

        /// <summary> The returned. </summary>
        Returned = 100140,

        /// <summary> The cancelled. </summary>
        Cancelled = 100150,

        /// <summary> The cancelled. </summary>
        Error = 100151,
    }
}
