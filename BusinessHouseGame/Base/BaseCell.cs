namespace BusinessHouseGame {
    /// <summary>
    /// Base Cell Class
    /// </summary>
    public abstract class BaseCell
    {
        /// <summary>
        /// Get or set Bank instance
        /// </summary>
        public IBank Bank { get; set; }

        /// <summary>
        /// Get or set Player instance
        /// </summary>
        public IPlayer Player { get; set; }

        /// <summary>
        /// Process the Player Entry
        /// </summary>
        public abstract void ProcessPlayerEntry();
    }
}

