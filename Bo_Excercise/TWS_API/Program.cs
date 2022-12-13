using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
// Use the Interactive Brokers "IBApi" 
// Make sure add the reference to the CSharpAPI.dll in the Project
using IBApi;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Samples;
using tws_api_csharp;

namespace IB_Real_Time_Console_CS
{
    class Program
    {
        static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }
            return array;
        }

        public static Samples.ContractClasses[] contractArray = InitializeArray<ContractClasses>(200);
        
        static void Main(string[] args)
        {
            Console.WriteLine("This is C#");
            // Create the ibClient object to represent the connection
            Samples.EWrapperImpl testImpl = new Samples.EWrapperImpl();

            EClientSocket clientSocket = testImpl.ClientSocket;
            EReaderSignal readerSignal = testImpl.Signal;
            // Connect to the IB Server through TWS. Parameters are:
            // host       - Host name or IP address of the host running TWS
            // port       - The port TWS listens through for connections
            // clientId   - The identifier of the client application
            clientSocket.eConnect("127.0.0.1", 7497, 0);

            // For IB TWS API version 9.72 and higher, implement this
            // signal-handling code. Otherwise just comment this code out.
            var reader = new EReader(clientSocket, readerSignal);
            reader.Start();
            new Thread(() => { 
                while (clientSocket.IsConnected()) { 
                    readerSignal.waitForSignal(); reader.processMsgs(); 
                } 
            }) { IsBackground = true }.Start();

            // Pause here until the connection is complete
            while (testImpl.NextOrderId <= 0) { }
            // Kick off the request for market data for this
            // contract.  reqMktData Parameters are:
            // tickerId         - A unique id to represent this request
            // contract         - The contract object specifying the financial instrument
            // genericTickList  - A string representing special tick values
            // snapshot         - When true obtains only the latest price tick
            //                    When false, obtains data in a stream
            // regulatory snapshot - API 9.72 or higher. set to false
            // mktDataOptions   - For TWS API 9.71 and up, this is required as the last parameter
            //! [reqmktdata_snapshot]


            startNewRequest(tws_api_csharp.ContractType.EurGbpFx(), 1, clientSocket, testImpl, 1);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.Amazon(), 100, clientSocket, testImpl, 2);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.GBPUSD(), 200, clientSocket, testImpl, 3);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.GBPEUR(), 300, clientSocket, testImpl, 4);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.AAPL(), 400, clientSocket, testImpl, 5);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.GOOGL(), 500, clientSocket, testImpl, 6);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.USStock(), 600, clientSocket, testImpl, 7);
            Thread.Sleep(1000);
            startNewRequest(tws_api_csharp.ContractType.AAPL(), 700, clientSocket, testImpl, 8);
            //startNewRequest(tws_api_csharp.ContractType.Bitcoin(), 33, clientSocket, testImpl, 9);
            //startNewRequest(tws_api_csharp.ContractType.Bitcoin(), 1, clientSocket, testImpl, 1);


            // Disconnect from TWS
            clientSocket.eDisconnect();
            printClassesArray(8);
        }

        private static void startNewRequest(IBApi.Contract contract, int reqId, EClientSocket clientSocket, Samples.EWrapperImpl testImpl, int id)
        {
            String queryTime = DateTime.Now.ToUniversalTime().AddMonths(-6).ToString("yyyyMMdd-HH:mm:ss");

            clientSocket.reqContractDetails(reqId, contract);
            Thread.Sleep(100);
            clientSocket.reqMarketDepth(reqId + 1, contract, 5, false, null);
            Thread.Sleep(100);
            clientSocket.reqHistoricalData(reqId + 2, contract, queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, false, null);
            Thread.Sleep(100);
            clientSocket.reqMktData(reqId + 3, contract, "295", false, false, null);
            Thread.Sleep(100);
            saveArray(testImpl.contractArray, id);
            clientSocket.cancelMktData(reqId);
            clientSocket.cancelMktDepth(reqId + 1);
            clientSocket.cancelHistoricalData(reqId + 2);
            clientSocket.cancelMktData(reqId + 3);

        }

        private static void saveArray(ContractClasses classesToSave, int reqId)
        {
            contractArray[reqId].ConId = classesToSave.ConId;
            contractArray[reqId].Volume = classesToSave.Volume;
            contractArray[reqId].Price = classesToSave.Price;
            contractArray[reqId].CurrentPrice = classesToSave.CurrentPrice;
            contractArray[reqId].WAP = classesToSave.WAP;
            contractArray[reqId].LowPrice = classesToSave.LowPrice;
            contractArray[reqId].HighPrice = classesToSave.HighPrice;
            contractArray[reqId].BarCount = classesToSave.BarCount;
            contractArray[reqId].Ticker = classesToSave.Ticker;
        }

        private static void printClassesArray(int lastReqId)
        {
            string path = "../Result.txt";
            File.WriteAllText(path, String.Empty);
            for (int i = 1; i <= lastReqId; i++)
            {
                Console.WriteLine("______________________________");
                Console.WriteLine("Checking Id: " + i);
                Console.WriteLine("Ticker: " + contractArray[i].Ticker);
                Console.WriteLine("ConId: " + contractArray[i].ConId);
                Console.WriteLine("Current Price: " + contractArray[i].CurrentPrice);
                Console.WriteLine("Price: " + contractArray[i].Price);
                Console.WriteLine("Bar Count: " + contractArray[i].BarCount);
                Console.WriteLine("HighPrice: " + contractArray[i].HighPrice);
                Console.WriteLine("LowPrice: " + contractArray[i].LowPrice);
                Console.WriteLine("Volume: " + contractArray[i].Volume);
                Console.WriteLine("WAP: " + contractArray[i].WAP);
                File.AppendAllText(path, "______________________________" + Environment.NewLine);
                File.AppendAllText(path, "Checking Id: " + i + Environment.NewLine);
                File.AppendAllText(path, "Ticker: " + contractArray[i].Ticker + Environment.NewLine);
                File.AppendAllText(path, "ConId: " + contractArray[i].ConId + Environment.NewLine);
                File.AppendAllText(path, "Current Price: " + contractArray[i].CurrentPrice + Environment.NewLine);
                File.AppendAllText(path, "Bar Count: " + contractArray[i].BarCount + Environment.NewLine);
                File.AppendAllText(path, "Price: " + contractArray[i].Price + Environment.NewLine);
                File.AppendAllText(path, "HighPrice: " + contractArray[i].HighPrice + Environment.NewLine);
                File.AppendAllText(path, "LowPrice: " + contractArray[i].LowPrice + Environment.NewLine);
                File.AppendAllText(path, "Volume: " + contractArray[i].Volume + Environment.NewLine);
                File.AppendAllText(path, "WAP: " + contractArray[i].WAP + Environment.NewLine);
            }
        }
    } // end class Program
} // end namespace IB_Real_Time_Console_CS
