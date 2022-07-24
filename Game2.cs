using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using test_RPG.Essentials;
using test_RPG.Essentials.GameObjectsGame2;

namespace test_RPG
{
    public partial class Game2 : Form
    {
        int x;
        int y;
        Random rand = new Random();
        Player player;
        Pickaxe pickaxe;
        private System.Windows.Forms.Timer GameTimer = new System.Windows.Forms.Timer();
        private int speed = 5;
        private int gravity = 10;
        private int FPS = 2;
        private int force;
        private bool jump;
        public Game2()
        {
            InitializeComponent();
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            player = new Player(this);
            pickaxe = new Pickaxe(this);
            player.Spawn();
            pickaxe.Spawn();
            player.BringToFront();
            player.Location = new Point(19, 428);
            pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            GameTimer.Enabled = true;
            GameTimer.Interval = FPS;
            GameTimer.Tick += new EventHandler(Updater);
            RenderLevel(hodnoty.level);
        }
        private void Updater(Object Object, EventArgs eventArgs)
        {
            if (Imports.isUpPressed())
            {
                jump = true;
            }
            if (jump && force < 0) jump = false;
            if (jump)
            {
                gravity = -10;
                force -= 1;
            }
            else gravity = 10;
            if (Imports.isLeftPressed())
            {
                player.Left -= speed;
                pickaxe.Image = Properties.Resources.Diamond_Pickaxe_Left;
                pickaxe.Location = new Point(player.Location.X - 28, player.Location.Y + 12);
            }
            if (Imports.isRightPressed())
            {
                player.Left += speed;
                pickaxe.Image = Properties.Resources.Diamond_Pickaxe_Right;
                pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            }
            player.Top += gravity;
            pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y);
            foreach (Control i in this.Controls)
            {
                if (i is PictureBox && i.Tag == "block")
                {
                    if (player.Bounds.IntersectsWith(i.Bounds) && !jump)
                    {
                        force = 8;
                        player.Top = i.Top - 71;
                    }
                }
            }
        }
        private void RenderLevel(int room)
        {
            switch (room)
            {
                case 3:
                    for (int g = 0; g < 19; g++)
                    {
                        x = 52 * g;
                        y = 500;
                        MakePlatforms(Properties.Resources.Grass_Block);
                    }
                    for (int d = 0; d < 19; d++)
                    {
                        x = 52 * d;
                        y = 552;
                        MakePlatforms(Properties.Resources.Dirt_Block);
                    }
                    for (int e = 0; e < 19; e++)
                    {
                        x = 52 * e;
                        y = 604;
                        MakePlatforms(Properties.Resources.Dirt_Block);
                    }
                    pickaxe.SendToBack();
                    player.SendToBack();
                    break;
            }
        }
        private void MakePlatforms(Image material)
        {
            PictureBox block = new PictureBox();
            block.Tag = "block";
            block.BackColor = Color.Transparent;
            block.Height = 52;
            block.Width = 52;
            block.Image = material;
            block.SizeMode = PictureBoxSizeMode.Zoom;
            block.Location = new Point(x, y);
            block.BringToFront();

            this.Controls.Add(block);
        }
    }
}
