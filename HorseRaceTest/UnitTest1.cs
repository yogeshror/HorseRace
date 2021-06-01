using HorseRace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HorseRaceTest
{
    [TestClass]
    public class UnitTest1
    {
        PunterFactory pFactory = new PunterFactory();
        Punter Jassy;
        Horse[] horses = new Horse[2];

        [TestMethod]
        public void TestWinnerOutcome()
        {
            Horse.StartingPosition1 = 0;
            Horse.RacetrackLength1 = 50;
            int BettingAmount = 45;
            int HorseNumber = 1;
            int expectedWin = 90;
            int expectedLose = 0;
            horses[0] = new Horse() { HorsePictureBox = null };
            horses[1] = new Horse() { HorsePictureBox = null };
            Jassy = pFactory.getPunter("Jassy", null, null);
            Jassy.Cash = BettingAmount;
            Jassy.PlaceBet((int)BettingAmount, HorseNumber);

            bool nowin = true;
            int win = -1;
            while (nowin)
            {
                for (int i = 0; i < horses.Length; i++)
                {
                    if (Horse.Run(horses[i]))
                    {
                        win = i + 1;
                        Jassy.Collect(win);
                        nowin = false;

                    }
                }
            }
            if (Jassy.bet.horseNum == win)
            {
                Assert.AreEqual(expectedWin, Jassy.Cash, "Account not credited correctly");
            }
            if (Jassy.bet.horseNum != win)
            {
                Assert.AreEqual(expectedLose, Jassy.Cash, "Account not debited correctly");

            }
        }
    }

}
