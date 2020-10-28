using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
using WpfApp1.Model;
using WpfApp1.ViewsModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Debitorer> people = new ObservableCollection<Debitorer>();
       
        public static Debitorer[] employee;
        public MainWindow()
        {
            InitializeComponent();
            Main();

            
            DataGridXAML.IsReadOnly = true;
        }

        private void RedViewClicked(object sender, RoutedEventArgs e)
        {
            people.Add(new Debitorer { DebitonerID = 11,
                DebitonerName= "test" });
        }

    static readonly HttpClient client = new HttpClient();

    public  async Task Main()
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:44393/Debitoner");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                 employee = JsonConvert.DeserializeObject<Debitorer[]>(responseBody);
                var sorted = employee.OrderBy(c => c.DebitonerName);
                people = new ObservableCollection<Debitorer>(sorted);
                //if (employee != null)
                //    DataGridXAML.ItemsSource = people;
                //DataContext = people;


            }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }

        private void DataGridXAML_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Debitorer test = (Debitorer)DataGridXAML.SelectedItem;
                if (test != null && test.DebitonerID > 0)
                {
                    RedViewModel.selecetItemId = test.DebitonerID;
                    DataContext = new RedViewModel();
                }
            }
            catch (Exception ex)
            {
            }
           

        }
    }

}
