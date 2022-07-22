using System;
using System.Drawing;
using System.Windows.Forms;
using test_RPG.Essentials;
using test_RPG.Essentials.GameObjects;

namespace test_RPG
{
    public partial class Form1 : Form
    {
        Player player;
        Food food;
        Gate gate;
        private int speed = 5;
        private Timer GameTimer = new Timer();
        private Timer timeleft = new Timer();
        private int FPS = 2;
        private Random random = new Random();
        private bool foodeaten = true;
        private int score = 0;
        private int level = 1;
        private bool gateeaten = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Player(this);
            food = new Food(this);
            gate = new Gate(this);
            player.Spawn();
            GameTimer.Enabled = true;
            timeleft.Enabled = true;
            GameTimer.Interval = 100;
            GameTimer.Interval = FPS;
            GameTimer.Tick += new EventHandler(Updater);
            timeleft.Tick += new EventHandler(timeleftevent);
            timebar.Value = 100;
        }
        private void Updater(Object myObject, EventArgs myEventArgs)
        {
            Barrier();
            if (Imports.isUpPressed())
            {
                player.Top -= speed;
                player.Image = Properties.Resources.Player_up;
            }
            if (Imports.isDownPressed())
            {
                player.Top += speed;
                player.Image = Properties.Resources.Player_down;
            }
            if (Imports.isLeftPressed())
            {
                player.Left -= speed;
                player.Image = Properties.Resources.Player_left;
            }
            if (Imports.isRightPressed())
            {
                player.Left += speed;
                player.Image = Properties.Resources.Player_right;
            }
            if (foodeaten)
            {
                food.Spawn();
                if (level == 2) food.BackColor = Color.MediumBlue;
                food.Location = new Point(random.Next(0, 600), random.Next(0, 600));
                food.Visible = true;
                foodeaten = false;
                Gatepercent();
            }
            foreach (Control i in this.Controls)
            { 
                if (i is PictureBox && i.Tag == "food")
                {
                    if (player.Bounds.IntersectsWith(i.Bounds))
                    {
                        foodeaten = true;
                        score++;
                        scorelbl.Text = "Score: " + score.ToString();
                        try { timebar.Value += 10; }
                        catch { timebar.Value = 100; }
                    }
                }
                if (i is PictureBox && i.Tag == "gate")
                {
                    if (player.Bounds.IntersectsWith(i.Bounds))
                    {
                        level = 2;
                        RenderLVL(level);
                    }
                }
            }
        }
        private void timeleftevent(Object myObject, EventArgs myEventArgs)
        {
            if (score <= 10) ScoreCalculator(1);
            if (score >= 10 && score <= 20) ScoreCalculator(2);
            if (score >= 20 && score <= 30) ScoreCalculator(3);
        }
        private void GameOver()
        {
            GameTimer.Enabled = false;
            timeleft.Enabled = false;
            MessageBox.Show("Game Over!\nYour Score: " + score, "Game", MessageBoxButtons.OK);
            Environment.Exit(0);
        }
        private void ScoreCalculator(int value)
        {
            try { timebar.Value -= value; }
            catch { GameOver(); }
        }
        private void Gatepercent()
        {
            int value = 0;
            if (score > 15)
            {
                value = 0;
                value = random.Next(0, 10);
            }
            if (score > 20)
            {
                value = 0;
                value = random.Next(5, 10);
            }
            if (score > 25)
            {
                value = 0;
                value = random.Next(7, 10);
            }
            if (value > 0)
            {
                gate.Spawn();
                if (level == 2) gate.BackColor = Color.MediumBlue;
                gate.Location = new Point(random.Next(0, 600), random.Next(0, 600));
                gate.Visible = true;
            }
        }
        private void RenderLVL(int room)
        {
            switch (room)
            {
                case 2:
                    player.BackColor = Color.MediumBlue;
                    food.BackColor = Color.MediumBlue;
                    score = 0;
                    timebar.Value = 100;
                    levellbl.Text = "Level: " + level.ToString();
                    this.BackColor = Color.MediumBlue;
                    gate.Visible = false;
                    break;
            }
        }
        private void Barrier()
        {
            if (player.Location.X < 5)
            {
                player.Location = new Point(player.Location.X + 10, player.Location.Y);
            }
            if (player.Location.X > 930)
            {
                player.Location = new Point(player.Location.X - 10, player.Location.Y);
            }
            if (player.Location.Y < 5)
            {
                player.Location = new Point(player.Location.X, player.Location.Y + 10);
            }
            if (player.Location.Y > 585)
            {
                player.Location = new Point(player.Location.X, player.Location.Y - 10);
            }
        }
    }
}
