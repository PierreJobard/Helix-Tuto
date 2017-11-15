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


namespace SampleSample.GridPlayer
{
    /// <summary>
    /// Interaction logic for STLPlayerControl.xaml
    /// </summary>
    public partial class GridPlayer : UserControl
    {
        MainViewModel m_mainViewModel;
        public GridPlayer()
        {
            InitializeComponent();
            m_mainViewModel = new MainViewModel(new FileDialogService(), view1);
            this.DataContext = m_mainViewModel;
            

            //default Camera position
            //view1.SetView(Point3D newPosition, Vector3D newDirection, Vector3D newUpDirection, double animationTime);
            //OK view1.SetView(new Point3D(200, 160, 100), new Vector3D(00, 0, -100), new Vector3D(0, 1, 0), 5);
            view1.SetView(new Point3D(200, 160, 800), new Vector3D(00, 0, -800), new Vector3D(0, 1, 0), 5);
            view1.ZoomExtents(500);
            


        }
        public void ReloadFile(String strPath)
        {
            m_mainViewModel.ReloadFile(strPath);
            
        }

        public void LoadFilesList(List<string> listFiles)
        {
/*

            foreach (String strPath in listFiles)
            {
                m_mainViewModel.ReloadFile(strPath);
            }


*/

            //test refresh view + vite
            //m_mainViewModel.CurrentModel = null;

            //nok root1.Content = null;
            
            

            foreach (String strPath in listFiles)
            {
                m_mainViewModel.ReloadFile(strPath);
            }

            //nok root1.Content = m_mainViewModel.CurrentModel;
            

        }




        private void AddCubeCommand(object sender, RoutedEventArgs e)
        {
            //AddCube();
            //m_mainViewModel.CurrentModel.Freeze();
        }

        private void AddCube()
        {
            SphereVisual3D sphere = new SphereVisual3D();
            sphere.Radius = 0.5;
            sphere.Center = new Point3D(0, 0, 0);
            sphere.Fill = Brushes.Red;
            //this.m_mainViewModel.viewport.Viewport.Children.Add(sphere);


            CubeVisual3D cube = new CubeVisual3D();
            cube.SideLength = 0.5;
            sphere.Center = new Point3D(1, 0, 0);
            sphere.Fill = Brushes.Azure;
            // this.m_mainViewModel.viewport.Viewport.Children.Add(cube);

/*
            UITranslator.Bind(root1);
            Rect3D box = m_mainViewModel.currentModel.Bounds;
            Point3D offset = new Point3D(box.X, box.Y, box.Z);
            UITranslator.Position = offset;

            view1.Camera.LookAt(offset, 5);
*/


        }




        private void OnViewportMouseDown(object sender, MouseButtonEventArgs e)
        {

            Point3D offset = view1.CursorPosition.Value;
            view1.LookAt(offset, 5);

        }

        private void ClearViewCommand(object sender, RoutedEventArgs e)
        {
            m_mainViewModel.CurrentModel = null;
        }

    }



}
