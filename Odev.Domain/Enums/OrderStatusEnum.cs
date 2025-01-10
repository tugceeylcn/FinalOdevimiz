using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Enums
{
    public enum OrderStatusEnum : int
    {
        /// <summary>
        /// The waiting.
        /// </summary>
        [Display(Name = "Bekliyor")]
        Waiting = 100010,

        /// <summary>
        /// The preparing.
        /// </summary>
        [Display(Name = "Hazırlanıyor")]
        Preparing = 100020,

        /// <summary>
        /// The shipped.
        /// </summary>
        [Display(Name = "Kargoya Verildi")]
        Shipped = 100040,

        /// <summary>
        /// The packaged.
        /// </summary>
        [Display(Name = "Paketlendi")]
        Packaged = 100060,

        /// <summary>
        /// The delivered.
        /// </summary>
        [Display(Name = "Teslim Edildi")]
        Delivered = 100070,

        /// <summary>
        /// The cancel.
        /// </summary>
        [Display(Name = "İptal Edildi")]
        Cancel = 100080,

        /// <summary>
        /// The partial cancel.
        /// </summary>
        [Display(Name = "İade Edildi")]
        Retrun = 100100
    }
}
