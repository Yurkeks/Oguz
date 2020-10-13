using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oguz.Models
{
    public class OrderDto
    {
        public List<Material> Materials { get; set; }
        public Guid MaterialId { get; set; }
        public Guid StyleId { get; set; }
        public Guid ColorId { get; set; }
        public Material Material { get; set; }
    }

    public class Chart : BaseDbObject
    {

    }

    public class ChartDto
    {
        public string[] DataLabels { get; set; }
        public string[] DatasetsLabels { get; set; }

    }
}
