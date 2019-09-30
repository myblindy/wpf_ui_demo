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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uidemo.Models;

namespace uidemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ScaleTransform ScaleTransform = new ScaleTransform();
        readonly TranslateTransform TranslateTransform = new TranslateTransform();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowModel();

            var tg = new TransformGroup();
            tg.Children.Add(ScaleTransform);
            tg.Children.Add(TranslateTransform);
            MainFrame.RenderTransform = tg;
            MainFrame.RenderTransformOrigin = new Point(.5, .5);
        }

        private async void ActionBarItem_Checked(object sender, RoutedEventArgs e)
        {
            if (MainFrame.HasContent)
            {
                var duration = TimeSpan.FromSeconds(.3);
                ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(.8, duration) { EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut } });
                ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(.8, duration) { EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut } });
                await Task.Delay(duration);

                duration = TimeSpan.FromSeconds(.2);
                TranslateTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(-ActualWidth, duration) { EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn } });
                await Task.Delay(duration);
            }

            MainFrame.Navigate(new Uri($"/Pages/{((MainWindowActionBarItem)((FrameworkElement)sender).DataContext).PageName}.xaml", UriKind.Relative));
        }

        private async void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var duration = TimeSpan.FromSeconds(.2);
            TranslateTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(ActualWidth * 2, 0, duration) { EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut } });
            await Task.Delay(duration);

            duration = TimeSpan.FromSeconds(.3);
            ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(1, duration));
            ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(1, duration));
        }
    }
}
