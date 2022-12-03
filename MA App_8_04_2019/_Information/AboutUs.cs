using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LMA.Data.UI.ViewModels.ViewModels;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace LeaveMeAlone
{
    public partial class AboutUs : UserControl
    {
        private DeleteUserAccountConfirmation_ deleteForm;
        public static AboutUs aboutUs = null;

        private ImageFormat format = null;

        public AboutUs()
        {
            InitializeComponent();
            aboutUs = this;
            
        }

      
    }
}
