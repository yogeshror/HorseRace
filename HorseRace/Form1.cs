using System;
using System.Windows.Forms;

namespace HorseRace
{
    public partial class Form1 : Form
    {
        Horse[] horses = new Horse[4];

        PunterFactory pFactory = new PunterFactory();
        Punter[] punters = new Punter[3];

        public Form1()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {

            Horse.StartingPosition1 = Horse1.Right - racetrack.Left;
            Horse.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            horses[0] = new Horse() { HorsePictureBox = Horse1 };
            horses[1] = new Horse() { HorsePictureBox = Horse2 };
            horses[2] = new Horse() { HorsePictureBox = Horse3 };
            horses[3] = new Horse() { HorsePictureBox = Horse4 };

            punters[0] = pFactory.getPunter("Jassy", MaximumBet, JassyBet); //getting Jassy object from factory class
            punters[1] = pFactory.getPunter("Rocky", MaximumBet, RockyBet); //getting Rocky object from factory class
            punters[2] = pFactory.getPunter("Megan", MaximumBet, MeganBet); //getting Megan object from factory class


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();
            }
        }

        private void JimButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[0].Cash);
        }

        private void RogerButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[1].Cash);
        }

        private void MikeButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[2].Cash);
        }

        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = string.Format("Maximum Bet: ${0}", Cash);
        }

        // setting the bet for each Punter and updating labels respectively
        private void Bets_Click(object sender, EventArgs e)
        {
            int PunterNum = 0;

            if (JassyButton.Checked)
            {
                PunterNum = 0;
            }
            if (RockyButton.Checked)
            {
                PunterNum = 1;
            }
            if (MeganButton.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)BettingAmount.Value, (int)HorseNumber.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningHorse;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < horses.Length; i++)
                {
                    if (Horse.Run(horses[i]))
                    {
                        winningHorse = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Horse #" + winningHorse);
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningHorse); //give double amount to all who've won or deduce betted amount
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Horse horse in horses)
                        {
                            horse.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  //stop punters from betting if they run out of cash
                string message = "Do you want to Play Again?";
                string title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

        private void racetrack_Click(object sender, EventArgs e)
        {

        }
    }
}
