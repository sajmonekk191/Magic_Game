using System.Drawing;

namespace test_RPG.Essentials.GameObjectsGame2
{
    class Colliders
    {
        public static Rectangle PlayerColliderStand(Player p)
        {
            return new Rectangle(p.Left + 11, p.Top + 71, p.Width - 20, p.Height - 50);
        }
        public static Rectangle PlayerCollider(Player p)
        {
            return new Rectangle(p.Left + 19, p.Top, p.Width - 28, p.Height);
        }
        public static Rectangle BlockColliderStand(Rectangle o)
        {
            return new Rectangle(o.X, o.Y, o.Width, o.Height - 51);
        }
        public static Rectangle BlockColliderLeft(Rectangle o)
        {
            return new Rectangle(o.X, o.Y + 10, o.Width - 20, o.Height - 10);
        }
        public static Rectangle BlockColliderRight(Rectangle o)
        {
            return new Rectangle(o.X + 10, o.Y + 10, o.Width, o.Height - 10);
        }
        public static Rectangle BlockColliderDown(Rectangle o)
        {
            return new Rectangle(o.X + 10, o.Y + 21, o.Width - 10, o.Height - 10);
        }
        public static Rectangle ToolCollider(Rectangle o)
        {
            return new Rectangle(o.X + 13, o.Y + 13, o.Width - 13, o.Height - 1);
        }
        public static Rectangle MouseCollider(int x, int y)
        {
            Rectangle rect = new Rectangle(x, y, 10, 10);
            return new Rectangle(rect.X + 13, rect.Y + 13, rect.Width - 13, rect.Height - 1);
        }
        public static Rectangle RangeCalculator(int x, int y)
        {
            Rectangle rect = new Rectangle(x, y, 100, 100);
            return new Rectangle(rect.X - 50, rect.Y - 50, rect.Width + 50, rect.Height + 50);
        }
    }
}
