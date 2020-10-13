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


namespace XML_Tree_Visualisation
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class FileWindow : Window
    {
        public FileWindow()
        {
            InitializeComponent();
        }


        private void openURLButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(URLBox.Text))
            {
                MessageBox.Show("Введите URL");
                return;
            }
            EnteredURL = URLBox.Text;
            this.DialogResult = true;
        }

        public string EnteredURL { set; get; }


    }
}
