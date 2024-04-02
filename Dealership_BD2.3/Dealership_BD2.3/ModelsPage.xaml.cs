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

namespace Dealership_BD2._3
{
    /// <summary>
    /// Логика взаимодействия для ModelsPage.xaml
    /// </summary>
    public partial class ModelsPage : Page
    {
        private DealershipEntities context = new DealershipEntities();
        public ModelsPage()
        {
            InitializeComponent();
            modelsDgr.ItemsSource = context.Models.ToList();
            Cbx.ItemsSource = context.Models.ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            modelsDgr.ItemsSource = context.Models.ToList().Where(item => item.ModelName.Contains(text_search.Text));
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            modelsDgr.ItemsSource = context.Models.ToList();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var selected = Cbx.SelectedItem as Models;
                modelsDgr.ItemsSource = context.Models.ToList().Where(item => item.ModelName == selected.ModelName);
            }
        }
    }
}