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
using System.IO;

namespace ElementsControlList
{
    public partial class MainWindow : Window
    {
        class City
        {
            public string Name { get; set; }
            public int Pop { get; set; }
            public int Reg { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        City[] punct = new City[10];
        private void winload(object sender, RoutedEventArgs e)
        {
            string path = @"Sitys\";

            for (int i = 0; i < 10; i++)
            {
                using (var sr = new StreamReader(path + i + ".txt"))
                {
                    punct[i] = new City();
                    punct[i].Name = sr.ReadLine();
                    punct[i].Pop = Convert.ToInt32(sr.ReadLine());
                    punct[i].Reg = Convert.ToInt32(sr.ReadLine());
                    comBox.Items.Add(punct[i]);
                }
            }

        }

        private void itemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (comBox.SelectedIndex != -1)
            {
            list.Items.Clear();
            list.Items.Add(punct[comBox.SelectedIndex].Name + " " + punct[comBox.SelectedIndex].Pop + " " + punct[comBox.SelectedIndex].Reg);
                deleteButton.IsEnabled = true;
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Array.Resize(ref punct, punct.Length + 1);
            punct[punct.Length - 1] = new City();
            int length = punct.Length;
            punct[length - 1].Name = newNameOfCity.Text;
            punct[punct.Length - 1].Pop = Convert.ToInt32(newPopukation.Text);
            punct[punct.Length - 1].Reg = Convert.ToInt32(newRegion.Text);
            _ = comBox.Items.Add(punct[punct.Length - 1]);
            newNameOfCity.Text = newPopukation.Text = newRegion.Text = "";
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            List<City> temp = punct.ToList();
            temp.RemoveAt(comBox.SelectedIndex);
            punct = temp.ToArray();
            comBox.Items.RemoveAt(comBox.SelectedIndex);
            list.Items.Clear();
            deleteButton.IsEnabled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработал Аюпов Евгений");

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
            
            if( messageBoxResult == MessageBoxResult.Yes)
            {
                
            }
        }
    }
}
