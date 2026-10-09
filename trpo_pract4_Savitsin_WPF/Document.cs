using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace trpo_pract4_Savitsin_WPF
{
    class Document : INotifyPropertyChanged
    {
        private int id = 0;
        private string name = "Название документа";
        private int countPage = 0;
        private int countCopies = 0;
        private int pricePage = 0;
        public int Id 
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public int CountPage
        {
            get => countPage;
            set
            {
                if (countPage != value)
                {
                    countPage = value;
                    OnPropertyChanged();
                }
            }
        }
        public int CountCopies
        {
            get => countCopies;
            set
            {
                if (countCopies != value)
                {
                    countCopies = value;
                    OnPropertyChanged();
                }
            }
        }
        public int PricePage
        {
            get => pricePage;
            set
            {
                if (pricePage != value)
                {
                    pricePage = value;
                    OnPropertyChanged();
                }
            }
        }

        private double pricePrint = 0;
        public double PricePrint
        {
            get => pricePrint;
            set
            {
                if (pricePage != value)
                {
                    pricePrint = CountPage * PricePage * CountCopies;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
