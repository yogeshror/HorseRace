using System.Windows.Forms;

namespace HorseRace
{
    public class Megan : Punter
    {
        public Megan(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }
       public override void setPunterName()
        {
            Name = "Megan";
        }
    }
}
