using System;
using System.Drawing;
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
        private int FPS = 2;
        private int jumpintensity;
        private bool jump;
        public Game2()
        {
            InitializeComponent();
        }

        private void Game2_Load(object sender, EventArgs e)
        {
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
                if (i is PictureBox && i.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(i.Bounds) && !jump)
                    {
                        gravity = 0;
                        jumpintensity = 13;
                        player.Top = i.Top - 71;
                    }
                }
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
                        i.Dispose();
                    }
                    pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y + 12);
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
                    for (int g = 0; g < 19; g++)
                    {
                        x = 52 * g;
                        y = 500;
                        MakePlatforms(Properties.Resources.Grass_Block, "platform");
                    }
                    for (int d = 0; d < 19; d++)
                    {
                        x = 52 * d;
                        y = 552;
                        MakePlatforms(Properties.Resources.Dirt_Block, "platform");
                    }
                    for (int e = 0; e < 19; e++)
                    {
                        x = 52 * e;
                        y = 604;
                        MakePlatforms(Properties.Resources.Dirt_Block, "platform");
                    }
                    // Ground //

                    // Tree //
                    for (int e = 0; e < 4; e++)
                    {
                        x = 752;
                        y = 344 + (52 * e);
                        MakePlatforms(Properties.Resources.Wood, "breakable");
                    }
                    for (int e = 0; e < 6; e++)
                    {
                        if (e >= 0 && e <= 2)
                        {
                            x = 700 + (52 * e);
                            y = 240 - 52;
                            MakePlatforms(Properties.Resources.Leaves, "breakable");
                        }
                        if(e == 4)
                        {
                            for(int g = 0;g < 5;g++)
                            {
                                x = 648 + (52 * g);
                                y = 292 - 52;
                                MakePlatforms(Properties.Resources.Leaves, "breakable");
                            }
                        }
                        if (e == 5)
                        {
                            for (int g = 0; g < 5; g++)
                            {
                                x = 648 + (52 * g);
                                y = 344 - 52;
                                MakePlatforms(Properties.Resources.Leaves, "breakable");
                            }
                        }
                    }
                    x = 348;
                    y = 404;
                    MakePlatforms(Properties.Resources.Leaves, "breakable");
                    // Tree //

                    // Inventory //
                    x = 406;
                    y = 596;
                    MakeItem(Properties.Resources.Diamond_Sword_Right, Color.DimGray, 48, 48);
                    x = x + 60;
                    MakeItem(Properties.Resources.Diamond_Pickaxe_Right, Color.DimGray, 48, 48);
                    x = x + 60;
                    MakeItem(Properties.Resources.Diamond_Axe_Right, Color.DimGray, 48, 48);
                    // Inventory //
                    pickaxe.SendToBack();
                    player.SendToBack();
                    foreach (Control i in this.Controls) if (i is PictureBox && i.Tag == "item") i.BringToFront();

                    break;
            }
        }
        private void MakePlatforms(Image material, string tag)
        {
            PictureBox block = new PictureBox();
            block.Tag = tag;
            block.BackColor = Color.Transparent;
            block.Height = 52;
            block.Width = 52;
            block.Image = material;
            block.SizeMode = PictureBoxSizeMode.Zoom;
            block.Location = new Point(x, y);
            block.BringToFront();

            this.Controls.Add(block);
        }
        private void MakeItem(Image material, Color color, int x1, int y1)
        {
            PictureBox item = new PictureBox();
            item.Tag = "item";
            item.BackColor = color;
            item.Height = x1;
            item.Width = y1;
            item.Image = material;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.Location = new Point(x, y);
            item.BringToFront();

            this.Controls.Add(item);
        }
        private void Barrier()
        {
            if (player.Location.X < 1) player.Location = new Point(player.Location.X + 10, player.Location.Y);
            if (player.Location.X > 940) player.Location = new Point(player.Location.X - 10, player.Location.Y);
            if (player.Location.Y < 5) player.Location = new Point(player.Location.X, player.Location.Y + 10);
            if (player.Location.Y > 585) player.Location = new Point(player.Location.X, player.Location.Y - 10);
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
    }
}
