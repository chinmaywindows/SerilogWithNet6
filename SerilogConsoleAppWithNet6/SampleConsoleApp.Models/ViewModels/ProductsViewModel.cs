using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Models.ViewModels
{
    public class ProductsViewModel
    {
        public class ProductsInfoContainer
        {
            public RootObject RootObject { get; set; }

        }

        public class RootObject
        {
            public ResultDetails  ResultDetails {get;set;}

        }

        public class ResultDetails
        {
            public LightLoadText[] LightLoadText { get; set; }
            public PackingMaterial[] packingMaterials { get; set; }
        }

        public class LightLoadText
        {
            public int Code { get; set; }
            public string CodeDescription { get; set; }
        }

        public class PackingMaterial
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public string? Description { get; set; }

        }
    }
}
