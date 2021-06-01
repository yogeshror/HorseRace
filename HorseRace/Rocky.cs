using System.Windows.Forms;

namespace HorseRace
{


    public class Rocky : Punter
    {
        public Rocky(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setPunterName()
        {
            Name = "Rocky";
        }
    }
}
