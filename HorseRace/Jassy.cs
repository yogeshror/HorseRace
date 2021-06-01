using System.Windows.Forms;

namespace HorseRace
{


    public class Jassy : Punter
    {
        public Jassy(Bet MyBet, Label MaximumBet, int Cash, Label MyLabel) : base(MyBet, MaximumBet, Cash, MyLabel)
        {
        }

        public override void setPunterName()
        {
            Name = "Jassy";
        }
    }
}
