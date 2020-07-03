using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    public partial class Form1 : Form
    {

        public class RussainRoulette
        {
            //global variable declaration
            public bool enableDisableFireButton;
            public bool enableDisablePlayAgainButton;
            public int[] gunArray = new int[5] { 0, 0, 0, 0, 0 };
            public int save;
            public int hit;
            public int counterVar = 0;
            public int clickCounterVar = 0;
            public bool enableDisable2;
            public int randomNumber;
            //class method

            public bool FireAwayButton()
            {
                return enableDisable2;
            }
            public int hitBybullet()
            {
                return hit;
            }

            public int saveBybullet()
            {
                return save;
            }

            public bool FireButtonAvailable()
            {

                return enableDisableFireButton;           //enable/disable button function.

            }

            public bool PlayAgainEnabledFalse()
            {

                return enableDisablePlayAgainButton;          //enable/disable button function.

            }

            public bool BulletLoadedInGun(Label label6)    //accessing form properties.
            {

                label6.Enabled = true;
                return true;

            }

            public void loadBullet()                        //bullet load into gun function.
            {

                Array.Resize(ref gunArray, gunArray.Length + 1);
                gunArray[5] = 1;

            }

            public int spinChamber()                        //Gun chambers spin Function.
            {

                Random rand = new Random();
                int randomIndex = rand.Next(0, gunArray.Length);
                int randomNumber = gunArray[randomIndex];
                return randomNumber;

            }
            public void FireAway(int randNumber1)
            {

                if(clickCounterVar >= 0 && clickCounterVar <= 1)
                {
                    save++;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GunEmpty);
                    player.Play();
                    enableDisableFireButton = true;
                    enableDisable2 = true;
                    enableDisablePlayAgainButton = false;           //this checks whether fireAway button has chance or not
                    PlayAgainEnabledFalse();        
                    FireButtonAvailable();
                    FireAwayButton();
                    if (randNumber1 == gunArray[5])
                    {
                        System.Media.SoundPlayer playerr = new System.Media.SoundPlayer(Resource1.awm);
                        playerr.Play();
                        save++;
                        save -= 1;
                        enableDisableFireButton = false;
                        enableDisable2 = false;                          // In this part if bullet is fired then we win the game.
                        enableDisablePlayAgainButton = true;
                        string message = "You Win the Game :)";
                        string title = "You Survived!!";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.awm);
                    player.Play();
                    hit++;
                    enableDisableFireButton = false;
                    enableDisable2 = false;
                    enableDisablePlayAgainButton = true;
                    PlayAgainEnabledFalse();        // In else part if life is used person is dead in shot and game become over
                    FireButtonAvailable();
                    FireAwayButton();
                    string message = "You loose the game :(";
                    string title = "You are dead!!";
                    MessageBox.Show(message, title);
                }

            }
            public void FireGun(int randNumber)              //this function fires the bullet
            {
                if (randNumber == gunArray[5] || counterVar == 5)       //In this check we are checking that bullet hits or not
                {              
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.awm);
                    player.Play();
                    hit++;
                    enableDisableFireButton = false;
                    enableDisable2 = false;
                    enableDisablePlayAgainButton = true;
                    PlayAgainEnabledFalse();        // This function checks whether bullet hits or not
                    FireButtonAvailable();
                    FireAwayButton();
                    string message = "You loose the game :(";
                    string title = "You are dead!!";
                    MessageBox.Show(message, title);

                }
                else if(clickCounterVar == 2)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.awm);
                    player.Play();
                    hit++;
                    enableDisableFireButton = false;
                    enableDisable2 = false;
                    enableDisablePlayAgainButton = true;
                    PlayAgainEnabledFalse();        // this part checks whether he loses his fireAway chance or not
                    FireButtonAvailable();
                    FireAwayButton();
                    string message = "You loose the game :(";
                    string title = "You are dead!!";
                    MessageBox.Show(message, title);
                }
                else
                {
                    save++;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GunEmpty);
                    player.Play();
                    enableDisableFireButton = true;
                    enableDisable2 = true;
                    enableDisablePlayAgainButton = false;             //if bullet is not hit it will increment the save var.
                    PlayAgainEnabledFalse();
                    FireButtonAvailable();
                    FireAwayButton();

                }
                    
               // }
                }
            }

        public Form1()
        {
            InitializeComponent();

            loadBullet.Enabled = true;
            spinChambers.Enabled = false;
            fireGun.Enabled = false;
            button1.Enabled = false;
            playAgain.Enabled = false;                  //Initial running component.
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

        }

        RussainRoulette robj = new RussainRoulette();
        int passVariable;

        private void loadBullet_Click(object sender, EventArgs e)
        {

            robj.loadBullet();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GunEmpty);
            player.Play();
            loadBullet.Enabled = false;                     // this function add bullet in gun.
            spinChambers.Enabled = true;
            bool a = robj.BulletLoadedInGun(label6);
            label6.Visible = a;

        }

        private void spinChambers_Click(object sender, EventArgs e)
        {

                passVariable = robj.spinChamber();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.mag);
                player.Play();
                spinChambers.Enabled = false;                                   // this function will take random number from the gun
                fireGun.Enabled = true;
                button1.Enabled = true;
                label6.Visible = false;
                bool a = robj.BulletLoadedInGun(label7);
                label7.Visible = a;
            
        }

        private void fireGun_Click(object sender, EventArgs e)
        {
            passVariable = robj.spinChamber();
            robj.FireGun(passVariable);                         //pass random value to fireGun function
            bool enableVar = robj.PlayAgainEnabledFalse();      //play again button will disable 
            playAgain.Enabled = enableVar;
            label7.Visible = false;
            bool enableVariable = robj.FireButtonAvailable();   //fire button will enable
            fireGun.Enabled = enableVariable;
            bool enableVar1 = robj.FireAwayButton();
            button1.Enabled = enableVar1;
            bool a = robj.BulletLoadedInGun(label7);          //enable label8
            label8.Visible = a;
            int b = robj.hitBybullet();
            label10.Text = b.ToString();
            int c = robj.saveBybullet();
            label9.Text = c.ToString();
            robj.counterVar++;
            
        }


        private void playAgain_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GameOver);
            player.Play();
            string message = "Game Is Over";
            string title = "Russian Roulette";
            MessageBox.Show(message, title);
            spinChambers.Enabled = false;                       //all buttons will become disable.
            playAgain.Enabled = false;                          //all buttons will become disable.     
            loadBullet.Enabled = true;                         //all buttons will become disable.    
            label8.Visible = false;                             //all label will be false.                                   
            robj.gunArray = new int[5] { 0, 0, 0, 0, 0 };       //this will reset as gun Empty.
            robj.save = 0;
            robj.hit = 0;
            label9.Text = "0";
            label10.Text = "0";
            robj.counterVar = 0;
            robj.clickCounterVar = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            passVariable = robj.spinChamber();
            robj.FireAway(passVariable);
            robj.counterVar++;
            robj.clickCounterVar++;
            bool enableVar = robj.PlayAgainEnabledFalse();      //play again button will disable 
            playAgain.Enabled = enableVar;
            bool enableVar1 = robj.FireAwayButton();
            button1.Enabled = enableVar1;
            label7.Visible = false;
            bool enableVariable = robj.FireButtonAvailable();   //fire button will enable
            fireGun.Enabled = enableVariable;
            bool a = robj.BulletLoadedInGun(label7);          //enable label8
            label8.Visible = a;
            int c = robj.saveBybullet();
            label9.Text = c.ToString();
            int b = robj.hitBybullet();
            label10.Text = b.ToString();
            
        }
    }
}
