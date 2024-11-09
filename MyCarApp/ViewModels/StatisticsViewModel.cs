using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace MyCarApp.ViewModels
{
    public class StatisticsViewModel
    {
        public ObservableCollection<StatisticItem> DetailedStatistics { get; set; }

        public StatisticsViewModel()
        {
            // Voorbeelddata, vervang dit door echte statistische gegevens
            DetailedStatistics = new ObservableCollection<StatisticItem>
            {
                new StatisticItem { StatisticName = "Totale Verkoop", StatisticValue = "€200,000" },
                new StatisticItem { StatisticName = "Gemiddelde Verkoopprijs", StatisticValue = "€20,000" },
                new StatisticItem { StatisticName = "Aantal Bezoeken", StatisticValue = "1200" }
            };
        }
    }

    public class StatisticItem
    {
        public string StatisticName { get; set; }
        public string StatisticValue { get; set; }
    }
}

