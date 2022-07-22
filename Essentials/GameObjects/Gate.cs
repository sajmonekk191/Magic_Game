using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjects
{
    class Gate : PictureBox
    {
        Form1 game;
        public Gate(Form1 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.DodgerBlue;
            this.Size = new Size(52, 52);
            this.Left = 540;
            this.Top = 580;
            this.Tag = "gate";
            this.Visible = false;
            this.Image = Properties.Resources.Gate;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
            this.BringToFront();
        }
    }
}
