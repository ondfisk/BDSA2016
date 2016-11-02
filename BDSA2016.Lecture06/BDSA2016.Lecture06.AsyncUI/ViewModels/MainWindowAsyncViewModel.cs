using BDSA2016.Lecture06.AsyncUI.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDSA2016.Lecture06.AsyncUI.ViewModels
{
    public class MainWindowAsyncViewModel : BaseViewModel
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

        public RelayCommand Calculate => new RelayCommand(CalculateRatesInParallelAsync);

        private async void CalculateRatesAsync(object o)
        {
            USD = await GetRateAsync("DKK", "USD") * DKK;
            GBP = await GetRateAsync("DKK", "GBP") * DKK;
            EUR = await GetRateAsync("DKK", "EUR") * DKK;
        }

        private async Task<double> GetRateAsync(string from, string to)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            using (var client = new WebClient())
            {
                var url = $"http://currency-api.appspot.com/api/{from}/{to}.json";

                var data = await client.DownloadStringTaskAsync(url);
                var json = JsonConvert.DeserializeObject<ExchangeRate>(data);

                return json.Rate;
            }
        }

        private async void CalculateRatesInParallelAsync(object o)
        {
            await Task.Run(() => 
                Parallel.Invoke(
                    async () => USD = await GetRateAsync("DKK", "USD") * DKK,
                    async () => GBP = await GetRateAsync("DKK", "GBP") * DKK,
                    async () => EUR = await GetRateAsync("DKK", "EUR") * DKK
                )
            );
        }
    }
}
