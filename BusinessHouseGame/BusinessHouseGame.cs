using System.Collections.Generic;
using Castle.Windsor;

namespace BusinessHouseGame {
    /// <summary>
    /// Represent business house game
    /// </summary>
    public class BusinessHouseGame {
        /// <summary>
        /// Gets or sets Bank
        /// </summary>
        private IBank Bank { get; set; }

        /// <summary>
        /// Gets or sets container
        /// </summary>
        private IWindsorContainer Container { get; set; }

        /// <summary>
        /// Gets or sets cells
        /// </summary>
        private List<BaseCell> Cells { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">IoC Container</param>
        /// <param name="bank">Bank instance</param>
        public BusinessHouseGame(IWindsorContainer container, IBank bank) {
            Cells = new List<BaseCell>();
            Container = container;
            Bank = bank;
        }

        /// <summary>
        /// Builds the Business House Board Game Celss
        /// </summary>
        /// <param name="boardString">Board game intput string</param>
        public void BuildBoard(string boardString) {
            string[] boardCellArray = boardString.Split(',');
            foreach (var boardCell in boardCellArray) {
                BaseCell baseCell = null;
                switch (boardCell)
                {
                    case "J":
                        baseCell = Container.Resolve<JailCell>();
                        break;
                    case "H":
                        baseCell = Container.Resolve<HotelCell>();
                        break;
                    case "L":
                        baseCell = Container.Resolve<LotteryCell>();
                        break;
                    case "E":
                        baseCell = Container.Resolve<EmptyCell>();
                        break;
                }
                Cells.Add(baseCell);
            }
        }

        /// <summary>
        /// Moves the player across the cells
        /// </summary>
        public void Move(int cellToMove, IPlayer player) {
            BaseCell cell = null;
            player.CurrentCellPosition += cellToMove;

            if (player.CurrentCellPosition >= Cells.Count) {
                player.CurrentCellPosition = player.CurrentCellPosition - Cells.Count;
            }
            cell = Cells[player.CurrentCellPosition];
            cell.Bank = Bank;
            cell.Player = player;
            cell.ProcessPlayerEntry();
        }
    }
}

