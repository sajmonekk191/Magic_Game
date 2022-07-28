using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using test_RPG.Essentials;
using test_RPG.Essentials.GameObjectsGame2;
using static test_RPG.Essentials.GameObjectsGame2.Colliders;

namespace test_RPG
{
    public partial class Game2 : Form
    {
        int x;
        int y;
        Random rand = new Random();
        Player player;
        Pickaxe pickaxe;
        Inventory inventory;
        private System.Windows.Forms.Timer GameTimer = new System.Windows.Forms.Timer();
        private int speed = 5;
        private int gravity = 10;
        private int itemgravity = 5;
        private int FPS = 2;
        private int jumpintensity;
        private bool jump;
        private int score = 0;
        public Game2()
        {
            InitializeComponent();
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            player = new Player(this);
            pickaxe = new Pickaxe(this);
            inventory = new Inventory(this);
            player.Spawn();
            pickaxe.Spawn();
            inventory.Spawn();
            player.BringToFront();
            pickaxe.BringToFront();
            player.Location = new Point(19, 428);
            pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            inventory.Location = new Point(860, 1020);
            GameTimer.Enabled = true;
            GameTimer.Interval = FPS;
            GameTimer.Tick += new EventHandler(Updater);
            this.Cursor = new Cursor("Crosshair.cur");
            RenderLevel(hodnoty.level);
        }
        private void Updater(Object Object, EventArgs eventArgs)
        {
            Barrier();
            if (Imports.isUpPressed())
            {
                jump = true;
            }
            if (jump && jumpintensity < 0) jump = false;
            if (jump)
            {
                gravity = -10;
                jumpintensity -= 1;
            }
            else gravity = 10;
            if (Imports.isLeftPressed())
            {
                hodnoty.isleft = true;
                player.Left -= speed;
                InventoryLoop(hodnoty.inventoryindex);
                pickaxe.Location = new Point(player.Location.X - 28, player.Location.Y + 12);
            }
            if (Imports.isRightPressed())
            {
                hodnoty.isleft = false;
                player.Left += speed;
                InventoryLoop(hodnoty.inventoryindex);
                pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            }
            if (Imports.isinventoryindex1())
            {
                hodnoty.inventoryindex = 1;
                InventorySelector("sword", hodnoty.isleft);

            }
            if (Imports.isinventoryindex2())
            {
                hodnoty.inventoryindex = 2;
                InventorySelector("pickaxe", hodnoty.isleft);
            }
            if (Imports.isinventoryindex3())
            {
                hodnoty.inventoryindex = 3;
                InventorySelector("axe", hodnoty.isleft);
            }
            foreach (Control i in this.Controls)
            {
                if (i is PictureBox && i.Tag == "breakable")
                {
                    if (PlayerCollider(player).IntersectsWith(BlockColliderDown(i.Bounds)))
                    {
                        player.Location = new Point(player.Location.X, i.Bottom + 10);
                    }
                    if (PlayerCollider(player).IntersectsWith(BlockColliderLeft(i.Bounds)))
                    {
                        player.Location = new Point(i.Left - 33, player.Location.Y);
                    }
                    if (PlayerCollider(player).IntersectsWith(BlockColliderRight(i.Bounds)))
                    {
                        player.Location = new Point(i.Right - 9, player.Location.Y);
                    }
                    if (PlayerColliderStand(player).IntersectsWith(BlockColliderStand(i.Bounds)) && !jump)
                    {
                        gravity = 0;
                        jumpintensity = 13;
                        player.Top = i.Top - 71;
                    }
                    var MousePos = this.PointToClient(Cursor.Position);
                    if (MouseCollider(MousePos.X, MousePos.Y).IntersectsWith(i.Bounds) && MouseCollider(MousePos.X, MousePos.Y).IntersectsWith(RangeCalculator(player.Location.X, player.Location.Y)) && Imports.isAttackPressed())
                    {
                        Image res = i.BackgroundImage;
                        i.Dispose();
                        MakeItem(res, "item", Color.Transparent, 25, 25, i.Location.X + 10, i.Location.Y + 30, false);
                    }
                    pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y + 12);
                }
                if (i is PictureBox && i.Tag == "item")
                {
                    if (PlayerCollider(player).IntersectsWith(i.Bounds))
                    {
                        score++;
                        scorelbl.Text = "Score: " + score;
                        i.Dispose();
                    }
                }
            }
            player.Top += gravity;
            pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y + 12);
        }
        private void RenderLevel(int room)
        {
            switch (room)
            {
                case 3:
                    // Ground //
                    for (int g = 0; g < 37; g++)
                    {
                        x = 52 * g;
                        y = 760;
                        MakePlatforms(Properties.Resources.Grass_Block, "breakable", x, y, true);
                    }
                    for (int d = 0; d < 37; d++)
                    {
                        x = 52 * d;
                        y = 812;
                        MakePlatforms(Properties.Resources.Dirt_Block, "breakable", x, y, true);
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 864;
                        MakePlatforms(Properties.Resources.Dirt_Block, "breakable", x, y, true);
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 916;
                        MakePlatforms(Properties.Resources.Stone, "breakable", x, y, true);
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 968;
                        MakePlatforms(Properties.Resources.Stone, "breakable", x, y, true);
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 1020;
                        MakePlatforms(Properties.Resources.Stone, "breakable", x, y, true);
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 1072;
                        MakePlatforms(Properties.Resources.Stone, "breakable", x, y, true);
                    }
                    // Ground //

                    // Tree //
                    SpawnTree(700, 608);
                    SpawnTree(1200, 608);
                    SpawnTree(1500, 608);
                    // Tree //

                    // Inventory //
                    x = 866;
                    y = 1026;
                    MakeItem(Properties.Resources.Diamond_Sword_Right, "hotbar", Color.DimGray, 48, 48, x, y, false);
                    x = x + 60;
                    MakeItem(Properties.Resources.Diamond_Pickaxe_Right, "hotbar", Color.DimGray, 48, 48, x, y, false);
                    x = x + 60;
                    MakeItem(Properties.Resources.Diamond_Axe_Right, "hotbar", Color.DimGray, 48, 48, x, y, false);
                    // Inventory //
                    pickaxe.SendToBack();
                    player.SendToBack();
                    foreach (Control i in this.Controls) if (i is PictureBox && i.Tag == "hotbar") i.BringToFront();
                    break;
            }
        }
        private void MakePlatforms(Image material, string tag, int x1, int y1, bool backimg)
        {
            PictureBox block = new PictureBox();
            block.Tag = tag;
            block.BackColor = Color.Transparent;
            block.Height = 52;
            block.Width = 52;
            block.Image = material;
            if (backimg) block.BackgroundImage = material;
            block.SizeMode = PictureBoxSizeMode.Zoom;
            block.Location = new Point(x1, y1);
            block.BringToFront();

            this.Controls.Add(block);
        }
        private void MakeItem(Image material, string tag, Color color, int x1, int y1, int x2, int y2, bool backimg)
        {
            PictureBox item = new PictureBox();
            item.Tag = tag;
            item.BackColor = color;
            item.Height = x1;
            item.Width = y1;
            item.Image = material;
            if(backimg) item.BackgroundImage = material;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.Location = new Point(x2, y2);
            item.BringToFront();

            this.Controls.Add(item);
        }
        private void Barrier()
        {
            if (player.Location.X < 1) player.Location = new Point(player.Location.X + 10, player.Location.Y);
            if (player.Location.X > 1890) player.Location = new Point(player.Location.X - 10, player.Location.Y);
        }
        private void InventorySelector(string selected, bool isleft)
        {
            switch (selected)
            {
                case "sword":
                    if (isleft) pickaxe.Image = Properties.Resources.Diamond_Sword_Left;
                    else pickaxe.Image = Properties.Resources.Diamond_Sword_Right;
                    break;
                case "pickaxe":
                    if (isleft) pickaxe.Image = Properties.Resources.Diamond_Pickaxe_Left;
                    else pickaxe.Image = Properties.Resources.Diamond_Pickaxe_Right;
                    break;
                case "axe":
                    if (isleft) pickaxe.Image = Properties.Resources.Diamond_Axe_Left;
                    else pickaxe.Image = Properties.Resources.Diamond_Axe_Right;
                    break;
            }
        }
        private void InventoryLoop(int slot)
        {
            switch (slot)
            {
                case 1:
                    InventorySelector("sword", hodnoty.isleft);
                    break;
                case 2:
                    InventorySelector("pickaxe", hodnoty.isleft);
                    break;
                case 3:
                    InventorySelector("axe", hodnoty.isleft);
                    break;
            }
        }
        private void SpawnTree(int x, int y)
        {
            int ofset = 52;
            int x1 = x;
            int y1 = y;
            for (int e = 0; e < 3; e++)
            {
                y1 = y + (52 * e);
                MakePlatforms(Properties.Resources.Wood, "breakable", x1, y1, true);
            }
            x1 = x1 - 2 * ofset;
            y1 = y1 - 5 * ofset;
            for (int e = 0; e < 6; e++)
            {
                if (e >= 0 && e <= 2)
                {
                    x1 = x1 + 52;
                    MakePlatforms(Properties.Resources.Leaves, "breakable", x1, y1, true);
                    if (e > 1)
                    {
                        x1 = x1 - 4 * ofset;
                        y1 = y1 + ofset;
                    }
                }
                if (e == 4)
                {
                    for (int g = 0; g < 5; g++)
                    {
                        x1 = x1 + 52;
                        MakePlatforms(Properties.Resources.Leaves, "breakable", x1, y1, true);
                        if (g > 3)
                        {
                            y1 = y1 + 52;
                            x1 = x1 - 5 * ofset;
                        }
                    }
                }
                if (e == 5)
                {
                    for (int g = 0; g < 5; g++)
                    {
                        x1 = x1 + 52;
                        MakePlatforms(Properties.Resources.Leaves, "breakable", x1, y1, true);
                    }
                }
            }
        }
    }
}
