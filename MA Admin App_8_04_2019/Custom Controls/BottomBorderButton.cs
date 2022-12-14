using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    class BottomBorderButton : Button
    {
        protected override void OnStyleChanged(EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         FlatAppearance.BorderColor, 4, ButtonBorderStyle.Solid);
        }
    }
}
