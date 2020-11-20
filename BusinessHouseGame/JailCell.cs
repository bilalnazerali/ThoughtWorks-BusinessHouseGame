namespace BusinessHouseGame {
    /// <summary>
    /// Represents Jail Cell
    /// </summary>
    public class JailCell : BaseCell {
        /// <summary>
        /// Process the player entry
        /// </summary>
        public override void ProcessPlayerEntry() {
            Bank.Credit(Helper.JailFine);
            Player.Debit(Helper.JailFine);
        }
    }
}

