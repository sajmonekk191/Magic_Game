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
        public static int inventoryindex()
        {
            short key1 = GetAsyncKeyState(Keys.D1);
            short key2 = GetAsyncKeyState(Keys.D2);
            short key3 = GetAsyncKeyState(Keys.D3);
            short key4 = GetAsyncKeyState(Keys.D4);
            short key5 = GetAsyncKeyState(Keys.D5);
            short key6 = GetAsyncKeyState(Keys.D6);
            short key7 = GetAsyncKeyState(Keys.D7);
            short key8 = GetAsyncKeyState(Keys.D8);
            short key9 = GetAsyncKeyState(Keys.D9);
            if (((key1 >> 15) & 0x0001) == 0x0001) return 0;
            if (((key2 >> 15) & 0x0001) == 0x0001) return 1;
            if (((key3 >> 15) & 0x0001) == 0x0001) return 2;
            if (((key4 >> 15) & 0x0001) == 0x0001) return 3;
            if (((key5 >> 15) & 0x0001) == 0x0001) return 4;
            if (((key6 >> 15) & 0x0001) == 0x0001) return 5;
            if (((key7 >> 15) & 0x0001) == 0x0001) return 6;
            if (((key8 >> 15) & 0x0001) == 0x0001) return 7;
            if (((key9 >> 15) & 0x0001) == 0x0001) return 8;
            else return 9;
        }
    }
}
