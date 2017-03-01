using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DivisasMVVM.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        #region Attributes
        private decimal pesos;
        private decimal dollars;
        private decimal euros;
        private decimal pounds;

        
        #endregion


        #region Properties
        public decimal Pesos { get; set; }
        public decimal Dollars
        {
            set
            {
                if(dollars != value)
                {
                    dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }
            }
            get
            {
                return dollars;
            }
        }
        public decimal Euros
        {
            set
            {
                if (euros != value)
                {
                    euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
            }
            get
            {
                return euros;
            }
        }
        public decimal Pounds
        {
            set
            {
                if (pounds != value)
                {
                    pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }
            }
            get
            {
                return pounds;
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion

        #region Commands
        public ICommand ConvertCommand { get { return new RelayCommand(ConvertMoney); } }

        private async void ConvertMoney()
        {
            if (Pesos <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un valor mayor a cero en pesos.", "Aceptar");
                return;
            }

            Dollars = Pesos / 19.8172846M;
            Euros = Pesos / 20.9002992M;
            Pounds = Pesos / 24.3594063M;
        }
        #endregion



    }
}
