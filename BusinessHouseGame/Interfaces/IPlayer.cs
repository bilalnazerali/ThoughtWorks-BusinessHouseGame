namespace BusinessHouseGame {
    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Get or sets the players balance
        /// </summary>
        int Balance { get; }

        /// <summary>
        /// Gets or sets the player asset balance
        /// </summary>
        int AssetBalance { get; set; }

        /// <summary>
        /// Credits the amount to the player
        /// </summary>
        void Credit(int amount);

        /// <summary>
        /// Debit the amount from the player
        /// </summary>
        void Debit(int amount);

        /// <summary>
        /// Gets or sets the current player cell position
        /// </summary>
        int CurrentCellPosition { get; set; }
    }
}

