namespace BusinessHouseGame {
    /// <summary>
    /// Represents Hotel Cell
    /// </summary>
    public class HotelCell : BaseCell {
        private IPlayer Owner { get; set; }

        private HotelType HotelType { get; set; }

        /// <summary>
        /// Process the player entry
        /// </summary>
        public override void ProcessPlayerEntry() {
            if (Owner == null) {
                Owner = Player;
                HotelType = HotelType.Silver;
                int buyOrSellAmount = Helper.HotelTypeUpgradeValue[HotelType];
                Owner.Debit(buyOrSellAmount);
                Bank.Credit(buyOrSellAmount);
                Owner.AssetBalance += buyOrSellAmount;
            }
            else if( Owner != null) {
                if (Owner.Id == Player.Id) {
                    if (HotelType == HotelType.Silver) {
                        HotelType = HotelType.Gold;
                    } else if (HotelType == HotelType.Gold) {
                        HotelType = HotelType.Platinum;
                    }
                    int buyOrSellAmount = Helper.HotelTypeUpgradeValue[HotelType];
                    Owner.Debit(buyOrSellAmount);
                    Bank.Credit(buyOrSellAmount);
                    Owner.AssetBalance += buyOrSellAmount;
                } else {
                    Owner.Credit(Helper.HotelTypeRent[HotelType]);
                    Player.Debit(Helper.HotelTypeRent[HotelType]);
                }
            }
        }
    }
}

