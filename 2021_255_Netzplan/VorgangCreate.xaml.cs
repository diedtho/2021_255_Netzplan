using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace _2021_255_Netzplan
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class VorgangCreate : Window
    {

        public VorgangCreate()
        {
            InitializeComponent();
        }


        void btnClickVorgangSpeichern(object sender, RoutedEventArgs e)
        {         
            Close();
        }
    }
}
