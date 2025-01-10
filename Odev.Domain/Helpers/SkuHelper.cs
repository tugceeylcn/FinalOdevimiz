using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Helpers
{
    public static class SkuHelper
    {
        public static string GenerateSKU(string brand, string model, string voltage, string feature)
        {
            string brandAbbr = brand.Substring(0, Math.Min(brand.Length, 3)).ToUpper();

            string modelAbbr = model.Replace(" ", "").ToUpper();

            string voltageAbbr = voltage + "V";

            string featureAbbr = feature.ToUpper();

            string sku = $"{brandAbbr}-{modelAbbr}-{voltageAbbr}-{featureAbbr}";

            return sku;
        }
    }
}
