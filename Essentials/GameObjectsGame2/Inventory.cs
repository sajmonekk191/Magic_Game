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
            this.Size = new Size(180, 60);
            this.Left = game.Width / 2 - 100;
            this.Top = 590;
            this.Tag = "inventory";
            this.Visible = true;
            this.Image = Properties.Resources.Inventory;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
        }
    }
}
