using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadroPaper
{
    internal class Material
    {
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public int CountInPack { get; set; }
        public string Unity { get; set; }
        public int CountOnStock { get; set; }
        public int MinPosBalance { get; set; }
        public int Price { get; set; }
    }
}
