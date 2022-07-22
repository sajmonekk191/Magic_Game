using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjects
{
    class Food : PictureBox
    {
        Form1 game;
        public Food(Form1 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.DodgerBlue;
            this.Size = new Size(32, 32);
            this.Left = 540;
            this.Top = 580;
            this.Tag = "food";
            this.Visible = false;
            this.Image = Properties.Resources.Food;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
            this.BringToFront();
        }
    }
}
