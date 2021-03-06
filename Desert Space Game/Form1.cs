using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Desert_Space_Game
{
    //Joey Gerber
    //Mr. T
    //ICS3U
    //The original installment in the incredibly impressive Voyagers series, Desert is a tale of a survivor of an interstellar disaster.
    //The player will act as this survivor, working to keep their health and sanity while navigating the ruin of the ship.
    public partial class Form1 : Form
    {
        Random randGen = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        //game descision variables
        int location = 1;
        string gameScreen = "title";

        //game over condition variables
        int health = 3;
        int sanity = 3;
        int deathTimer = 300;
        int countdown = 100;
        string playerName;
        int scene18Visited = 0;
        int scene4Visited = 0;
        int scene14Visited = 0;
        int scene16Visited = 0;
        int scene13Visited = 0;

        string textGameOver = "YOU DIED";

        //game bools
        bool hubVisit = true;
        bool engineer = false;
        bool scientist = false;
        bool officer = false;
        bool respirator = false;
        bool crowbar = false;
        bool preservation = false;
        bool airlockOpen = false;
        bool masterCode = false;
        bool broadcastOn = false;
        bool blueOrb = false;
        bool bomb = false;
        bool survivor = false;
        bool survivorDead = false;


        List<int> orbX = new List<int>();
        List<int> orbY = new List<int>();
        List<int> orbDirection = new List<int>();
        int orbLength = 7;
        int orbWidth = 20;

        List<int> orbSpeed = new List<int>();

        //sounds

        SoundPlayer beep = new SoundPlayer(Properties.Resources.beep_sound_effect);
        SoundPlayer impact = new SoundPlayer(Properties.Resources.impact);
        SoundPlayer wind = new SoundPlayer(Properties.Resources.heavy_wind);
        SoundPlayer ambience = new SoundPlayer(Properties.Resources.ambience);
        SoundPlayer vomit = new SoundPlayer(Properties.Resources.vomit);
        SoundPlayer zap = new SoundPlayer(Properties.Resources._456310__corruptinator__electricity_energy_2);

        //other paint variables
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameScreen == "game")
            {
                e.Graphics.FillRectangle(redBrush, 30, 30, health * 50, 5);

                e.Graphics.FillRectangle(greenBrush, 30, 60, sanity * 50, 5);
            }
            //Established Title variables to reset.
            if (gameScreen == "title")
            {
                this.BackColor = Color.Blue;
                storyLabel.Text = "";
                greenLabel.Text = "";
                redLabel.Text = "";
                purpleLabel.Text = "";
                yellowLabel.Text = "";
                whiteLabel.Text = "";
                healthLabel.Hide();
                sanityLabel.Hide();
                bombLabel.Hide();
                health = 3;
                sanity = 3;
                continueButton.Hide();
                location = 36; //establish location.
                nameBox.Enabled = false;
                nameBox.Hide();
                playLabel.Show();
                location = 36;
                deathTimer = 500;
                countdown = 500;
                titleLabel.Text = "DESERT";

                //bool reset
                engineer = false;
                scientist = false;
                officer = false;
                respirator = false;
                crowbar = false;
                preservation = false;
                airlockOpen = false;
                masterCode = false;
                blueOrb = false;
                broadcastOn = false;
                bomb = false;
                //reset images.
                roleBox.Hide();
                respiratorBox.Hide();
                crowbarBox.Hide();
                preservationSuitBox.Hide();
                masterKeyBox.Hide();
                airlockOnBox.Hide();
                broadcastOnBox.Hide();
                Refresh();
            }
            if (gameScreen == "opening")
            {
                playLabel.Hide();
                continueButton.Show();
                continueButton.Enabled = true;
                nameBox.Enabled = true;
                nameBox.Show();
                //bool reset
                engineer = false;
                scientist = false;
                officer = false;
                respirator = false;
                crowbar = false;
                preservation = false;
                airlockOpen = false;
                masterCode = false;
                blueOrb = false;
                broadcastOn = false;
                bomb = false;
                survivor = false;
                survivorDead = false;
                scene18Visited = 0;
                scene4Visited = 0;
                scene16Visited = 0;
                scene13Visited = 0;
                hubVisit = false;
                roleBox.Hide();
                respiratorBox.Hide();
                crowbarBox.Hide();
                preservationSuitBox.Hide();
                masterKeyBox.Hide();
                airlockOnBox.Hide();
                broadcastOnBox.Hide();
            }
            if (gameScreen == "game")
            {
                healthLabel.Show();
                sanityLabel.Show();
                storyLabel.Show();
                greenLabel.Show();
                redLabel.Show();
                purpleLabel.Show();
                yellowLabel.Show();
                purpleLabel.Show();
                playLabel.Hide();
                creditLabel.Hide();
                continueButton.Hide();
                nameBox.Hide();
                gameTimer.Enabled = true;
                this.BackColor = Color.Black;
            }
            //orb variables
            for (int i = 0; i < orbX.Count; i++)
            {
                e.Graphics.FillRectangle(blueBrush, orbX[i], orbY[i], orbLength, orbWidth);
            }
            if (scientist == true)
            {
                roleBox.Show();
                roleBox.Image = Properties.Resources.scientist1;
            }
            // inventory variables, on and off
            if (engineer == true)
            {
                roleBox.Show();
                roleBox.Image = Properties.Resources.engineer1;
            }
            if (officer == true)
            {
                roleBox.Show();
                roleBox.Image = Properties.Resources.officer1;
            }
            if (officer == false && engineer == false && scientist == false)
            {
                roleBox.Hide();
            }
            if (crowbar == true)
            {
                crowbarBox.Show();
                crowbarBox.Image = Properties.Resources.crowbar;
            }
            if (crowbar == false)
            {
                crowbarBox.Hide();
            }
            if (preservation == false)
            {
                preservationSuitBox.Hide();
            }
            if (respirator == true)
            {
                respiratorBox.Show();
            }
            if (respirator == false)
            {
                respiratorBox.Hide();
            }
            if (preservation == true)
            {
                preservationSuitBox.Show();
                preservationSuitBox.Image = Properties.Resources.preservation_suit1;
            }
            if (broadcastOn == true)
            {
                broadcastOnBox.Show();
                //broadcastOnBox.Image = Properties.Resources.broadcastOn;
            }
            if (broadcastOn == false)
            {
                broadcastOnBox.Hide();
            }
            if (airlockOpen == true)
            {
                airlockOnBox.Show();
            }
            if (airlockOpen == false)
            {
                airlockOnBox.Hide();
            }
            if (masterCode == true)
            {
                masterKeyBox.Show();
                masterKeyBox.Image = Properties.Resources.computerChip1;
            }
            if (masterCode == false)
            {
                masterKeyBox.Hide();
            }

        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //game over variables.
            if (health <= 0)
            {
                location = 39;
                gameScreen = "gameOver";
            }
            if (sanity <= 0)
            {
                location = 39;
                gameScreen = "gameOver";
            }
            if (deathTimer == 0)
            {
                deathTimer = 0;
                location = 39;
                gameScreen = "gameOver";
            }
            if (countdown == 0)
            {
                bomb = false;
                countdown = 0;
                location = 39;
                gameScreen = "gameOver";
            }
            if (bomb == true)
            {

                countdown--;
                bombLabel.Text = $"{countdown}";
                bombLabel.Show();
            }
            if (gameScreen == "gameOver")
            {
                location = 39;
                storyLabel.Text = $"{textGameOver}";
                greenLabel.Text = "Return to title";
                redLabel.Text = "Replay";
                purpleLabel.Text = "Exit";
                health = 3;
                sanity = 3;
            }

            //orb crisis
            if (blueOrb == true)
            {
                deathTimer--;
                titleLabel.Text = $"{deathTimer}";

                //establish orbs
                if (orbY.Count == 0)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        orbX.Add(randGen.Next(0, 800));
                        orbY.Add(randGen.Next(100, 700));
                        orbSpeed.Add(randGen.Next(1, 10));
                        int temporary = randGen.Next(0, 2);
                        if (temporary == 1)
                        {
                            orbDirection.Add(orbSpeed[i]);
                        }
                        else
                        {
                            orbDirection.Add(orbSpeed[i] * -1);
                        }

                    }
                }


                //orb movement
                for (int i = 0; i < orbX.Count; i++)
                {
                    orbX[i] += orbDirection[i];
                    if (orbX[i] > 0)
                    {
                        orbDirection[i] = orbDirection[i] * -1;
                    }
                    if (orbX[i] < 800)
                    {
                        orbDirection[i] = orbDirection[i] * -1;
                    }
                }
            }
            if (location == 38)
            {
                for (int i = 0; i < orbX.Count; i++)
                {
                    orbX.RemoveRange(0, orbX.Count); ;

                }
            }
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M) //green


            {
                if (location == 0) { if (respirator == true) { location = 6; } else { location = 2; } }
                else if (location == 1) { location = 2; scientist = true; }
                else if (location == 2) { location = 9; }
                else if (location == 3) { location = 9; }
                else if (location == 4)
                {
                    if (scientist == true)
                    { location = 0; }
                    else
                    {
                        int medSkill = randGen.Next(1, 5);
                        if (medSkill == 4)
                        {
                            survivor = true;
                            { location = 0; }
                        }
                        location = 5;
                        survivorDead = true;
                        sanity--;
                    }
                }
                else if (location == 5) { location = 2; }
                else if (location == 6) { location = 7; }
                else if (location == 7) { location = 9; }
                else if (location == 8) { location = 9; }
                else if (location == 9)
                {
                    location = 13;
                }
                else if (location == 10) { location = 9; crowbar = true; sanity--; }
                else if (location == 11) { location = 9; }
                else if (location == 12) { location = 9; }
                else if (location == 13) { if (scene16Visited == 0 && officer == true || scene16Visited == 0 && masterCode == true) { location = 16; } else if (scene18Visited == 0) { location = 18; } else { location = -13; } hubVisit = true; }
                else if (location == 14) { } //nothing
                else if (location == 15) { location = 13; }
                else if (location == 16) { sanity--; location = 17; bomb = true; }
                else if (location == 17) { location = 13; }
                else if (location == 18) { health--; location = 19; broadcastOn = true; } // nothing
                else if (location == 19) { location = 9; scene18Visited++; }
                else if (location == 20) { location = 9; }
                else if (location == 21) { location = 13; }
                else if (location == 22) { location = 23; }
                else if (location == 23) { location = 25; }
                else if (location == 24) { location = 25; }
                else if (location == 25)
                {
                    sanity--;
                    health--;
                    location = 26;
                }
                else if (location == 26) { location = 27; health--; sanity--; blueOrb = true; }
                else if (location == 27) { location = 9; }
                else if (location == 28) { location = 9; }
                else if (location == 29) { location = 31; }
                else if (location == 30) { location = 38; } // end game scenes
                else if (location == 31) { location = 38; }
                else if (location == 32) { location = 38; }
                else if (location == 33) { }
                else if (location == 34) { gameScreen = "opening"; continueButton.Show(); }
                else if (location == 35) { gameScreen = "opening"; continueButton.Show(); }
                else if (location == 36) { gameScreen = "opening"; continueButton.Show(); }
                else if (location == 37) { { gameScreen = "opening"; continueButton.Show(); } }
                else if (location == 38) { location = 36; gameScreen = "title"; }
                else if (location == 39) { location = 36; gameScreen = "title"; }
                else if (location == 99) { location = 0; }

                else if (location == -1)
                {
                    location = 1;
                }
                else if (location == -5) { location = 18; }

                else if (location == 39) { location = -1; health = 3; sanity = 3; }
                else if (location == -4) { location = 2; }
                else if (location == -12) { location = 11; }
                else if (location == -13) { location = 13; }
            }


            if (e.KeyCode == Keys.W) //red
            {
                if (location == 0) { location = 2; }
                else if (location == -2) { location = 38; }
                else if (location == 1) { officer = true; location = 2; }
                else if (location == 2)
                {
                    if (scene4Visited > 0) { location = -4; }

                    else { location = 4; }
                }
                else if (location == 3) { location = 9; }
                else if (location == 4) { location = 5; }
                else if (location == 5) { location = 2; scene4Visited++; }
                else if (location == 6) { respirator = false; location = 8; }
                else if (location == 7) { location = 2; scene4Visited++; }
                else if (location == 8) { location = 2; scene4Visited++; }
                else if (location == 9) { location = 10; }
                else if (location == 10) { location = 9; }
                else if (location == 11) { location = 12; health--; preservation = true; }
                else if (location == 12) { location = 9; }
                else if (location == 13) { if (scene14Visited == 0) { location = 14; sanity--; } else { location = -14; } hubVisit = true; }
                else if (location == 14) { if (scientist == true) { location = 15; } else { location = 13; } scene14Visited++; }
                else if (location == 15) { location = 13; }
                else if (location == 16) { location = 18; bomb = true; }
                else if (location == 17) { location = -5; }
                else if (location == 18) { location = 20; health--; }
                else if (location == 19) { location = 9; }
                else if (location == 20) { location = 9; scene18Visited++; }
                else if (location == 21) { location = 13; }
                else if (location == 22) { if (broadcastOn == true) { location = 24; } else { redLabel.Text = "Not enough power to initiate scan."; } }
                else if (location == 23) { location = 25; health--; }
                else if (location == 24) { location = 25; health--; }
                else if (location == 25) { location = 9; health--; blueOrb = true; }
                else if (location == 26) { location = 28; }
                else if (location == 27) { location = 39; }
                else if (location == 28) { location = 9; }
                else if (location == 29) { location = 32; }
                else if (location == 34) { gameScreen = "instructions"; }
                else if (location == 32) { location = 9; }
                else if (location == 35) { }
                else if (location == 36) { gameScreen = "instructions"; }
                else if (location == 37) { gameScreen = "instructions"; }
                else if (location == 38) { location = -2; }
                else if (location == 39) { location = -1; gameScreen = "game"; storyLabel.Text = "Press any of the below keys to continue"; }

                else if (location == -1)
                {
                    location = 1;
                }
                //bridge scene code.
                else if (location == -5) { location = 18; }
                else if (location == -4) { location = 2; }
                else if (location == -12) { location = 11; }
                else if (location == -13) { location = 13; }
                else if (location == -14) { location = 13; }
                else if (location == -14) { location = 13; }
            }

            if (e.KeyCode == Keys.N) // purple
            {
                if (location == 0) { }
                else if (location == 1) { location = 2; engineer = true; }
                else if (location == 2) { if (respirator == false) { location = 3; } else { purpleLabel.Text = "You have already searched for supplies"; } }
                else if (location == 3) { location = 2; respirator = true; }
                else if (location == 9) { location = 11; }
                else if (location == 10 && bomb == true) { location = -3; }
                else if (location == 13) { location = 21; sanity--; masterCode = true; hubVisit = true; }
                else if (location == 18) { location = 18; health--; }
                else if (location == 21) { location = 13; }
                else if (location == 22) { location = 9; }
                else if (location == 29) { location = 30; }
                else if (location == 32) { location = 42;  }
                else if (location == 36) { location = 34; }
                else if (location == 34) { location = 36; }
                else if (location == 38) { this.Close(); }
                else if (location == 39) { this.Close(); }
                else if (location == -3) { location = 9; }
            }
            if (e.KeyCode == Keys.B)
            {
                if (location == 9)
                {
                    if (airlockOpen == true || engineer == true || crowbar == true)
                    {
                        location = 29;
                        blueOrb = true;
                        if (engineer == true || preservation == true)
                        {

                            int functionality = randGen.Next(1, 11);
                            if (functionality == 10)
                            {
                                health--;
                            }
                        }
                        else
                        {
                            health--;
                        }
                    }
                    else
                    { location = 40; }
                }
                else if (location == 13) { location = 9; }
                else if (location == 36) { location = 37; }
                else if (location == 37) { location = 36; }
                else if (location == 38) { location = 36; gameScreen = "title"; }
                else if (location == -1)
                {
                    location = 1;
                }
                else if (location == 40)
                {
                    location = 9;
                }
            } //yellow

            if (e.KeyCode == Keys.V)
            {
                hubVisit = true;
                if (location == 0)
                {
                    location = 22;
                }
                else if (location == 9) { location = 22; }
                else if (location == 38) { location = 36; gameScreen = "title"; }

            } //white

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }



            //storyBox.Image = ();
            switch (location)
            {
                case 34:
                    break;
                case 35:
                    break;
                case 36:
                    break;
                case 37:
                    break;
            }
            switch (location)
            {
                case -5:
                    storyLabel.Text = "Removal of alien life in process. Countdown protocols  underway  ";
                    break;
                case -3:
                    int rand1 = randGen.Next(1, 4);
                    int rand2 = randGen.Next(1, 4);
                    int rand3 = randGen.Next(1, 4);
                    if (rand2 == rand1)
                    {
                        rand2 = randGen.Next(1, 4);
                    }
                    if (rand3 == rand2 || rand3 == rand1)
                    {
                        rand3 = randGen.Next(1, 4);
                    }
                    storyLabel.Text = $"You initiate the defusing process. Activate the labels, greatest to least: {rand1}, {rand2}, {rand3}";
                    greenLabel.Text = $"{rand1}";
                    redLabel.Text = $"{rand2}";
                    purpleLabel.Text = $"{rand3}";
                    break;
                case -1: //transition location, errors
                    break;

                case 0:
                    storyLabel.Text = "Compressing his chest and recalling medical knowledge from your past, the man returns from the brink. Though his right leg is very damaged.";
                    greenLabel.Text = "Continue";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    scene4Visited = 2;
                    Refresh();
                    break;
                case 1:
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyLabel.Text = "You dream of your previous life. What was your passion?";
                    greenLabel.Text = "I was a Scientist";
                    redLabel.Text = "I was an Officer";
                    purpleLabel.Text = "I was an Engineer";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    //storyBox.Image = ();
                    ambience.Play();
                    Refresh();
                    break;
                case 2:
                    storyLabel.Text = $"{playerName} awake in a room, remembering the crash. The mission, to your right is another crewmember.";
                    greenLabel.Text = "Exit the room";
                    redLabel.Text = "Check the other crewmate";
                    purpleLabel.Text = "Look for gear in this room";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.corridor);
                    Refresh();
                    break;
                case 3:
                    storyLabel.Text = "You find an emergency respirator.";
                    greenLabel.Text = "";
                    redLabel.Text = "";
                    purpleLabel.Text = "Continue";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.corridor);
                    Refresh();
                    break;
                case 4:
                    storyLabel.Text = "The crewmember appears to be lightly breathing. Maybe you could try and save them?";
                    greenLabel.Text = "Don't go into the light";
                    redLabel.Text = "Shame you were unlucky... nothing to do about it now.";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    storyBox.Image = (Properties.Resources.corridor);
                    Refresh();
                    break;
                case 5:
                    storyLabel.Text = $"The man coughs. {playerName}... why must I go? ";
                    greenLabel.Text = "He dies";
                    redLabel.Text = "Continue";

                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.corridor);
                    Refresh();
                    break;
                case 6:
                    storyLabel.Text = "He rasps, gesturing at his legs. He won't be moving any time soon, and on a forign planet to boot. Its a dangerous spot.";
                    greenLabel.Text = "Abandon him";
                    redLabel.Text = "Give respirator";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.corridor);
                    Refresh();
                    break;
                case 7:
                    storyLabel.Text = "He nods. You leave the room, no immediate intention to return";
                    greenLabel.Text = "continue";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.hallway);
                    Refresh();
                    break;
                case 8:
                    storyLabel.Text = "You give him the respirator, telling him not to move. You venture out into the crashed ship.";
                    greenLabel.Text = "";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.corridor);
                    Refresh();
                    break;
                case 9:
                    storyLabel.Text = "You observe the hallway of the ruin of the ship. The crash was so sudden... on a foreign planet, you realize you cannot expect unmaintained equipment to protect you forver.";
                    greenLabel.Text = "I can access ship functions in the control room";
                    redLabel.Text = "Maybe there will be something in the cockpit.";
                    purpleLabel.Text = "There could be something in the equipment room";
                    whiteLabel.Text = "I can broadcast a signal";
                    yellowLabel.Text = "I can access the airlock";
                    storyBox.Image = (Properties.Resources.hallway);
                    Refresh();
                    break;
                case 10:
                    if (engineer == true)
                    {
                        storyLabel.Text = "the pilots are keeled over, dead. You are glad you were not present for the crash.";
                    }
                    else
                    {
                        storyLabel.Text = "the pilots are keeled over, dead. ";
                    }
                    greenLabel.Text = "Maybe they have something useful on them.";
                    redLabel.Text = "I should respect the dead";
                    if (bomb == true) { purpleLabel.Text = "Drain excess explosive charge"; }
                    else
                    {
                        purpleLabel.Text = "";
                    }
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.cockpit1);
                    Refresh();
                    break;
                case 11:
                    storyLabel.Text = "The equipment room took quite a beating. You see a hand reaching out from some rubble, the only uncrushed remnant of an unlucky crewmate.";
                    greenLabel.Text = "It is too dangerous, I am going to leave";
                    redLabel.Text = "There's got to be something in here";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.engine1);
                    Refresh();
                    break;
                case 12:
                    storyLabel.Text = "A large beam falls, grazing your shoulder. You find an EP (Existence Preservation) Suit.";
                    greenLabel.Text = "";
                    redLabel.Text = "Continue";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    storyBox.Image = (Properties.Resources.engine1);
                    whiteLabel.Text = "";
                    impact.Play();
                    Refresh();
                    break;
                case 13:
                    if (hubVisit == false)
                    { storyLabel.Text = "You enter the control room. Most of the personnel is nothing but bloody corpses."; }
                    else
                    {
                        storyLabel.Text = "You may access the following areas of the ship";
                    }
                    greenLabel.Text = "Time to access the computer mainframe, see what is going on";
                    redLabel.Text = "Let's see if anyone is still alive.";
                    purpleLabel.Text = "Well, they don't have any need for their belongings.";
                    yellowLabel.Text = "Navigate other areas of the ship";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.controlRoom1);
                    Refresh();
                    break;
                case 14:
                    storyLabel.Text = "You throw up as you notice that death is ever prevalent. ";
                    greenLabel.Text = "";
                    redLabel.Text = "continue";

                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.controlRoom1);
                    vomit.Play();
                    Refresh();

                    break;
                case 15:
                    storyLabel.Text = "You manage to save two of the personnel back. After some rest, they may live again.";
                    greenLabel.Text = "";
                    redLabel.Text = "continue";

                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.controlRoom1);
                    ambience.Play();
                    Refresh();
                    break;
                case 16:
                    storyLabel.Text = "After entering authentication, you access the private console. Within are documents never seen before... Red Sea, Jericho, Broken Paradise";
                    greenLabel.Text = "Let's investigate";
                    redLabel.Text = "I... I don't need to know what is in there.";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    beep.Play();
                    Refresh();
                    break;
                case 17:
                    storyLabel.Text = "Exposition";
                    greenLabel.Text = "Attempt to delve further";
                    redLabel.Text = "Wipe files and restart computer";

                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    beep.Play();
                    Refresh();
                    break;
                case 18:
                    storyLabel.Text = $"Welcome, {playerName}Here are the accessible functions:";
                    greenLabel.Text = "Divert power to Comms";
                    redLabel.Text = "Divert power to Airlock";

                    purpleLabel.Text = "Divert power to Power";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    beep.Play();
                    Refresh();
                    break;
                case 19:
                    storyLabel.Text = "Communication is now prepared";
                    greenLabel.Text = "continue";
                    redLabel.Text = "";

                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    zap.Play();
                    Refresh();
                    break;
                case 20:
                    storyLabel.Text = "Airlock is now functional";
                    greenLabel.Text = "";
                    redLabel.Text = "continue";

                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    zap.Play();
                    Refresh();
                    break;
                case 21:
                    storyLabel.Text = "You locate the captains body, finding the master code from the compute. You can access any function you wish.";
                    greenLabel.Text = "";
                    redLabel.Text = "";
                    purpleLabel.Text = "Continue";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.controlRoom1);
                    vomit.Play();
                    Refresh();
                    break;
                case 22:
                    storyLabel.Text = "You enter the broadcasting room";
                    greenLabel.Text = "Time to contact Earth, they can send backup";
                    redLabel.Text = "Initiate scan for lifeforms.";
                    purpleLabel.Text = "Exit room.";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    beep.Play();
                    storyBox.Image = (Properties.Resources.engine1);
                    Refresh();
                    break;
                case 23:
                    storyLabel.Text = "You send a distress signal towards Earth, as well as all the research info the expedition compiled";
                    greenLabel.Text = "continue";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    beep.Play();
                    Refresh();
                    break;
                case 24:
                    storyLabel.Text = "There are four survivors, including you. Outside the ship, there are multiple energy spikes, and a single detectable lifeform";
                    greenLabel.Text = "";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    beep.Play();
                    Refresh();
                    break;
                case 25:
                    storyLabel.Text = "A distinct buzzing noise affects you. You clutch your head at the forbidden sound.";
                    greenLabel.Text = "Open comm channels";
                    redLabel.Text = "Run!";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    ambience.Play();
                    Refresh();
                    break;
                case 26:
                    storyLabel.Text = "A voice radiates through your mind. 'Who? Why? Come.";
                    greenLabel.Text = "Plead for my life";
                    redLabel.Text = "Look, I don't know who you are, but I am not compromising my life or freedom.";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    ambience.Play();
                    storyBox.Image = (Properties.Resources.computerScreen);
                    Refresh();
                    break;
                case 27:
                    storyLabel.Text = "'Harm. None. Wait.' You see a blue orb of light enter the room. You scream";
                    greenLabel.Text = "Run";
                    redLabel.Text = "Remain";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    ambience.Play();
                    storyBox.Image = (Properties.Resources.computerScreen);
                    Refresh();
                    break;
                case 28:
                    storyLabel.Text = "'Come. Outside. Speak'";
                    greenLabel.Text = "";
                    redLabel.Text = "Continue";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.computerScreen);
                    Refresh();
                    break;
                case 29:
                    storyLabel.Text = "You exit the airlock, walking onto the planets desolate surface. Many blue lights are circling you.'Herald. Messenger. Enemy?'";
                    greenLabel.Text = "I can be a herald";
                    redLabel.Text = "Uh, Messenger?";
                    purpleLabel.Text = "Make no mistake, I am enemy";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    if (storyLabel.Visible == true)
                    {
                        blueOrb = true;
                    }
                    storyBox.Image = (Properties.Resources.alienworld1);
                    ambience.Play();
                    Refresh();
                    break;
                case 30:
                    storyLabel.Text = "Your contact with extra-terrestrial life has resulted in your surival. The question is, will your message be a good one, or a bad one?";
                    greenLabel.Text = "You survived.";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.alienworld1);
                    Refresh();
                    break;
                case 31:
                    storyLabel.Text = "Go forth, herald. Bring word of our existance. As a warning towards your species curiosity.";
                    greenLabel.Text = "";
                    redLabel.Text = "";
                    purpleLabel.Text = "";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.alienworld1);
                    Refresh();
                    break;
                case 32:
                    storyLabel.Text = "'Enemy. Ruin. Doom.";
                    greenLabel.Text = "Run accross planets surface";
                    redLabel.Text = "Return to hub";
                    purpleLabel.Text = "Try and fight.";
                    yellowLabel.Text = "";
                    whiteLabel.Text = "";
                    storyBox.Image = (Properties.Resources.alienworld1);
                    Refresh();
                    break;
                case 35:
                    storyLabel.Show();
                    storyLabel.Text = "Welcome. This is a choice based game. After a brutal crash-landing, you will make choices to keep both your health and your sanity. Use the indicated keys for this purpose. Good luck.";
                    Refresh();
                    break;

                case 36:
                    break;
                case 38:
                    storyLabel.Text = "You have managed to survive the horrors for now... though time still runs out. In the future, there may be hope, or despair. The question is always of what is next.?";
                    greenLabel.Text = "Title Screen";
                    redLabel.Text = "Credits";
                    purpleLabel.Text = "Exit";
                    Refresh();
                    break;

                case 39:
                    storyLabel.Text = "Regretably, you have perished.";

                    break;
                case 40:
                    storyLabel.Text = "The airlock is depowered. You cannot force it open";
                    yellowLabel.Text = "Continue";
                    impact.Play();
                    Refresh();
                    break;
                case 42:
                    storyLabel.Text = "You flee as the blue orbs follow you. There is only one way to escape the terrors now...";
                    wind.Play();
                    //intention is that the player is required to press the escape button.
                    Refresh();
                    break;

                case -12:
                    storyLabel.Text = "You have already found the EP suit.";
                    redLabel.Text = "continue"; ;
                    Refresh();
                    break;

                case -13:
                    storyLabel.Text = "You cannot access any more computer functions.";
                    greenLabel.Text = "continue"; ;
                    Refresh();
                    break;
                case -14:
                    storyLabel.Text = "You have already checked those corpses";
                    redLabel.Text = "Continue";
                    break;
                case -18:
                    storyLabel.Text = "You do not have authorization.";
                    redLabel.Text = "continue"; ;
                    Refresh();
                    break;
                case -24:
                    storyLabel.Text = "There is not enough power to scan for lifeforms.";
                    redLabel.Text = "continue"; ;
                    Refresh();
                    break;

                case -23:
                    storyLabel.Text = "There is not enough power to send a message to earth.";
                    greenLabel.Text = "continue";
                    Refresh();
                    break;

            }

        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            try
            {
                gameScreen = "game";
                location = -1;
                continueButton.Enabled = false;
                playerName = Convert.ToString(nameBox.Text);
                nameBox.Enabled = false;
                storyLabel.Show();
                storyLabel.Text = "Press any of the below keys to continue";
            }
            catch
            {
                nameBox.Text = "Enter letters";
            }
        }


        private void StoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SettingLabel_Click(object sender, EventArgs e)
        {

        }

        private void CreditLabel_Click(object sender, EventArgs e)
        {

        }

        private void InstructionLabel_Click(object sender, EventArgs e)
        {

        }

        private void PlayLabel_Click(object sender, EventArgs e)
        {

        }

        private void BroadcastOnBox_Click(object sender, EventArgs e)
        {

        }
    }
}
