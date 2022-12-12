using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws_api_csharp
{
    public class ContractType
    {
        public static Contract EurGbpFx()
        {
            //! [cashcontract]
            Contract contract = new Contract();
            contract.Symbol = "EUR";
            contract.SecType = "CASH";
            contract.Currency = "GBP";
            contract.Exchange = "IDEALPRO";
            //! [cashcontract]
            return contract;
        }

        public static Contract Euthereum()
        {
            //! [cashcontract]
            Contract contract = new Contract();
            contract.Symbol = "ETH";
            contract.SecType = "CRYPTO";
            contract.Exchange = "PAXOS";
            contract.Currency = "USD";
            contract.LocalSymbol = "ETH.USD";
            contract.ConId = 495759171;
            //contract.conId = 495759171;
            //! [cashcontract]
            return contract;
        }

        public static Contract Bitcoin()
        {
            //! [cashcontract]
            Contract contract = new Contract();
            contract.Symbol = "BTC";
            contract.SecType = "CRYPTO";
            contract.Exchange = "PAXOS";
            contract.Currency = "USD";
            contract.LocalSymbol = "BTC.USD";
            contract.ConId = 479624278;
            //contract.conId = 479624278

            //! [cashcontract]
            return contract;
        }

        public static Contract EuropeanStock()
        {
            Contract contract = new Contract();
            contract.Symbol = "NOKIA";
            contract.SecType = "STK";
            contract.Currency = "EUR";
            contract.Exchange = "SMART";
            contract.PrimaryExch = "HEX";
            return contract;
        }

        public static Contract Amazon()
        {
            Contract contract = new Contract();
            contract.Symbol = "USD";
            contract.SecType = "CASH";
            contract.Currency = "CHF";
            contract.Exchange = "IDEALPRO";
            return contract;
        }

        /*
         * Using the contract's own symbol (localSymbol) can greatly simplify a contract description
         */
        public static Contract MutualFund()
        {
            //! [fundcontract]
            Contract contract = new Contract();
            contract.Symbol = "VINIX";
            contract.SecType = "FUND";
            contract.Exchange = "FUNDSERV";
            contract.Currency = "USD";
            //! [fundcontract]
            return contract;
        }

        public static Contract Index()
        {
            //! [indcontract]
            Contract contract = new Contract();
            contract.Symbol = "DAX";
            contract.SecType = "IND";
            contract.Currency = "EUR";
            contract.Exchange = "EUREX";
            //! [indcontract]
            return contract;
        }

        public static Contract GBPUSD()
        {
            //! [cfdcontract]
            Contract contract = new Contract();
            contract.Symbol = "GBP";
            contract.SecType = "CASH";
            contract.Currency = "USD";
            contract.Exchange = "IDEALPRO";
            //! [cfdcontract]
            return contract;
        }

        public static Contract GBPEUR()
        {
            //! [cfdcontract]
            Contract contract = new Contract();
            contract.Symbol = "GBP";
            contract.SecType = "CASH";
            contract.Currency = "EUR";
            contract.Exchange = "IDEALPRO";
            //! [cfdcontract]
            return contract;
        }

        public static Contract CFD()
        {
            //! [cfdcontract]
            Contract contract = new Contract();
            contract.Symbol = "IBDE30";
            contract.SecType = "CFD";
            contract.Currency = "EUR";
            contract.Exchange = "SMART";
            //! [cfdcontract]
            return contract;
        }

        public static Contract USStockCFD()
        {
            //! [usstockcfd]
            Contract contract = new Contract();
            contract.Symbol = "IBM";
            contract.SecType = "CFD";
            contract.Currency = "USD";
            contract.Exchange = "SMART";
            //! [usstockcfd]
            return contract;
        }

        public static Contract EuropeanStockCFD()
        {
            //! [europeanstockcfd]
            Contract contract = new Contract();
            contract.Symbol = "BMW";
            contract.SecType = "CFD";
            contract.Currency = "EUR";
            contract.Exchange = "SMART";
            //! [europeanstockcfd]
            return contract;
        }

        public static Contract AAPL()
        {
            Contract contract = new Contract();
            contract.Symbol = "AAPL";
            contract.Currency = "USD";
            contract.Exchange = "SMART";
            contract.SecType = "STK";
            return contract;
        }

        public static Contract GOOGL()
        {
            Contract contract = new Contract();
            contract.Symbol = "GOOGL";
            contract.Currency = "USD";
            contract.Exchange = "SMART";
            contract.SecType = "STK";
            return contract;
        }

        public static Contract USStock()
        {
            //! [stkcontract]
            Contract contract = new Contract();
            contract.Symbol = "SPY";
            contract.SecType = "STK";
            contract.Currency = "USD";
            contract.Exchange = "ARCA";
            //! [stkcontract]
            return contract;
        }

        public static Contract SwissBonds()
        {
            //! [stkcontract]
            Contract contract = new Contract();
            contract.Symbol = "CONF";
            contract.SecType = "IND";
            contract.Currency = "CHF";
            contract.Exchange = "EUREX";
            //! [stkcontract]
            return contract;
        }

    }
}
