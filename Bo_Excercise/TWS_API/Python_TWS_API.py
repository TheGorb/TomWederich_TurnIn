from cgi import test
from inspect import getattr_static
from ibapi.client import *
from ibapi.wrapper import *
from ibapi.tag_value import *
from ibapi.contract import *
from ibapi.ticktype import TickTypeEnum

import threading
from contractSamples import *
from time import sleep
import datetime

 
port = 7497
 
globalArray = []

for i in range (200):
    globalArray.append(contractInformations());
globalArray[0].price = 100;

clientId = 1001
indexArray = 0;
currentReqId = 0;

# This is the IBAPI primary EClient and EWrapper class
class TestApp(EClient, EWrapper):
    def __init__(self):
        EClient.__init__(self, self)
 
    def nextValidId(self, orderId: int):
        self.nextOrderId = orderId

    def tickByTickBidAsk(self, reqId: int, time: int, bidPrice: float, askPrice: float,
                         bidSize: Decimal, askSize: Decimal, tickAttribBidAsk: TickAttribBidAsk):
        print("tick by tick ask: ", reqId, time, bidPrice, "askPrice: ", askPrice, bidSize, askSize);
        globalArray[reqId].currentPrice = bidPrice;
        globalArray[reqId].price = round(askPrice, 5) - round(bidPrice, 5);
        globalArray[reqId].price = round(globalArray[reqId].price, 4);

    # Returned market data
    def tickPrice(self, reqId: TickerId, tickType: TickType, price: float, attrib: TickAttrib):
        global globalArray
        print(f"tickPrice. reqId: {reqId}, tickType: {TickTypeEnum.to_str(tickType)}, price: {price}, attribs: {attrib}")

    # End of all market data request
    def tickSnapshotEnd(self, reqId: int):
        if reqId == 49:
            # After my last request, disconnect from socket.
            self.disconnect()

    def contractDetails(self, reqId: int, contractDetails: ContractDetails):
        global globalArray
        print("Contract details : ", reqId, contractDetails);
        globalArray[reqId].conId = contractDetails.contract.conId
        globalArray[reqId].ticker = contractDetails.contract.symbol
    # Returned Hisotircal Data
    def tickPrice(self, tickerId: int, field: int, price: float, attribs: TickAttrib):
        print ("tickePrice: ", tickerId, price);

    def historicalData(self, reqId: int, bar: BarData):
        global globalArray

        print("Historical Data", reqId, bar)
        globalArray[reqId].price = bar.close
        globalArray[reqId].WAP = bar.wap
        globalArray[reqId].volume = bar.volume
        globalArray[reqId].highPrice = bar.high
        globalArray[reqId].lowPrice = bar.low
        globalArray[reqId].barCount = bar.barCount
        if (globalArray[reqId].currentPrice == 0.0):
            globalArray[reqId].currentPrice = bar.close
     
    # End of All Hisotrical Data
    def historicalDataEnd(self, reqId: int, start: str, end: str):
        print("data End", reqId, start, end);
 
    # Show order placed
    def openOrder(self, orderId: OrderId, contract: Contract, order: Order, orderState: OrderState):
        print(orderId, contract, order, orderState)
 
    def stop(self):
        self.done = True
        self.disconnect()
         
def run_loop(app_obj: TestApp):
    print("Run_Loop")
    app_obj.run()
 
# This is an introduction to start using threads and combining requests with one another
class startInvesting():
 
    def newCashContratRequest(app, currentContract):
        global currentReqId
        global indexArray

        app.reqMktDepth(currentReqId, currentContract, 1, False, []);
        queryTime = (datetime.datetime.today() - datetime.timedelta(days=180)).strftime("%Y%m%d-%H:%M:%S")
        app.reqMarketDataType(4);
        app.reqMktData(currentReqId, currentContract, "", 0, 0, []);
        app.reqTickByTickData(currentReqId, currentContract, "BidAsk", 1, True);
        app.reqHistoricalData(currentReqId, currentContract, queryTime, "1 D", "4 hours", "MIDPOINT", 1, 1,  False, []);
        app.reqContractDetails(currentReqId, currentContract);
        
        app.cancelMktData(currentReqId);
        currentReqId += 1;
        return;

    @staticmethod
    def newContractRequest(app, currentContract):
        global currentReqId
        global indexArray

        app.reqMktDepth(currentReqId, currentContract, 1, False, []);
        queryTime = (datetime.datetime.today() - datetime.timedelta(days=180)).strftime("%Y%m%d-%H:%M:%S")
        app.reqMarketDataType(4);
        app.reqMktData(currentReqId, currentContract, "100", True, 0, []);
        app.reqTickByTickData(currentReqId, currentContract, "AllLast", 1, True);
        app.reqHistoricalData(currentReqId, currentContract, queryTime, "1 D", "4 hours", "TRADES", 1, 1,  False, []);
        app.reqContractDetails(currentReqId, currentContract);
        
        app.cancelMktData(currentReqId);
        currentReqId += 1;
        return;

    # Create the market scanner
    def buildScanner():
        global clientId
        global indexArray

        app = TestApp()
        app.connect("127.0.0.1", port, clientId)
 
        contract = contractSamples()
        sleep(1)

        #startInvesting.newContractRequest(app, contract.Tesla())

        publicMethodNames = [method for method in dir(contract) if callable(getattr(contract, method)) if not method.startswith('_')]  # 'private' methods start from _
        for method in publicMethodNames:
            try:
                if (getattr(contract, method)().secType == "CASH"):
                    startInvesting.newCashContratRequest(app, getattr(contract, method)());
                else:
                    startInvesting.newContractRequest(app, getattr(contract, method)());
            except TypeError:
                pass

        threading.Timer(4, app.stop).start()
        app.run();
        return

    # Print Scanner Results
    def printScanner():
        global globalArray
        global indexArray
        global currentReqId

        open('result.txt', 'w').close()
        with open('result.txt', 'w') as file:
            file.writelines("#Form: {ConId; Ticker; Price; Bar Count; Volume; High Price; Low Price; Current Price; WAP}\n\n");
            for i in range(currentReqId):
                file.writelines("{" + str(globalArray[i].conId) + ";");
                file.writelines(str(globalArray[i].ticker) + ";");
                file.writelines(str(globalArray[i].price) + ";");
                file.writelines(str(globalArray[i].barCount) + ";");
                file.writelines(str(globalArray[i].volume) + ";");
                file.writelines(str(globalArray[i].highPrice) + ";");
                file.writelines(str(globalArray[i].lowPrice) + ";");
                file.writelines(str(globalArray[i].currentPrice) + ";");
                file.writelines(str(globalArray[i].WAP) + "}\n");
                print("____________________________");
                print("conId:", globalArray[i].conId);
                print("ticker:", globalArray[i].ticker);
                print("price:", globalArray[i].price);
                print("barCount:", globalArray[i].barCount);
                print("volume:", globalArray[i].volume);
                print("highPrice:", globalArray[i].highPrice);
                print("lowPrice:", globalArray[i].lowPrice);
                print("currentPrice:", globalArray[i].currentPrice);
                print("WAP:", globalArray[i].WAP);
        return
 
def main():
     
    startInvesting.buildScanner()
 
    startInvesting.printScanner()
     
    #startInvesting.buildHistorical()
     
    #startInvesting.calcChange()
     
    #startInvesting.printTopDif()
 
    #startInvesting.bestBuys()
 
 
if __name__ == "__main__":
    main()