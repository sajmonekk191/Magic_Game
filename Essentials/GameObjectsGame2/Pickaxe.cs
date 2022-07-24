using System.Drawing;
using System.Windows.Forms;

namespace test_RPG.Essentials.GameObjectsGame2
{
    class Pickaxe : PictureBox
    {
        Game2 game;
        public Pickaxe(Game2 Game)
        {
            game = Game;
        }
        public void Spawn()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(32, 32);
            this.Left = 540;
            this.Top = 580;
            this.Tag = "pickaxe";
            this.Visible = true;
            this.Image = Properties.Resources.Diamond_Pickaxe_Right;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            game.Controls.Add(this);
        }
    }
}
