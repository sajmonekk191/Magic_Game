using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjectsGame2
{
    class Grass_Block
    {
        Game2 game;
        public Grass_Block(Game2 Game)
        {
            game = Game;
        }
        public void Spawn(int x, int y, int width, int height, string tag)
        {
            PictureBox item = new PictureBox();
            item.Name = "Grass";
            item.BackColor = Color.Transparent;
            item.Size = new Size(width, height);
            item.Left = x;
            item.Top = y;
            item.Tag = tag;
            item.Visible = true;
            item.Image = Properties.Resources.Grass_Block;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(item);
        }
    }
    class Dirt_Block
    {
        Game2 game;
        public Dirt_Block(Game2 Game)
        {
            game = Game;
        }
        public void Spawn(int x, int y, int width, int height, string tag)
        {
            PictureBox item = new PictureBox();
            item.Name = "Dirt";
            item.BackColor = Color.Transparent;
            item.Size = new Size(width, height);
            item.Left = x;
            item.Top = y;
            item.Tag = tag;
            item.Visible = true;
            item.Image = Properties.Resources.Dirt_Block;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(item);
        }
    }
    class Stone
    {
        Game2 game;
        public Stone(Game2 Game)
        {
            game = Game;
        }
        public void Spawn(int x, int y, int width, int height, string tag)
        {
            PictureBox item = new PictureBox();
            item.Name = "Stone";
            item.BackColor = Color.Transparent;
            item.Size = new Size(width, height);
            item.Left = x;
            item.Top = y;
            item.Tag = tag;
            item.Visible = true;
            item.Image = Properties.Resources.Stone;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(item);
        }
    }
    class Wood
    {
        Game2 game;
        public Wood(Game2 Game)
        {
            game = Game;
        }
        public void Spawn(int x, int y, int width, int height, string tag)
        {
            PictureBox item = new PictureBox();
            item.Name = "Wood";
            item.BackColor = Color.Transparent;
            item.Size = new Size(width, height);
            item.Left = x;
            item.Top = y;
            item.Tag = tag;
            item.Visible = true;
            item.Image = Properties.Resources.Wood;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(item);
        }
    }
    class Leaves
    {
        Game2 game;
        public Leaves(Game2 Game)
        {
            game = Game;
        }
        public void Spawn(int x, int y, int width, int height, string tag)
        {
            PictureBox item = new PictureBox();
            item.Name = "Leaves";
            item.BackColor = Color.Transparent;
            item.Size = new Size(width, height);
            item.Left = x;
            item.Top = y;
            item.Tag = tag;
            item.Visible = true;
            item.Image = Properties.Resources.Leaves;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(item);
        }
    }
}
