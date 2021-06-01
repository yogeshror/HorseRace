using System;
using System.Windows.Forms;

namespace HorseRace
{
    public class PunterFactory
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "jassy":
                    p = new Jassy(null, MaximumBet, 50, bet);
                    break;

                case "rocky":
                    p = new Rocky(null, MaximumBet, 50, bet);
                    break;

                case "megan":
                    p = new Megan(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.setPunterName();
            return p;
        }
    }
}
