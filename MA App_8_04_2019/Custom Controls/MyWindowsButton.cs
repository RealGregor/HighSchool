using System.Windows.Forms;

namespace LeaveMeAlone
{
    class MyWindowsButton : Button
    {
        //============ DONT KNOW IF I WANT THIS THIS YET ==============
        private const uint WM_MOUSEACTIVATE = 0x21;
        protected override void WndProc(ref Message m)
        {
            // WM_MOUSEACTIVATE = 0x21
            if (m.Msg == WM_MOUSEACTIVATE && this.CanFocus && !this.Focused)
            {
                this.Focus();
                this.Focus();
            }
            base.WndProc(ref m);
        }
    }
}
