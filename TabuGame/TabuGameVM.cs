using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace TabuGame
{
    public class TabuGameVM:INotifyPropertyChanged
    {
        System.Timers.Timer recordTimer = new System.Timers.Timer(1000);
        public TabuGameVM(int numberOfGroups, int numberOfCards, int numberOfExchanges)
        {
            recordTimer.Elapsed += RecordTimer_Elapsed;
            numberOfCardsInTheStack = numberOfCards;
            ListOfGroups = new List<Group>();
            for (int i = 0; i < numberOfGroups; i++)
            {
                ListOfGroups.Add(new Group(i + 1));
            }
        }

        private void RecordTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (numberOfSecondStays > 0)
            {
                numberOfSecondStays--;
                NotifyPropertyChanged("NumberOfSecondsStays");
            }
            else
            {
                recordTimer.Stop();
            }
        }
        private int numberOfSecondStays;

        public string NumberOfSecondsStays
        {
            get { return numberOfSecondStays.ToString(); }
        }

        internal void StartTimer()
        {
            numberOfSecondStays = 60;
            recordTimer.Start();
        }

        private int numberOfCardsInTheStack;

        public string CardsStay
        {
            get { return numberOfCardsInTheStack.ToString(); }
        }

        public List<Group> ListOfGroups { get; set; }

        internal void CardDecrease()
        {
            numberOfCardsInTheStack--;
            NotifyPropertyChanged("CardsStay");
        }

        private void NotifyPropertyChanged(string pProperty)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(pProperty));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Group: INotifyPropertyChanged
    {
        public Group(int number)
        {
            numberOfCards = 0;
            GroupTitle = "קבוצה " + number.ToString();
            //GetNewCardCommand = new RelayCommand(() => { numberOfCards++; });
        }
        public string GroupTitle { get; set; }
        private int numberOfCards;

        public ICommand GetNewCardCommand { get; set; }
        public string NumberOfCards
        {
            get { return numberOfCards.ToString(); }
            
        }

        internal void AddCard()
        {
            numberOfCards++;
            NotifyPropertyChanged("NumberOfCards");
        }
        private void NotifyPropertyChanged(string pProperty)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(pProperty));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
