﻿namespace HorseRace
{
    public class Bet
    {
        public int Amount;
        public int horseNum;
        public Punter Bettor;

        public Bet(int Amount, int horseNum, Punter Bettor)
        {
            this.Amount = Amount;
            this.horseNum = horseNum;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                description = string.Format("{0} bets {1} on horse #{2}",
                    Bettor.Name, Amount, horseNum);
            }
            else
            {
                description = string.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

        public int Pay(int Winner)
        {
            if (horseNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
