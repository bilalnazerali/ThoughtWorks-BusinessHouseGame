namespace BusinessHouseGame {
    public interface IBank
    {
        /// <summary>
        /// Gets or sets the Bank Balance
        /// </summary>
        int Balance { get; }

        /// <summary>
        /// Credits the amount to the bank
        /// </summary>
        void Credit(int amount);

        /// <summary>
        /// Debit the amount from the bank
        /// </summary>
        void Debit(int amount);
    }
}

