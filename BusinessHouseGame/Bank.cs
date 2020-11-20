namespace BusinessHouseGame {
    /// <summary>
    /// Represents the bank
    /// </summary>
    public class Bank : IBank
    {
        /// <summary>
        /// Gets or sets the balance
        /// </summary>
        public int Balance { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Bank(int initialBalance)
        {
            Balance = initialBalance;
        }

        /// <summary>
        /// Credits the amount to bank
        /// </summary>
        public void Credit(int amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Debit the amount from the bank
        /// </summary>
        public void Debit(int amount)
        {
            Balance -= amount;
        }
    }
}

