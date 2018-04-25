using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class PajkDownloadWalkDataResult
    {
        public float totalDistance;
        public float money;
        public List<PajkWalkDataInfo> walkDataInfos;
    }

    public class PajkWalkDataInfo
    {
        public long id;
        public float distance;
        public float stepCount;
        public long walkTime;
        public string walkDate;
        public float calories;
        public float targetStepCount;
    }
}
