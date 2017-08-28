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
    /// Interaction logic for AddAirplaneDialog.xaml
    /// </summary>
    public partial class AddAirplaneDialog : Window
    {


        public string ModelName
        {
            get { return (string)GetValue(ModelNameProperty); }
            set { SetValue(ModelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ModelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelNameProperty =
            DependencyProperty.Register("ModelName", typeof(string), typeof(AddAirplaneDialog), new PropertyMetadata(""));



        public int MaxPassengers
        {
            get { return (int)GetValue(MaxPassengersProperty); }
            set { SetValue(MaxPassengersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxPassengers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxPassengersProperty =
            DependencyProperty.Register("MaxPassengers", typeof(int), typeof(AddAirplaneDialog), new PropertyMetadata(0));



        public float MaxCargo
        {
            get { return (float)GetValue(MaxCargoProperty); }
            set { SetValue(MaxCargoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxCargo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxCargoProperty =
            DependencyProperty.Register("MaxCargo", typeof(float), typeof(AddAirplaneDialog), new PropertyMetadata((float)0));



        public float FuelTank
        {
            get { return (float)GetValue(FuelTankProperty); }
            set { SetValue(FuelTankProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FuelTank.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FuelTankProperty =
            DependencyProperty.Register("FuelTank", typeof(float), typeof(AddAirplaneDialog), new PropertyMetadata((float)0));



        public AddAirplaneDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddAirplaneDialog(Airplane updateAirplane):this()
        {
            
            labelTitle.Content = "ID самолета";
            LabelID.Content = updateAirplane.AirplaneID;
            this.ModelName = updateAirplane.ModelName;
            this.MaxCargo = updateAirplane.MaxCargo;
            this.MaxPassengers = updateAirplane.MaxPassengers;
            this.FuelTank = updateAirplane.FuelTank;
        }

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
