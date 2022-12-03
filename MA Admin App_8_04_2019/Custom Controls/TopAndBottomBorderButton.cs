using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    class TopAndBottomBorderButton : Button
    {
        protected override void OnStyleChanged(EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         FlatAppearance.BorderColor, 2, ButtonBorderStyle.Solid,
                                         FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         FlatAppearance.BorderColor, 2, ButtonBorderStyle.Solid);
        }
    }
}
