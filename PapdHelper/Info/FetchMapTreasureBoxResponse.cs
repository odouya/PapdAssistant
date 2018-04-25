using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class FetchMapTreasureBoxResponse
    {
        public string boxId;
        public List<FetchMapTreasureBoxResponseItem> boxGiftList;
    }

    public class FetchMapTreasureBoxResponseItem
    {
        public string giftType;
        public int gold;
    }
}
