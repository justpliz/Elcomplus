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
using System.Net;
using System.Xml;
using System.IO;

namespace XML_Tree_Visualisation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
     
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            fileLocation = Directory.GetCurrentDirectory() + "\\XmlFilename.xml";
        }
        private string fileLocation;

        private void OpenURL_Click(object sender, RoutedEventArgs e)
        {
            FileWindow OpenURLWindow = new FileWindow();
            if (OpenURLWindow.ShowDialog() == true)
            {
                if (XMLDownload(OpenURLWindow.EnteredURL) != true)
                {
                    MessageBox.Show("Ошибка скачивания файла");
                }
            }
            else
                return;

            XmlDataProvider provider = new XmlDataProvider();
            provider.Source = new Uri(fileLocation, UriKind.Absolute);
            provider.XPath = "./*";

            trvItems.DataContext = provider;
        }

        public bool XMLDownload(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(url, fileLocation);
                    return true;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
