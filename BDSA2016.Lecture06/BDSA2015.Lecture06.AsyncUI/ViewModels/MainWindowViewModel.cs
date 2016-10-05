using BDSA2016.Lecture06.AsyncUI.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDSA2016.Lecture06.AsyncUI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private double _dkk;

        public double DKK
        {
            get { return _dkk; }
            set { _dkk = value; OnPropertyChanged(); }
        }

        private double _usd;

        public double USD
        {
            get { return _usd; }
            set { _usd = value; OnPropertyChanged(); }
        }

        private double _gbp;

        public double GBP
        {
            get { return _gbp; }
            set { _gbp = value; OnPropertyChanged(); }
        }

        private double _eur;

        public double EUR
        {
            get { return _eur; }
            set { _eur = value; OnPropertyChanged(); }
        }

        public ICommand Calculate => new RelayCommand(CalculateRates);

        private void CalculateRates(object o)
        {
            var amount = DKK;

            USD = GetRate("DKK", "USD") * DKK;
            GBP = GetRate("DKK", "GBP") * DKK;
            EUR = GetRate("DKK", "EUR") * DKK;
        }

        private double GetRate(string from, string to)
        {
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            using (var client = new WebClient())
            {
                var url = $"http://currency-api.appspot.com/api/{from}/{to}.json";

                var data = client.DownloadString(url);
                var json = JsonConvert.DeserializeObject<ExchangeRate>(data);

                return json.Rate;
            }
        }
    }
}
