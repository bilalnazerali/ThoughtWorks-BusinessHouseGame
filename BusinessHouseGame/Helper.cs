using System.Collections.Generic;

namespace BusinessHouseGame {
    /// <summary>
    /// Helper Class
    /// </summary>
    public class Helper
    {
        public const int LotteryPrize = 200;

        public const int JailFine = 150;
        /// <summary>
        /// Hotel type and it is buy value
        /// </summary>
        public static Dictionary<HotelType, int> HotelTypeValue = 
            new Dictionary<HotelType, int>() {
                { HotelType.Silver, 200 },
                { HotelType.Gold, 300 },
                { HotelType.Platinum, 500 }
            };

        /// <summary>
        /// Hotel type and it is rent
        /// </summary>
        public static Dictionary<HotelType, int> HotelTypeRent =
            new Dictionary<HotelType, int>() {
                { HotelType.Silver, 50 },
                { HotelType.Gold, 150 },
                { HotelType.Platinum, 300 }
            };

        /// <summary>
        /// Hotel type upgrade value
        /// </summary>
        public static Dictionary<HotelType, int> HotelTypeUpgradeValue =
            new Dictionary<HotelType, int>() {
                { HotelType.Silver, HotelTypeValue[HotelType.Silver] },
                { HotelType.Gold, HotelTypeValue[HotelType.Gold] - HotelTypeValue[HotelType.Silver] },
                { HotelType.Platinum, HotelTypeValue[HotelType.Platinum] - HotelTypeValue[HotelType.Gold] }
            };
    }
}

