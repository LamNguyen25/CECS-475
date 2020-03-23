// Lam Nguyen
// Lab Assignment 3: Problem 2
// Event Publisher
using System;
using System.Threading;

namespace stockEvent {
    public class Stock {
        // Create event object
        public event EventHandler<StockNotification> stockEvent;

        private String _name;
        private int _intialValue;
        private int _maxChange;
        private int _notificationThreshold;
        private int _currentValue;
        private int _numberChanges;
        private DateTime _dateTime;

        // Stock Constructor: assign values for all data members
        public Stock(String name, int startingValue, int maxChange, int threshold) {
            _name = name;
            _intialValue = startingValue;
            _currentValue = _intialValue;
            _maxChange = maxChange;
            _notificationThreshold = threshold;
            _dateTime = DateTime.Now;


            //Create a thread
            Thread thread = new Thread(Activate);
            thread.Start();
        }

        // Method to activate the thread and call ChangeStockValue method
        public void Activate() {
            for(int i = 0; i < 15; i++) {
                Thread.Sleep(500);
                ChangeStockValue();
            }
        }

        // Invokes the stockEvent (of event-type StockNotification)
        public void ChangeStockValue() {
            Random rand = new Random();
            int num = rand.Next(0, _maxChange);
            _currentValue += num;
            _numberChanges++;

            if((Math.Abs(_currentValue - _intialValue))> _notificationThreshold) {
                stockEvent?.Invoke(this, new StockNotification(_name, _currentValue, _numberChanges, _dateTime));
            }

        }

    }

    public class StockNotification : EventArgs {
        // Stores information for the event
        public StockNotification(String stockName, int currentValue, int numberChanges, DateTime dateTime) {
            StockName = stockName;
            CurrentValue = currentValue;
            NumberChanges = numberChanges;
            DateAndTime = dateTime;
        }
        // Get stockName
        public String StockName { get; }
        // Get currentValue
        public int CurrentValue { get; }
        // Get numberChanges
        public int NumberChanges { get; }
        // Get dateAndTime
        public DateTime DateAndTime { get;  }
    }


}
