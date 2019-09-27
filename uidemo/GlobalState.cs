using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace uidemo
{
    public class GlobalState : INotifyPropertyChanged
    {
        public static GlobalState Instance { get; } = new GlobalState();

        bool darkMode;
        public bool DarkMode
        {
            get => darkMode;
            set
            {
                darkMode = value;
                FirePropertyChanged();

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri($"/uidemo;component/Styles/{(darkMode ? "Dark" : "Light")}StyleResources.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/uidemo;component/Styles/CommonStyleResources.xaml", UriKind.RelativeOrAbsolute) });
            }
        }

        private void FirePropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
