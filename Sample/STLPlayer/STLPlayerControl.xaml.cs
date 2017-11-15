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

using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;


namespace WpfApplication1.Controls.STLViewer
{
    /// <summary>
    /// Interaction logic for STLPlayerControl.xaml
    /// </summary>
    public partial class STLPlayer : UserControl
    {
        MainViewModel m_mainViewModel;
        public STLPlayer()
        {
            InitializeComponent();
            m_mainViewModel = new MainViewModel(new FileDialogService(), view1);
            this.DataContext = m_mainViewModel;
            view1.SetView(new Point3D(200, 160, 800), new Vector3D(00, 0, -800), new Vector3D(0, 1, 0), 5);
            view1.ZoomExtents(500);


        }
        public void ReloadFile(String strPath)
        {
            m_mainViewModel.ReloadFile(strPath);
            view1.Title = strPath;

        }

        private void OnViewportMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point3D offset = view1.CursorPosition.Value;

            view1.Camera.LookAt(offset, 5);

        }



    }



}
