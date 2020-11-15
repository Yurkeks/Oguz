using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oguz.Models
{
    public class Chart : BaseDbObject
    {

    }

    public class ChartDto
    {
        public string[] DataLabels { get; set; }
        public string[] DatasetsLabels { get; set; }

    }
}
