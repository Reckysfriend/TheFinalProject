using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Merchandise : Item
    {
        public MerchType MerchType {  get; private set; }
    }
    internal enum MerchType
    {
        Clothing,
        Figurin,
        Cups,
        Posters,
        Miscellaneous
    }
}
