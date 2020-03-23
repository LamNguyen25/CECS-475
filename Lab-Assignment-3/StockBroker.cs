// Lam Nguyen
// Lab Assignment 3: Problem 2
// Event subscriber
using System;
using System.Collections.Generic;
using System.IO;

namespace stockEvent {
    public class StockBroker {
        private String _brokerName;
        protected List<Stock> stocks;
        private static object locker = new Object();
        /// <summary>
        /// StockBroker constructor
        /// </summary>
        /// <param name="name"> name of the stock broker </param>
        public StockBroker(String name) {
            stocks = new List<Stock>();
            _brokerName = name;
        }

        /// <summary>
        /// registers the Notify listerner with the stock
        /// (in addition to adding it to the list of stocks held by the broker)
        /// </summary>
        /// <param name="stock"> stock object </param>
        public void AddStock(Stock stock) {
            stocks.Add(stock);
            stock.stockEvent += EventHandler;
            stock.stockEvent += WriteToFile;
            
        }

        /// <summary>
        /// Outputs to the console the name, value, and the number of changes of the stock
        /// whose value is out of the range given the stock's notification threshold
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventHandler(object sender, StockNotification e) {
            Console.WriteLine($"{_brokerName.PadRight(10)} {e.StockName.ToString().PadRight(10)} {e.CurrentValue.ToString().PadRight(10)} {e.NumberChanges.ToString().PadRight(10)} {e.DateAndTime.ToString()}");
        }

        // Print the output to a text file
        public void WriteToFile(object sender, StockNotification e) {
            try {
                //Wait for the resource to be free
                lock (locker) {
                    // Set a variable to the Documents path.
                    string docPath = "/Users/lamnguyen/Desktop/CSULB/Semesters/Spring-2020/CECS-475/Assignments/A-3/A(3)-Part2";

                    using (FileStream file = new FileStream(Path.Combine(docPath, "output.txt"), FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (StreamWriter writer = new StreamWriter(file)) {
                        writer.WriteLine(_brokerName.PadRight(10) + e.StockName.PadRight(20) + e.CurrentValue.ToString().PadRight(15) + e.NumberChanges.ToString().PadRight(10) + e.DateAndTime.ToString());
                    }
                }
            }
            catch (IOException) { }
        }
    }

}
