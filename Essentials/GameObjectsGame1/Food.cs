using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjects
{
    class Food : PictureBox
    {
        Game1 game;
        public Food(Game1 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(32, 32);
            this.Left = 540;
            this.Top = 580;
            this.Tag = "food";
            this.Visible = true;
            this.Image = Properties.Resources.Food;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
            this.BringToFront();
        }
    }
}
