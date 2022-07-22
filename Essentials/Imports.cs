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
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isDownPressed()
        {
            short key = GetAsyncKeyState(Keys.S);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isLeftPressed()
        {
            short key = GetAsyncKeyState(Keys.A);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
        public static bool isRightPressed()
        {
            short key = GetAsyncKeyState(Keys.D);
            if (((key >> 15) & 0x0001) == 0x0001) return true;
            else return false;
        }
    }
}
