using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjects
{
    class Player : PictureBox
    {
        Game1 game;
        public Player(Game1 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(72, 72);
            this.Left = 540;
            this.Top = 580;
            this.Tag = "player";
            this.Visible = true;
            this.Image = Properties.Resources.Player_up;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
            this.BringToFront();
        }
    }
}
