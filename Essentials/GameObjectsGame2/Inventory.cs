using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjectsGame2
{
    class Inventory : PictureBox
    {
        Game2 game;
        public Inventory(Game2 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(560, 63);
            this.Left = game.Width / 2 - 100;
            this.Top = 590;
            this.Tag = "inventory";
            this.Visible = true;
            this.Image = Properties.Resources.Toolbar;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
        }
    }

    class Hotbar
    {
        Game2 game;
        public int grasscount;
        public int dirtcount;
        public int stonecount;
        public int woodcount;
        public int leavescount;
        public bool grassStacked = false;
        public bool dirtStacked = false;
        public bool stoneStacked = false;
        public bool woodStacked = false;
        public bool leavesStacked = false;
        public Hotbar(Game2 Game)
        {
            game = Game;
        }

        bool[] SlotFull = new bool[8];

        public Point[] SlotPosition = new Point[8];
        public string[] SlotName = new string[8];
        public void makeslotfull()
        {
            for (int i = 0; i < 8; i++)
            {
                SlotPosition[i] = new Point(685 + (i * 62), 1026);
            }
        }
        public void SpawnItem(Image res, int x, int y)
        {
            PictureBox item = new PictureBox();
            item.BackColor = Color.FromArgb(60, 62, 34);
            item.Size = new Size(50, 50);
            item.Left = x;
            item.Top = y;
            item.Tag = "item";
            item.Visible = true;
            item.Image = res;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(item);
        }
        public void ApplyFirstEmptySlot(Image res, string item)
        {
            for (int i = 0; i < 8; i++)
            {
                bool value = SlotFull[i];
                if (!value)
                {
                    SpawnItem(res, SlotPosition[i].X, SlotPosition[i].Y);
                    SlotName[i] = item;
                    SlotFull[i] = true;
                    return;
                }
            }
        }
    }
}
