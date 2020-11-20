namespace BusinessHouseGame {
    /// <summary>
    /// Represents Lottery Cell
    /// </summary>
    public class LotteryCell : BaseCell {
        /// <summary>
        /// Process the player entry
        /// </summary>
        public override void ProcessPlayerEntry() {
            Bank.Debit(Helper.LotteryPrize);
            Player.Credit(Helper.LotteryPrize);
        }
    }
}

