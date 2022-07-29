// block counter - Easy
// map generator - Hard
// ore generator - Very Hard
using System;
using System.Drawing;
using System.Windows.Forms;
using test_RPG.Essentials;
using test_RPG.Essentials.GameObjectsGame2;
using test_RPG.Properties;
using static test_RPG.Essentials.GameObjectsGame2.Colliders;

namespace test_RPG
{
    public partial class Game2 : Form
    {
        Random rand = new Random();
        Player player;
        Pickaxe pickaxe;
        Inventory inventory; 
        Hotbar hotbar;
        Grass_Block grassblock;
        Dirt_Block dirtblock;
        Stone stone;
        Wood wood;
        Leaves leaves;
        private System.Windows.Forms.Timer GameTimer = new System.Windows.Forms.Timer();
        private int speed = 5;
        private int gravity = 10;
        private int FPS = 2;
        private int jumpintensity;
        private bool jump;
        public static int score = 0;
        public Game2()
        {
            InitializeComponent();
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            player = new Player(this); // optional argument spawn
            pickaxe = new Pickaxe(this);
            inventory = new Inventory(this);
            hotbar = new Hotbar(this);
            grassblock = new Grass_Block(this);
            dirtblock = new Dirt_Block(this);
            stone = new Stone(this);
            wood = new Wood(this);
            leaves = new Leaves(this);
            hotbar.makeslotfull();
            player.Spawn();
            pickaxe.Spawn();
            inventory.Spawn();
            player.BringToFront();
            pickaxe.BringToFront();
            player.Location = new Point(19, 428);
            pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            inventory.Location = new Point(680, 1020);
            GameTimer.Enabled = true;
            GameTimer.Interval = FPS;
            GameTimer.Tick += new EventHandler(Updater);
            this.Cursor = new Cursor("Crosshair.cur");
            RenderLevel(Values.level);
            counterlbl.Visible = true;
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
                jumpintensity--;
            }
            else gravity = 10;
            if (Imports.isLeftPressed())
            {
                Values.isleft = true;
                player.Left -= speed;
                InventorySelector(hotbar.SlotName[Values.inventoryindex], Values.isleft);
                pickaxe.Location = new Point(player.Location.X - 28, player.Location.Y + 12);
            }
            if (Imports.isRightPressed())
            {
                Values.isleft = false;
                player.Left += speed;
                InventorySelector(hotbar.SlotName[Values.inventoryindex], Values.isleft);
                pickaxe.Location = new Point(player.Location.X + 38, player.Location.Y + 12);
            }
            int value = Imports.inventoryindex();
            if (value != 9)
            {
                Values.inventoryindex = value;
                InventorySelector(hotbar.SlotName[Values.inventoryindex], Values.isleft);
                counterlbl.Text = hotbar.SlotName[Values.inventoryindex];
            }
            foreach (Control i in this.Controls)
            {
                if (i is PictureBox && i.Tag == "block")
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
                        if (i.Name.Contains("Grass") && hotbar.SlotName[Values.inventoryindex] == "Shovel") grassblock.Spawn(i.Location.X + 10, i.Location.Y + 30, 25, 25, "drop");
                        else if (i.Name.Contains("Dirt") && hotbar.SlotName[Values.inventoryindex] == "Shovel") dirtblock.Spawn(i.Location.X + 10, i.Location.Y + 30, 25, 25, "drop");
                        else if (i.Name.Contains("Stone") && hotbar.SlotName[Values.inventoryindex] == "Pickaxe") stone.Spawn(i.Location.X + 10, i.Location.Y + 30, 25, 25, "drop");
                        else if (i.Name.Contains("Wood") && hotbar.SlotName[Values.inventoryindex] == "Axe") wood.Spawn(i.Location.X + 10, i.Location.Y + 30, 25, 25, "drop");
                        else if (i.Name.Contains("Leaves")) leaves.Spawn(i.Location.X + 10, i.Location.Y + 30, 25, 25, "drop");
                        else return;
                        i.Dispose();
                    }
                    pickaxe.Location = new Point(pickaxe.Location.X, player.Location.Y + 12);
                }
                if (i is PictureBox && i.Tag == "drop")
                {
                    if (PlayerCollider(player).IntersectsWith(i.Bounds))
                    {
                        if (i.Name.Contains("Grass"))
                        {
                            hotbar.grasscount++;
                            if (!hotbar.grassStacked)
                            {
                                hotbar.grassStacked = true;
                                hotbar.ApplyFirstEmptySlot(Resources.Grass_Block, "Grass_Block");
                            }
                            foreach (Control g in this.Controls) if (g is PictureBox && g.Tag == "item") g.BringToFront();
                        }
                        else if (i.Name.Contains("Dirt"))
                        {
                            hotbar.dirtcount++;
                            if (!hotbar.dirtStacked)
                            {
                                hotbar.dirtStacked = true;
                                hotbar.ApplyFirstEmptySlot(Resources.Dirt_Block, "Dirt_Block");
                            }
                            foreach (Control g in this.Controls) if (g is PictureBox && g.Tag == "item") g.BringToFront();
                        }
                        else if (i.Name.Contains("Stone"))
                        {
                            hotbar.stonecount++;
                            if (!hotbar.stoneStacked)
                            {
                                hotbar.stoneStacked = true;
                                hotbar.ApplyFirstEmptySlot(Resources.Stone, "Stone");
                            }
                            foreach (Control g in this.Controls) if (g is PictureBox && g.Tag == "item") g.BringToFront();
                        }
                        else if (i.Name.Contains("Wood"))
                        {
                            hotbar.woodcount++;
                            if (!hotbar.woodStacked)
                            {
                                hotbar.woodStacked = true;
                                hotbar.ApplyFirstEmptySlot(Resources.Wood, "Wood");
                            }
                            foreach (Control g in this.Controls) if (g is PictureBox && g.Tag == "item") g.BringToFront();
                        }
                        else if (i.Name.Contains("Leaves"))
                        {
                            hotbar.leavescount++;
                            if (!hotbar.leavesStacked)
                            {
                                hotbar.leavesStacked = true;
                                hotbar.ApplyFirstEmptySlot(Resources.Leaves, "Leaves");
                            }
                            foreach (Control g in this.Controls) if (g is PictureBox && g.Tag == "item") g.BringToFront();
                        }
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
                    int x;
                    int y;
                    // Ground //
                    for (int g = 0; g < 37; g++)
                    {
                        x = 52 * g;
                        y = 760;
                        grassblock.Spawn(x, y, 52, 52, "block");
                    }
                    for (int d = 0; d < 37; d++)
                    {
                        x = 52 * d;
                        y = 812;
                        dirtblock.Spawn(x, y, 52, 52, "block");
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 864;
                        dirtblock.Spawn(x, y, 52 ,52, "block");
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 916;
                        stone.Spawn(x, y, 52, 52, "block");
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 968;
                        stone.Spawn(x, y, 52, 52, "block");
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 1020;
                        stone.Spawn(x, y, 52, 52, "block");
                    }
                    for (int e = 0; e < 37; e++)
                    {
                        x = 52 * e;
                        y = 1072;
                        stone.Spawn(x, y, 52 ,52, "block");
                    }
                    // Ground //

                    // Tree //
                    SpawnTree(700, 608);
                    SpawnTree(1200, 608);
                    SpawnTree(1500, 608);
                    // Tree //

                    // Inventory //
                    hotbar.ApplyFirstEmptySlot(Resources.Diamond_Sword_Left, "Sword");
                    hotbar.ApplyFirstEmptySlot(Resources.Diamond_Pickaxe_Left, "Pickaxe");
                    hotbar.ApplyFirstEmptySlot(Resources.Diamond_Axe_Left, "Axe");
                    hotbar.ApplyFirstEmptySlot(Resources.Diamond_Shovel_Left, "Shovel");
                    // Inventory //
                    pickaxe.SendToBack();
                    player.SendToBack();
                    foreach (Control i in this.Controls) if (i is PictureBox && i.Tag == "hotbar") i.BringToFront();
                    foreach (Control i in this.Controls) if (i is PictureBox && i.Tag == "item") i.BringToFront();
                    break;
            }
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
                case "Sword":
                    if (isleft) pickaxe.Image = Resources.Diamond_Sword_Left;
                    else pickaxe.Image = Resources.Diamond_Sword_Right;
                    break;
                case "Pickaxe":
                    if (isleft) pickaxe.Image = Resources.Diamond_Pickaxe_Left;
                    else pickaxe.Image = Resources.Diamond_Pickaxe_Right;
                    break;
                case "Axe":
                    if (isleft) pickaxe.Image = Resources.Diamond_Axe_Left;
                    else pickaxe.Image = Resources.Diamond_Axe_Right;
                    break;
                case "Grass_Block":
                    if (isleft) pickaxe.Image = Resources.Grass_Block;
                    else pickaxe.Image = Resources.Grass_Block;
                    break;
                case "Dirt_Block":
                    if (isleft) pickaxe.Image = Resources.Dirt_Block;
                    else pickaxe.Image = Resources.Dirt_Block;
                    break;
                case "Stone":
                    if (isleft) pickaxe.Image = Resources.Stone;
                    else pickaxe.Image = Resources.Stone;
                    break;
                case "Wood":
                    if (isleft) pickaxe.Image = Resources.Wood;
                    else pickaxe.Image = Resources.Wood;
                    break;
                case "Leaves":
                    if (isleft) pickaxe.Image = Resources.Leaves;
                    else pickaxe.Image = Resources.Leaves;
                    break;
                case "Shovel":
                    if (isleft) pickaxe.Image = Resources.Diamond_Shovel_Left;
                    else pickaxe.Image = Resources.Diamond_Shovel_Right;
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
                wood.Spawn(x1, y1, 52, 52, "block");
            }
            x1 = x1 - 2 * ofset;
            y1 = y1 - 5 * ofset;
            for (int e = 0; e < 6; e++)
            {
                if (e >= 0 && e <= 2)
                {
                    x1 = x1 + 52;
                    leaves.Spawn(x1, y1, 52, 52, "block");
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
                        leaves.Spawn(x1, y1, 52, 52, "block");
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
                        leaves.Spawn(x1, y1, 52, 52, "block");
                    }
                }
            }
        }
    }
}
