using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace test_RPG.Essentials
{
    class Imports
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        public static bool isUpPressed()
        {
            short key = GetAsyncKeyState(Keys.W);
            short key1 = GetAsyncKeyState(Keys.Up);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else if (((key1 >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isUpReleased()
        {
            short key = GetAsyncKeyState(Keys.W);
            short key1 = GetAsyncKeyState(Keys.Up);
            if (((key >> 15) & 0x0001) == 0x0000) return true;
            else if (((key1 >> 15) & 0x0001) == 0x0000) return true;
            else return false;
        }
        public static bool isDownPressed()
        {
            short key = GetAsyncKeyState(Keys.S);
            short key1 = GetAsyncKeyState(Keys.Down);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else if (((key1 >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isLeftPressed()
        {
            short key = GetAsyncKeyState(Keys.A);
            short key1 = GetAsyncKeyState(Keys.Left);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else if (((key1 >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isRightPressed()
        {
            short key = GetAsyncKeyState(Keys.D);
            short key1 = GetAsyncKeyState(Keys.Right);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else if (((key1 >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isAttackPressed()
        {
            short key = GetAsyncKeyState(Keys.LButton);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isinventoryindex1()
        {
            short key = GetAsyncKeyState(Keys.D1);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isinventoryindex2()
        {
            short key = GetAsyncKeyState(Keys.D2);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isinventoryindex3()
        {
            short key = GetAsyncKeyState(Keys.D3);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
    }
}
