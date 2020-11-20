using System;

namespace BusinessHouseGame {
    /// <summary>
    /// Represents the Player
    /// </summary>
    public class Player : IPlayer {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initalBalance"></param>
        public Player(int initalBalance) {
            Id = Guid.NewGuid().ToString();
            Balance = initalBalance;
            CurrentCellPosition = -1;
        }

        /// <summary>
        /// Gets or sets the balance
        /// </summary>
        public int Balance { get; private set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the current cell position
        /// </summary>
        public int CurrentCellPosition { get; set; }

        /// <summary>
        /// Gets or sets the asset balance
        /// </summary>
        public int AssetBalance { get; set; }

        /// <summary>
        /// Credit the amount to the player
        /// </summary>
        public void Credit(int amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Debit the amount from the player
        /// </summary>
        /// <param name="amount"></param>
        public void Debit(int amount)
        {
            Balance -= amount;
        }
    }
}

