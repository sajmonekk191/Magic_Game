using System;
using System.Drawing;
using System.Windows.Forms;
using test_RPG.Essentials;
using test_RPG.Essentials.GameObjectsGame2;

namespace test_RPG
{
    public partial class Game2 : Form
    {
        Player player;
        Pickaxe pickaxe;
        private Timer GameTimer = new Timer();
        private int speed = 4;
        private int FPS = 2;
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
            pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            GameTimer.Enabled = true;
            GameTimer.Interval = FPS;
            GameTimer.Tick += new EventHandler(Updater);
        }
        private void Updater(Object Object, EventArgs eventArgs)
        {
            if (Imports.isUpPressed())
            {
                player.Top -= speed;
                pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y + 12);
            }
            if (Imports.isDownPressed())
            {
                player.Top += speed;
                pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y + 12);
            }
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
        }
    }
}
