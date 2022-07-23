using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjectsGame2
{
    class Player : PictureBox
    {
        Game2 game;
        public Player(Game2 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(42, 72);
            this.Left = 540;
            this.Top = 580;
            this.Tag = "player";
            this.Visible = true;
            this.Image = Properties.Resources.Steve;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
            this.BringToFront();
        }
    }
}
