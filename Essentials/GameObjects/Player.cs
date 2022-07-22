using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjects
{
    class Player : PictureBox
    {
        Form1 game;
        public Player(Form1 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.DodgerBlue;
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
