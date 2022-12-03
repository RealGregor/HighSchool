using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    class MyRoundedEdgeButton1 : System.Windows.Forms.Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddEllipse(0,0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(GraphPath);
            base.OnPaint(e);
        }
        //private const uint WM_MOUSEACTIVATE = 0x21;
        //protected override void WndProc(ref Message m)
        //{

        //    // WM_MOUSEACTIVATE = 0x21
        //    if (m.Msg == WM_MOUSEACTIVATE && this.CanFocus && !this.Focused)
        //        this.Focus();
        //    base.WndProc(ref m);
        //}
    }
}
