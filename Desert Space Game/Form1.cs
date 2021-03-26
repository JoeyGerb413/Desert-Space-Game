﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Desert_Space_Game
{
    public partial class Form1 : Form
    {
        Random randgen = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        //game descision variables
        int location = 1;
        string gameScreen = "title";

        //game over condition variables
        int health = 1;
        int sanity = 3;
        int deathTimer = 3000;
        int countdown = 3000;
        string playerName;

        string textGameOver = "yOU DIED";

        //keypress bools:

        //game bools
        bool engineer = false;
        bool scientist = false;
        bool officer = false;
        bool survivor = false;
        bool respirator = false;
        bool crowbar = false;
        bool preservation = false;
        bool airlockOpen = false;
        bool masterCode = false;
        bool survivorDead = false;
        bool broadcastOn = false;
        bool blueOrb = false;
        bool bomb = false;
        //other variables


        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            mLabel.Text = $"{location}";
            if (gameScreen == "game")
            {
                e.Graphics.FillRectangle(redBrush, 30, 30, health * 50, 5);

                e.Graphics.FillRectangle(greenBrush, 30, 80, sanity * 50, 5);
            }

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
                health = 1;
                sanity = 3;
                continueButton.Hide();
                location = 36;
                nameBox.Enabled = false;
                nameBox.Hide();
                playLabel.Show();
                settingLabel.Show();
                instructionLabel.Show();
                creditLabel.Show();

            }
            if (gameScreen == "opening")
            {
                playLabel.Hide();
                settingLabel.Hide();
                creditLabel.Hide();
                instructionLabel.Hide();
                continueButton.Show();
                continueButton.Enabled = true;
                nameBox.Enabled = true;
                nameBox.Show();
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
                settingLabel.Hide();
                creditLabel.Hide();
                instructionLabel.Hide();
                continueButton.Hide();
                nameBox.Hide();
                gameTimer.Enabled = true;
                this.BackColor = Color.Black;
            }

            }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
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
                countdown = 0;
                    location = 39;
                gameScreen = "gameOver";
            }
            if (bomb == true)
            {
                countdown--;
                bombLabel.Text = $"{countdown}";
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
            if (blueOrb == true)
            {
                deathTimer--;
                titleLabel.Text = $"{deathTimer}";
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
                        int medSkill = randgen.Next(1, 5);
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
                else if (location == 6) { location = 7; survivorDead = true; }
                else if (location == 7) { location = 9; }
                else if (location == 8) { location = 9; }
                else if (location == 9) { location = 13; }
                else if (location == 10) { location = 9; crowbar = true; sanity--; }
                else if (location == 11) { location = 9; }
                else if (location == 12) { location = 9; }
                else if (location == 13) { if (officer == true || masterCode == true) { location = 16; } else { location = 18; } }
                else if (location == 14) { } //nothing
                else if (location == 15) { location = 13; }
                else if (location == 16) { sanity--; location = 17; bomb = true; }
                else if (location == 17) { location = 21; }
                else if (location == 18) { health--; location = 19; broadcastOn = true; } // nothing
                else if (location == 19) { location = 9; }
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
                else if (location == 26) { location = 27; }
                else if (location == 27) { }
                else if (location == 28) { location = 9; }
                else if (location == 29) { location = 31; }
                else if (location == 30) { location = 38; } // end game scenes
                else if (location == 31) { location = 38; }
                else if (location == 32) { location = 32; }
                else if (location == 33) { }
                else if (location == 34) { }
                else if (location == 35) { location = 36; }
                else if (location == 36) { gameScreen = "opening"; continueButton.Show(); }
                else if (location == 37) { location = 36; }
                else if (location == 39) { location = 36; gameScreen = "title"; }
                else if (location == 99) { location = 0; }

                else if (location == -1)
                {
                    location = 1;
                }
                else if (location == -5) { location = 18; }

                else if (location == 39) { location = -1; health = 3; sanity = 3; }
            }


            if (e.KeyCode == Keys.W) //red
            {
                if (location == 0) { }
                else if (location == 1) { officer = true; location = 2; }
                else if (location == 2) { if (survivorDead == false) { location = 4; } else {redLabel.Text = $"He is gone {playerName}."; }
                    if (survivor == true) { location = 4; } else { redLabel.Text = $"You already saved him, {playerName}."; }
                }
                else if (location == 3) { location = 9; }
                else if (location == 4) { location = 5; }
                else if (location == 5) { location = 2; }
                else if (location == 6) { respirator = false; location = 8; }
                else if (location == 7) { location = 2; }
                else if (location == 8) { location = 2; }
                else if (location == 9) { location = 10; }
                else if (location == 10) { location = 9; }
                else if (location == 11) { location = 12; health--; preservation = true; }
                else if (location == 12) { location = 9; }
                else if (location == 13) { location = 14; sanity--; }
                else if (location == 14) { if (scientist == true) { location = 15; } else { location = 13; } }
                else if (location == 15) { location = 13; }
                else if (location == 16) { location = 18; }
                else if (location == 17) { location = -5; }
                else if (location == 18) { location = 20; health--; }
                else if (location == 19) { location = 9; }
                else if (location == 20) { location = 9; }
                else if (location == 21) { location = 13; }
                else if (location == 22) { if (broadcastOn == true) { location = 24; } else { location = 41; } }
                else if (location == 23) { location = 25; health--; }
                else if (location == 24) { location = 25; health--; }
                else if (location == 25) { location = 9; health--; blueOrb = true; }
                else if (location == 26) { location = 28; }
                else if (location == 27) { location = 39; }
                else if (location == 28) { location = 9; }
                else if (location == 29) { location = 32; }
                else if (location == 36) { location = 35; }
                else if (location == 39) { location = -1; gameScreen = "game"; storyLabel.Text = "Press any of the below keys to continue"; }

                else if (location == -1)
                {
                    location = 1;
                }
                else if (location == -5) { location = 18; }

            }

            if (e.KeyCode == Keys.N)
            {
                if (location == 0) { }
                else if (location == 1) { location = 2; engineer = true; }
                else if (location == 2) { if (respirator == false) { location = 3; } else { purpleLabel.Text = "You have already searched for supplies"; } }
                else if (location == 3) { location = 2; respirator = true; }
                else if (location == 9) { location = 11; }
                else if (location == 10 && bomb == true) { location = -3; }
                else if (location == 13) { location = 21; sanity--; masterCode = true; }
                else if (location == 18) { location = 18; health--; }
                else if (location == 21) { location = 13; }
                else if (location == 29) { location = 30; }
                else if (location == 39) { this.Close(); }
                else if (location == -3) { location = 9; }
            }
            if (e.KeyCode == Keys.B)
            {
                if (location == 9)
                {
                    if (airlockOpen == true || engineer == true || crowbar == true)
                    {
                        if ( engineer == true || preservation == true)
                        {
                            int functionality = randgen.Next(1, 11);
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
                    else { location = 40; }
                }
                else if (location == -1)
                {
                    location = 1;
                }
                else if (location == 40)
                {
                    location = 9;
                }
                if (e.KeyCode == Keys.V)
                {
                    if (location == 0)
                    {
                        location = 22;
                    }
                    else if (location == 9) { location = 22; }
                }



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
                    storyLabel.Text = "Removal of alien life in process. Countdown protocols underway ";
                    break;
                case -3:
                    int rand1 = randgen.Next(1, 4);
                    int rand2 = randgen.Next(1, 4);
                    int rand3 = randgen.Next(1, 4);
                    if (rand2 == rand1)
                    {
                        rand2 = randgen.Next(1, 4);
                    }
                    if (rand3 == rand2 || rand3 == rand1)
                    {
                        rand3 = randgen.Next(1, 4);
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
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 1:
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        storyLabel.Text = "You dream of your previous life. What was your passion, your name?";
                        greenLabel.Text = "I was a Scientist";
                        redLabel.Text = "I was an Officer";
                        purpleLabel.Text = "I was an Engineer";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 2:
                        storyLabel.Text = $"{playerName} awake in a room, remembering the crash. The mission, to your right is another crewmember.";
                        greenLabel.Text = "Exit the room";
                        redLabel.Text = "Check the other";
                        purpleLabel.Text = "Look for gear in this room";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 3:
                        storyLabel.Text = "You find an emergency respirator.";
                        greenLabel.Text = "";
                        redLabel.Text = "";
                        purpleLabel.Text = "Continue";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 4:
                        storyLabel.Text = "The crewmember appears to be lightly breathing. Maybe you could try and save them?";
                        greenLabel.Text = "Don't go into the light";
                        redLabel.Text = "Shame you were unlucky... nothing to do about it now.";
                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 5:
                        storyLabel.Text = $"The man coughs. {playerName}... why must I go? ";
                        greenLabel.Text = "He dies";
                        redLabel.Text = "Continue";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 6:

                        storyLabel.Text = "He rasps, gesturing at his legs. He won't be moving any time soon, and on a forign planet to boot. Its a dangerous spot.";
                        greenLabel.Text = "Abandon him";
                        redLabel.Text = "Give respirator";
                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 7:
                        storyLabel.Text = "He nods. You leave the room, no immediate intention to return";
                        greenLabel.Text = "continue";
                        redLabel.Text = "";
                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 8:
                        storyLabel.Text = "You give him the respirator, telling him not to move. You venture out into the crashed ship.";
                        greenLabel.Text = "";
                        redLabel.Text = "";
                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 9:
                        storyLabel.Text = "You observe the hallway of the ruin of the ship. The crash was so sudden... on a foreign planet, you realize you cannot expect unmaintained equipment to protect you forver.";
                        greenLabel.Text = "I can access ship functions in the control room";
                        redLabel.Text = "Maybe there will be something in the cockpit.";
                        purpleLabel.Text = "There could be something in the equipment room";
                        whiteLabel.Text = "I can broadcast a signal";
                        yellowLabel.Text = "I can access the airlock";
                        //storyBox.Image = ();
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

                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 11:
                        storyLabel.Text = "The equipment room took quite a beating. You see a hand reaching out from some rubble, the only uncrushed remnant of an unlucky crewmate.";
                        greenLabel.Text = "It is too dangerous, I am going to leave";
                        redLabel.Text = "There's got to be something in here";
                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 12:
                        storyLabel.Text = "A large beam falls, grazing your shoulder. You find an EP (Existence Preservation) Suit.";
                        greenLabel.Text = "";
                        redLabel.Text = "Continue";
                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        //storyBox.Image = ();
                        whiteLabel.Text = "";

                        Refresh();
                        break;
                    case 13:
                        storyLabel.Text = "You enter the control room. Most of the personnel is nothing but bloody corpses.";
                        greenLabel.Text = "Time to access the computer mainframe, see what is going on";
                        redLabel.Text = "Let's see if anyone is still alive.";
                        purpleLabel.Text = "Well, they don't have any need for their belongings.";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 14:
                        storyLabel.Text = "You throw up as you notice that death is ever prevalent. ";
                        greenLabel.Text = "";
                        redLabel.Text = "continue";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ()
                        Refresh();

                        break;
                    case 15:
                        storyLabel.Text = "You manage to save two of the personnel back. After some rest, they may live again.";
                        greenLabel.Text = "";
                        redLabel.Text = "continue";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 16:
                        storyLabel.Text = "After entering authentication, you access the private console. Within are documents never seen before... Red Sea, Jericho, Broken Paradise";
                        greenLabel.Text = "Let's investigate";
                        redLabel.Text = "I... I don't need to know what is in there.";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 17:
                        storyLabel.Text = "Exposition";
                        greenLabel.Text = "Attempt to delve further";
                        redLabel.Text = "Wipe files and restart computer";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 18:
                        storyLabel.Text = "You enter your name and password. You notice there are three ship functinos you could access";
                        greenLabel.Text = "Divert power to Comms";
                        redLabel.Text = "Divert power to Airlock";

                        purpleLabel.Text = "Divert power to Power";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 19:
                        storyLabel.Text = "Communication is now prepared";
                        greenLabel.Text = "continue";
                        redLabel.Text = "";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 20:
                        storyLabel.Text = "Airlock is now functional";
                        greenLabel.Text = "";
                        redLabel.Text = "continue";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 21:
                        storyLabel.Text = "You locate the captains body, finding the master code from the compute. You can access any function you wish.";
                        greenLabel.Text = "";
                        redLabel.Text = "";

                        purpleLabel.Text = "Continue";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 22:
                        storyLabel.Text = "You enter the broadcasting room";
                        greenLabel.Text = "Time to contact Earth, they can send backup";
                        redLabel.Text = "Initiate scan for lifeforms.";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 23:
                        storyLabel.Text = "You send a distress signal towards Earth, as well as all the research info the expedition compiled";
                        greenLabel.Text = "continue";
                        redLabel.Text = "";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 24:
                        storyLabel.Text = "There are four survivors, including you. Outside the ship, there are multiple energy spikes, and a single detectable lifeform";
                        greenLabel.Text = "";
                        redLabel.Text = "";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 25:
                        storyLabel.Text = "A distinct buzzing noise affects you. You clutch your head at the forbidden sound.";
                        greenLabel.Text = "Open comm channels";
                        redLabel.Text = "Run!";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 26:
                        storyLabel.Text = "A voice radiates through your mind. 'Who? Why? Come.";
                        greenLabel.Text = "Plead for my life";
                        redLabel.Text = "Look, I don't know who you are, but I am not compromising my life or freedom.";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 27:
                        storyLabel.Text = "'Harm. None. Wait.' You see a blue orb of light enter the room. You scream";
                        greenLabel.Text = "Run";
                        redLabel.Text = "Remain";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 28:
                        storyLabel.Text = "'Come. Outside. Speak'";
                        greenLabel.Text = "";
                        redLabel.Text = "Continue";

                        purpleLabel.Text = "";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 29:
                        storyLabel.Text = "Many blue lights are circling you.'Herald. Messenger. Enemy?";
                        greenLabel.Text = "I can be a herald";
                        redLabel.Text = "Uh, Messenger?";

                        purpleLabel.Text = "Make no mistake, I am nemy";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 32:
                        storyLabel.Text = "'Enemy. Ruin. Doom.";
                        greenLabel.Text = "Run accross planets surfac";
                        redLabel.Text = "Return to hub";

                        purpleLabel.Text = "Try and fight.";
                        yellowLabel.Text = "";
                        whiteLabel.Text = "";
                        //storyBox.Image = ();
                        Refresh();
                        break;
                    case 35:
                        storyLabel.Show();
                        mLabel.Text = "Welcome. This is a choice based game.";
                        break;

                    case 39:
                        storyLabel.Text = "Regretably, you have perished.";

                        

                        break;
                case 40:
                    storyLabel.Text = "The airlock is depowered. You cannot force it open";
                    yellowLabel.Text = "Continue";
                    break;
             }   
            }

        
        
       

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            try
            {
                gameScreen = "game";
                location = -1;
                continueButton.Enabled = false;
                playerName = Convert.ToString(nameBox);
                nameBox.Enabled = false;
                storyLabel.Show();
                storyLabel.Text = "Press any of the below keys to continue";
            }
            catch
            {
                nameBox.Text = "Enter letters";
            }
        }
    }
}
