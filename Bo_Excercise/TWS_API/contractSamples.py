from ibapi.contract import *
from ibapi.client import *
from ibapi.wrapper import *

class contractInformations:
    conId: 0
    price: 0.0
    barCount: 0
    volume: 0.0
    highPrice: 0.0
    lowPrice: 0.0
    currentPrice: 0.0
    bid: 0.0
    ask: 0.0
    WAP: 0.0
    VWAP: 0.0

    def __init__(self):
        self.conId = 0
        self.ticker = ""
        self.price = 0.0
        self.barCount = 0
        self.volume = 0.0
        self.highPrice = 0.0
        self.lowPrice = 0.0
        self.currentPrice = 0.0
        self.bid = 0.0
        self.ask = 0.0
        self.WAP = 0.0
        self.VWAP = 0.0

class contractSamples:

    def EurGbpFx(self):
        contract = Contract();
        contract.symbol = "EUR";
        contract.secType = "CASH";
        contract.currency = "GBP";
        contract.exchange = "IDEALPRO";
        return contract;

    def Euthereum(self):
        contract = Contract();
        contract.symbol = "ETH";
        contract.exchange = "PAXOS";
        contract.conId = 495759171;
        return contract;

    def Bitcoin(self):
        contract = Contract();
        contract.symbol = "BTC";
        contract.exchange = "PAXOS";
        contract.conId = 479624278;
        return contract;

    def Amazon(self):
        contract = Contract();
        contract.symbol = "AMZ";
        contract.secType = "STK";
        contract.currency = "EUR";
        contract.exchange = "SMART";
        return contract;
    
    def USDCHEF(self):
        contract = Contract();
        contract.symbol = "USD";
        contract.secType = "CASH";
        contract.currency = "CHF";
        contract.exchange = "IDEALPRO";
        return contract;

    def GBPUSD(self):
        contract = Contract();
        contract.symbol = "GBP";
        contract.secType = "CASH";
        contract.currency = "USD";
        contract.exchange = "IDEALPRO";
        return contract;

    def Tesla(self):
        contract = Contract();
        contract.symbol = "TSLA";
        contract.secType = "STK";
        contract.currency = "USD";
        contract.exchange = "SMART";
        return contract;

    def EuropeanStock(self):
        contract = Contract();
        contract.symbol = "BMW";
        contract.secType = "STK";
        contract.currency = "EUR";
        contract.exchange = "SMART";
        contract.PrimaryExch = "IBIS";
        return contract;

    def AAPL(self):
        contract = Contract();
        contract.symbol = "AAPL";
        contract.currency = "USD";
        contract.exchange = "SMART";
        contract.secType = "STK";
        return contract;

    def GOOGL(self):
        contract = Contract();
        contract.symbol = "GOOGL";
        contract.currency = "USD";
        contract.exchange = "SMART";
        contract.secType = "STK";
        return contract;