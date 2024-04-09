using System.Windows.Forms;
using System.IO;
using System.Media;

namespace gameWar
{
    public partial class Form1 : Form
    {
        int countHeart = 3, countScore = 0, elapsedTime = 0, speed = 10, moveTopBullet = 465, count = 0, countChecked = 0;
        int countNightLight = 0;
        int countChangeBack = 0;
        int countChangeSpeed = 0;
        int countBullet = 0;
        int bestCountScore = 0;
        bool isGhost = false;
        PictureBox myPictureBox = new PictureBox();
        PictureBox heartRandom = new PictureBox();
        PictureBox [] bullet = new PictureBox[1000];
        PictureBox bulletEnemyStrengh = new PictureBox();
        PictureBox bullet_Enemy = new PictureBox();

        Button isPlayAgain = new Button();
        Button isNotPlayAgain = new Button();
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            
        }
        void stopGameOver()
        {
            // sound play
            SoundPlayer simpleSound = new SoundPlayer(@"D:\projectnemone\project c#\gameWar\gameWar\musics\die.wav");
            simpleSound.Play();
            // save to best count score
            if (countScore > bestCountScore) bestCountScore = countScore;
            // stop timer
            timer1.Stop();

            pictureBox2.Visible = false;
            myPictureBox.Location = new Point(200, 100);
            myPictureBox.Size = new Size(300, 300);
            myPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            myPictureBox.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\game-over.png");
            if (countNightLight % 2 == 1)
            {
                myPictureBox.BackColor = DefaultBackColor;
                myPictureBox.BackColor = Color.MidnightBlue;
            }
            else
            {
                myPictureBox.BackColor = DefaultBackColor;
                myPictureBox.BackColor = Color.RoyalBlue;
            }
            this.Controls.Add(myPictureBox);
            myPictureBox.BringToFront();
            // second
            isPlayAgain.Location = new Point(280, 400);
            isPlayAgain.AutoSize = true;
            if (countNightLight % 2 == 1)
            {
                isPlayAgain.BackColor = DefaultBackColor;
                isPlayAgain.BackColor = Color.MidnightBlue;
            }
            else
            {
                isPlayAgain.BackColor = DefaultBackColor;
                isPlayAgain.BackColor = Color.RoyalBlue;
            }
            isPlayAgain.Text = "Play again    ";
            isPlayAgain.Font = new Font(isPlayAgain.Font.FontFamily, 18, isPlayAgain.Font.Style);
            this.Controls.Add(isPlayAgain);
            isPlayAgain.Click += isPlayAgain_Click;
            isPlayAgain.BringToFront();
            // is not play 
            isNotPlayAgain.Location = new Point(200, 400);
            isNotPlayAgain.AutoSize = true;
            if (countNightLight % 2 == 1)
            {
                isNotPlayAgain.BackColor = DefaultBackColor;
                isNotPlayAgain.BackColor = Color.MidnightBlue;
            }
            else
            {
                isNotPlayAgain.BackColor = DefaultBackColor;
                isNotPlayAgain.BackColor = Color.RoyalBlue;
            }
            isNotPlayAgain.Text = "End";
            isNotPlayAgain.Font = new Font(isNotPlayAgain.Font.FontFamily, 18, isNotPlayAgain.Font.Style);
            this.Controls.Add(isNotPlayAgain);
            isNotPlayAgain.Click += isNotPlayAgain_Click;
            isNotPlayAgain.BringToFront();

        }
        private void isPlayAgain_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            countHeart = 3;
            countScore = 0;
            displayCountHeart.Text = countHeart.ToString();
            displayCountStar.Text = countScore.ToString();
            speed = 10;
            countChangeBack = 0;
            elapsedTime = 0;
            countNightLight = 0;
            count = 0;
        }
        private void isNotPlayAgain_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"D:\projectnemone\project c#\gameWar\gameWar\info.txt", "your record: " + bestCountScore + Environment.NewLine);
            File.AppendAllText(@"D:\projectnemone\project c#\gameWar\gameWar\info.txt", "your score current: " + countScore);
            Application.Exit();
        }
        void moveStarDecorasion()
        {
            STAR1.Location = new Point(STAR1.Location.X, STAR1.Location.Y + 5);
            STAR2.Location = new Point(STAR2.Location.X, STAR2.Location.Y + 5);
            STAR3.Location = new Point(STAR3.Location.X, STAR3.Location.Y + 5);
            STAR6.Location = new Point(STAR6.Location.X, STAR6.Location.Y + 5);
            STAR7.Location = new Point(STAR7.Location.X, STAR7.Location.Y + 5);

            STAR1.SendToBack();
            STAR2.SendToBack();
            STAR3.SendToBack();
            STAR6.SendToBack();
            STAR7.SendToBack();

            if (STAR2.Location.Y >= 430)
            {
                STAR2.Location = new Point(706, 254);
            }
            if (STAR1.Location.Y >= 430)
            {
                STAR1.Location = new Point(533, 132);
            }
            if (STAR3.Location.Y >= 430)
            {
                STAR3.Location = new Point(396, 212);
            }
            if (STAR6.Location.Y >= 430)
            {
                STAR6.Location = new Point(210, 70);
            }
            if (STAR7.Location.Y >= 430)
            {
                STAR7.Location = new Point(59, 162);
            }

        }
        void bulletEnemy()
        {
            //bullet.Image = Image.FromFile(ImageCheckedBullet(countChecked));
            //bullet.Location = new Point(pictureBox1.Location.X + 25, 465);
            //bullet.SizeMode = PictureBoxSizeMode.Zoom;
            //bullet.Size = new Size(40, 40);
            //this.Controls.Add(bullet);
        }
        void Bullet_Enemy()
        {
            bullet_Enemy.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\bulleetEnemy.png");
            bullet_Enemy.Location = new Point(pictureBox2.Location.X + 20, pictureBox2.Location.Y);
            bullet_Enemy.SizeMode = PictureBoxSizeMode.Zoom;
            bullet_Enemy.Size = new Size(30, 30);
            this.Controls.Add(bullet_Enemy);
        }
        void bulletEnemystrengh()
        {
            bulletEnemyStrengh.Image = Image.FromFile(@"D:\\projectnemone\\project c#\\gameWar\\gameWar\\images\\icons8-bullet-67.png");
            bulletEnemyStrengh.Location = new Point(pictureBox1.Location.X + 25, 465);
            bulletEnemyStrengh.SizeMode = PictureBoxSizeMode.Zoom;
            bulletEnemyStrengh.Size = new Size(40, 40);
            this.Controls.Add(bulletEnemyStrengh);
        }
        void shot()
        {
            for (int i = 0; i < 1000; i++)
            {
                bullet[i] = new PictureBox();
                bullet[i].Image = Image.FromFile(ImageCheckedBullet(countChecked));
                bullet[i].SizeMode = PictureBoxSizeMode.Zoom;
                bullet[i].Size = new Size(40, 40);
            }          
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\Jet-enemy.png");
            //if (!pictureBox2.Bounds.IntersectsWith(bullet.Bounds))
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + speed);
            elapsedTime += timer1.Interval;
            if (elapsedTime == 100)
            {
                shot();
            } 
            if (countScore != 0 && countScore % 20 == 0)
            {
                countChangeBack++;
                //MessageBox.Show(countChangeBack + "");
                if (countChangeBack == 1)
                {
                    countNightLight++;
                    //MessageBox.Show(countChangeBack + "");
                    //MessageBox.Show(countNightLight + "");
                    if (countNightLight % 2 == 1)
                    {
                        //this.BackColor = DefaultBackColor;
                        this.BackColor = Color.MidnightBlue;
                        sun.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\moon.png");
                        sun.SendToBack();
                    }
                    else
                    {
                        //this.BackColor = DefaultBackColor;
                        this.BackColor = Color.RoyalBlue;
                        sun.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\son.png");
                        sun.SendToBack();
                    }
                    Random rnd = new Random();
                    heartRandom.Visible = true;
                    heartRandom.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\health.png");
                    heartRandom.Location = new Point(rnd.Next(1, 688), 1);
                    heartRandom.Size = new Size(75, 50);
                    heartRandom.SizeMode = PictureBoxSizeMode.Zoom;
                    this.Controls.Add(heartRandom);
                }

            }
            if (countScore != 0 && countScore % 21 == 0)
            {
                countChangeBack = 0;
            }
            if (elapsedTime % 5000 == 0 || countScore % 5 == 0)
            {
                countChangeSpeed++;
                if (countChangeSpeed == 1)
                {
                    speed += 2;
                }
            }
            if (elapsedTime % 5100 == 0) countChangeSpeed = 0;
            moveStarDecorasion();
            if (elapsedTime % 3000 == 0)
            {
                countScore++;
                displayCountStar.Text = countScore + "";
            }
            heartRandom.Location = new Point(heartRandom.Location.X, heartRandom.Location.Y + 10);
            if (heartRandom.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                heartRandom.Visible = false;
                countHeart++;
                displayCountHeart.Text = countHeart + "";
                heartRandom.Location = new Point(0, 0);
            }
            if (pictureBox2.Location.Y >= 600)
            {
                Random rnd = new Random();
                pictureBox2.Location = new Point(rnd.Next(1, 688), 0);
                countScore++;
                displayCountStar.Text = "";
                displayCountStar.Text = countScore + "";
                count = 0;
            }
            if (!isGhost)
                if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    Random rnd = new Random();
                    pictureBox2.Location = new Point(rnd.Next(1, 688), 0);
                    countHeart--;
                    displayCountHeart.Text = countHeart + "";
                    if (countHeart == 0)
                    {
                        stopGameOver();
                    }
                }
            if (pictureBox1.Bounds.IntersectsWith(bullet_Enemy.Bounds))
            {
                if (countHeart > 0)
                    countHeart--;
                if(countHeart == 0)
                {
                    stopGameOver();
                }
                displayCountHeart.Text = countHeart + "";
                bullet_Enemy.Location = new Point(pictureBox2.Location.X + 25, pictureBox2.Location.Y);
            }
            for(int i = 0; i <= countBullet; i++)
            {
                if (pictureBox2.Bounds.IntersectsWith(bullet[i].Bounds) && bullet[i].Visible == true)
                {
                    countScore += 2;
                    count++;
                    bullet[i].Visible = false;
                    //bullet[i].Location = new Point(pictureBox1.Location.X + 25, 465);
                    displayCountStar.Text = countScore + "";
                    if (count == 3)
                    {
                        Random rnd = new Random();
                        pictureBox2.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\Explosion.png");
                        pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y);
                        await Task.Delay(50);
                        pictureBox2.Location = new Point(rnd.Next(1, 688), 0);
                        //bullet[i].Location = new Point(pictureBox1.Location.X + 25, 465);
                        count = 0;
                        bullet[i].Visible = false;
                        // sound play
                        SoundPlayer simpleSound = new SoundPlayer(@"D:\projectnemone\project c#\gameWar\gameWar\musics\score.wav");
                        simpleSound.Play();
                    }
                }
            }
            if (bullet_Enemy.Location.Y >= 565) bullet_Enemy.Location = new Point(pictureBox2.Location.X + 25, pictureBox2.Location.Y);
            for(int i=0;i<=countBullet;i++)
            {

                if (bullet[i].Location.Y <= 2) bullet[i].Visible=false;
            }
            if (elapsedTime == 100)
            {
                //bulletEnemy();
                Bullet_Enemy();
            }
            if (elapsedTime%10000 == 0)
            {
                bulletEnemystrengh();
            }
            if (pictureBox2.Bounds.IntersectsWith(bulletEnemyStrengh.Bounds))
            {
                count = 0;
                Random rnd = new Random();
                pictureBox2.Image = Image.FromFile(@"D:\projectnemone\project c#\gameWar\gameWar\images\Explosion.png");
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y);
                await Task.Delay(50);
                pictureBox2.Location = new Point(rnd.Next(1, 688), 0);
                bulletEnemyStrengh.Visible = false;
                count = 0;
                // sound play
                SoundPlayer simpleSound = new SoundPlayer(@"D:\projectnemone\project c#\gameWar\gameWar\musics\score.wav");
                simpleSound.Play();
            }
            for(int i=0;i<=countBullet; i++)
            {
                if (bullet[i].Visible != false)
                bullet[i].Location = new Point(bullet[i].Location.X, bullet[i].Location.Y - 20);
            }
            bulletEnemyStrengh.Location = new Point(bulletEnemyStrengh.Location.X, bulletEnemyStrengh.Location.Y - 20);
            bullet_Enemy.Location = new Point(bullet_Enemy.Location.X, bullet_Enemy.Location.Y + 20);
        }
        void MoveJetLeft()
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X - 10, pictureBox1.Location.Y);

        }
        void MoveJetRight()
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (pictureBox1.Location.X >= 1)
                {

                    MoveJetLeft();

                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (pictureBox1.Location.X <= 688)
                    MoveJetRight();
            }
            if (e.KeyCode == Keys.G)
            {
                isGhost = true;
                isActiveGhost.Text = "On";
            }
            else if (e.KeyCode == Keys.H)
            {
                isGhost = false;
                isActiveGhost.Text = "Off";
            }
            if(e.KeyCode == Keys.Space)
            {
                countBullet++;
                bullet[countBullet].Location = new Point(pictureBox1.Location.X + 25, 465);
                Controls.Add(bullet[countBullet]);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                countChecked = 1;
                pictureBox1.Image = Image.FromFile(ImageChecked(countChecked));
            }
        }

        private void jet2_CheckedChanged(object sender, EventArgs e)
        {
            if (jet2.Checked)
            {
                countChecked = 2;
                pictureBox1.Image = Image.FromFile(ImageChecked(countChecked));
            }
        }

        private void jet3_CheckedChanged(object sender, EventArgs e)
        {
            if (jet3.Checked)
            {
                countChecked = 3;
                pictureBox1.Image = Image.FromFile(ImageChecked(countChecked));
            }
        }
        string ImageChecked(int check)
        {
            string result = "";
            if (check == 1)
            {
                result = @"D:\projectnemone\project c#\gameWar\gameWar\images\jet.png";
            }
            else if (check == 2)
            {
                result = @"D:\projectnemone\project c#\gameWar\gameWar\images\icons8-jet-64.png";
            }
            else if (check == 3)
            {
                result = @"D:\projectnemone\project c#\gameWar\gameWar\images\icons8-fighter-jet-48 (1).png";
            }
            return result;
        }
        string ImageCheckedBullet(int check)
        {
            string result = "";
            if (check == 1)
            {
                result = @"D:\projectnemone\project c#\gameWar\gameWar\images\Shot.png";
            }
            else if (check == 2)
            {
                result = @"D:\projectnemone\project c#\gameWar\gameWar\images\icons8-bullet-64 (1).png";
            }
            else if (check == 3)
            {
                result = @"D:\projectnemone\project c#\gameWar\gameWar\images\icons8-bullet-64 (2).png";
            }
            return result;
        }
        private void playTimer_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked || jet2.Checked || jet3.Checked)
            {
                labelChoose.Visible = false;
                jet2.Visible = false;
                jet3.Visible = false;
                radioButton1.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                playTimer.Visible = false;
                timer1.Start();
            }
        }
    }
}

