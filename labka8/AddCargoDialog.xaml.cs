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
using Model;

namespace labka8
{
    /// <summary>
    /// Interaction logic for AddCargoDialog.xaml
    /// </summary>
    public partial class AddCargoDialog : Window
    {
        public AddCargoDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddCargoDialog(Cargo updCargo):this()
        {
            labelTitle.Content = "Cargo ID";
            labelID.Content = updCargo.CargoID.ToString();
            this.CargoType = updCargo.CargoType;
            this.Destination = updCargo.Destination;
            this.Weight = updCargo.Weight;
        }

        public string CargoType
        {
            get { return (string)GetValue(CargoTypeProperty); }
            set { SetValue(CargoTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CargoType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CargoTypeProperty =
            DependencyProperty.Register("CargoType", typeof(string), typeof(AddCargoDialog), new PropertyMetadata(""));



        public string Destination
        {
            get { return (string)GetValue(DestinationProperty); }
            set { SetValue(DestinationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Destination.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DestinationProperty =
            DependencyProperty.Register("Destination", typeof(string), typeof(AddCargoDialog), new PropertyMetadata(""));



        public float Weight
        {
            get { return (float)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Weight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(float), typeof(AddCargoDialog), new PropertyMetadata((float)0));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
