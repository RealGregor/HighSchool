using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    class MyCheckBox : CheckBox{
            protected override bool ShowFocusCues
            {
                get { return true; }/*false if you want it without cues*/
            }
    }
}
