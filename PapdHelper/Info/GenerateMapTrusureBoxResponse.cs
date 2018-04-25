using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class GenerateMapTrusureBoxResponse
    {
        public GenerateMapTrusureBoxResponseItem boxVO;
        public int targetStep;
    }

    public class GenerateMapTrusureBoxResponseItem
    {
        public string boxType;
        public string id;
        public string lng;
        public string lat;
    }
}
