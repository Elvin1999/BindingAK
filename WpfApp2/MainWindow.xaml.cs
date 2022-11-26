using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //public Car Car { get; set; }


        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }

        

        public MainWindow()
        {
            InitializeComponent();
            Fullname = "Hello World";

            Car = new Car
            {
                Model = "Q7",
                Vendor = "Audi",
                Engine = 3.5
            };


            Cars = new ObservableCollection<Car>
            {
                new Car
            {
                Model = "Q7",
                Vendor = "Audi",
                Engine = 3.5
            },
            new Car
            {
                Model = "E-200",
                Vendor = "Mercedes",
                Engine = 2
            }
            };

            this.DataContext = this;
        }
        //public string Fullname { get; set; }

        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["mainColor"] = this.Resources["mainColor2"];
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Fullname = "Clicked";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Car = new Car
            //{
            //    Engine = 2,
            //    Vendor = "Mercedes",
            //    Model = "E-200"
            //};
            Car.Model = "Q8";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Car.Model);
            //Cars.Add(new Car
            //{
            //    Model = "La Ferrari",
            //    Vendor = "Ferrari",
            //    Engine = 6
            //});

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Car=Car;
            infoWindow.Show();
        }
    }
}
