using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BusinessHouseGame {
    class Program
    {
        static void Main(string[] args)
        {
            //Input Set : 1
            //string boardString = "J,H,L,H,E,L,H,L,H,J";
            //string diceOutput = "2,2,1, 4,4,2, 4,4,2, 2,2,1, 4,4,2, 4,4,2, 2,2,1";

            //Input Set : 2
            string boardString = "J,H,L,H,E,L,H,L,H,J";
            string diceOutput = "2,2,1, 4,2,3, 4,1,3, 2,2,7, 4,7,2, 4,4,2, 2,2,2";

            var container = new WindsorContainer();
            container.Register(Component.For<IBank>().ImplementedBy<Bank>().LifestyleSingleton());
            container.Register(Component.For<IPlayer>().ImplementedBy<Player>().LifestyleTransient());
            container.Register(Component.For<EmptyCell>().ImplementedBy<EmptyCell>().LifestyleTransient());
            container.Register(Component.For<JailCell>().ImplementedBy<JailCell>().LifestyleTransient());
            container.Register(Component.For<LotteryCell>().ImplementedBy<LotteryCell>().LifestyleTransient());
            container.Register(Component.For<HotelCell>().ImplementedBy<HotelCell>().LifestyleTransient());
            container.Register(Component.For<BusinessHouseGame>().ImplementedBy<BusinessHouseGame>().LifestyleSingleton());

            var bank = container.Resolve<IBank>(new Castle.MicroKernel.Arguments() { { "initialBalance", 5000}});

            var businessHouseGame = 
                container.Resolve<BusinessHouseGame>(
                    new Castle.MicroKernel.Arguments() { { "container", container}, { "bank", bank } }
                );

            var player1 = container.Resolve<IPlayer>(new Castle.MicroKernel.Arguments() { { "initalBalance", 1000 } });
            var player2 = container.Resolve<IPlayer>(new Castle.MicroKernel.Arguments() { { "initalBalance", 1000 } });
            var player3 = container.Resolve<IPlayer>(new Castle.MicroKernel.Arguments() { { "initalBalance", 1000 } });

            businessHouseGame.BuildBoard(boardString);

            string[] diceOutputArray = diceOutput.Split(',');

            for (int index = 0; index < diceOutputArray.Length; index = index + 3)
            {
                businessHouseGame.Move(Convert.ToInt32(diceOutputArray[index]), player1);
                businessHouseGame.Move(Convert.ToInt32(diceOutputArray[index + 1]), player2);
                businessHouseGame.Move(Convert.ToInt32(diceOutputArray[index + 2]), player3);
            }

            Console.WriteLine("Player-1 has total money {0} and asset of amount : {1}", player1.Balance, player1.AssetBalance);
            Console.WriteLine("Player-2 has total money {0} and asset of amount : {1}", player2.Balance, player2.AssetBalance);
            Console.WriteLine("Player-3 has total money {0} and asset of amount : {1}", player3.Balance, player3.AssetBalance);
            Console.WriteLine("Balance at Bank: {0}", bank.Balance);

            Console.ReadLine();
            container.Dispose();
        }
    }
}

