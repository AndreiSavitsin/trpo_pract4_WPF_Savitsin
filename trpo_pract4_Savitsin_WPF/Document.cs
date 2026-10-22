using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace trpo_pract4_Savitsin_WPF
{
    class Document : INotifyPropertyChanged
    {
        Random rnd = new Random();

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
                    OnPropertyChanged(nameof(PricePrint));
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
                    OnPropertyChanged(nameof(PricePrint));
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
                    OnPropertyChanged(nameof(PricePrint));
                }
            }
        }
        
        public double PricePrint
        {
            get => CountPage * PricePage * CountCopies;    
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void GenerateNewId()
        {
            do
            {
                Id = rnd.Next(1, 100000);
            }
            while (File.Exists(Id + ".json"));
        }
    }
}
