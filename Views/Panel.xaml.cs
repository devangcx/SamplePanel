using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SamplePanel.Views
{
    /// <summary>
    /// Interaction logic for Panel.xaml
    /// </summary>
    [Guid("5ec87085-9407-4509-9f31-b0fceea2bacc")]
    public partial class Panel : Page
    {
        public static Guid Guid => typeof(Panel).GUID;

        public Panel()
        {
            InitializeComponent();
        }
    }
}
