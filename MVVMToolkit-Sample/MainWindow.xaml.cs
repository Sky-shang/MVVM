using MVVMToolkit_Sample.Common;
using MVVMToolkit_Sample.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMToolkit_Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //注册跳转
            WindowHelper.ShowPageHome = () =>
            {
                frame.Navigate(new PageHome());
            };

            //跳转至登录页
            frame.Navigate(new PageLogin());
        }
    }
}
