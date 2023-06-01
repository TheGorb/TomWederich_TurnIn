# TWS API Python Program

This repository contains a Python program that utilizes the TWS API (Trader Workstation API) for trading purposes. The program connects to the Interactive Brokers Trader Workstation (TWS) platform and performs various actions such as retrieving market data, placing orders, and managing historical data.

## TWS API

This repository contains a Python program that utilizes the TWS API (Trader Workstation API) for trading purposes. The TWS API is a powerful interface provided by Interactive Brokers to interact with their Trader Workstation platform programmatically.

## What is TWS API?

The TWS API allows developers to integrate their own applications with the Interactive Brokers Trader Workstation platform. It provides a comprehensive set of functions and data services for accessing real-time market data, placing orders, managing portfolios, retrieving historical data, and much more. With the TWS API, you can automate trading strategies, build custom trading applications, and leverage the advanced features of the Interactive Brokers platform.

## How to Use TWS API with a Program?

To use the TWS API with a program, follow these steps:

1. Obtain API Credentials: Before using the TWS API, you need to configure your Interactive Brokers account to enable API access. This involves logging into your account, enabling API connections, and generating the necessary credentials (API key, account ID, etc.). Refer to the Interactive Brokers documentation for detailed instructions on obtaining API credentials.

2. Set Up the TWS Platform: Install the Interactive Brokers Trader Workstation (TWS) platform on your computer and configure it with your account credentials. Ensure that the TWS platform is running and connected to the desired market data and trading destinations.

3. Choose a Programming Language: The TWS API supports various programming languages, including Python, Java, C++, and C#. Choose a programming language that you are comfortable with and has good support for the TWS API.

4. Implement API Functions: Use the TWS API documentation and programming guides to understand the available functions and data structures provided by the API. Depending on your requirements, you can implement functions to retrieve real-time market data, place orders, manage positions, retrieve historical data, and perform other trading-related operations.

5. Connect to TWS: Establish a connection from your program to the TWS platform using the API credentials. This involves establishing a socket connection and authenticating with the provided API key and account ID.

6. Interact with TWS: Once the connection is established, you can start interacting with the TWS platform by making API requests. This includes retrieving market data, placing orders, managing positions, and receiving real-time updates.

7. Handle API Responses: Handle the responses received from the TWS platform and process them in your program. This may involve parsing market data, managing order status, updating positions, and handling error conditions.

8. Implement Trading Strategies: Utilize the TWS API capabilities to implement your trading strategies or build custom trading applications. Leverage the real-time market data, historical data, and order placement functions provided by the API to execute your trading logic.

9. Monitor and Manage Connections: Monitor the API connection status and handle disconnections or errors gracefully. Implement reconnection mechanisms and error handling strategies to ensure the stability and reliability of your program.

10. Test and Deploy: Thoroughly test your program with simulated trading accounts or paper trading environments provided by Interactive Brokers. Once you are confident in your program's functionality, you can deploy it to live trading with real accounts, but exercise caution and proper risk management.

## Why Choose TWS?

There are several reasons why you might choose to use the TWS API and the Interactive Brokers Trader Workstation platform for your trading needs:

1. Comprehensive Trading Features: The TWS platform offers a wide range of advanced trading features, including access to global markets, various order types, advanced charting tools, risk management capabilities, and more. The TWS API allows you to leverage these features and build sophisticated trading applications.

2. Reliable Market Data: Interactive Brokers provides reliable and high-quality market data from global exchanges. The TWS API enables you to access real-time market data, historical data, and market scanners to support your trading strategies.

3. Execution Speed and Low Latency: Interactive Brokers is known for its fast execution and low-latency trading infrastructure. By using the TWS API, you can take advantage of this speed and efficiency in executing your trades.

4. Diverse Asset Classes: The TWS platform supports trading across various asset classes, including stocks, options, futures, forex, and more. The TWS API allows you to access and trade these asset classes programmatically.

5. Community and Support: Interactive Brokers has a large community of traders and developers using the TWS API. This means that you can find resources, documentation, and community support to help you in your development journey.

6. Industry Reputation: Interactive Brokers is a well-established and highly reputable brokerage firm, known for its robust technology, financial stability, and regulatory compliance. By choosing TWS and the TWS API, you can benefit from their industry experience and trustworthiness.

## Installation

To use this program, follow the steps below:

1. Ensure you have Python installed on your system (version 3.7 or above).

2. Clone this repository to your local machine:

```
git clone https://github.com/your-username/tws-api-python-program.git
```

3. Install the required dependencies:

```
pip install ibapi
```

Note: Additional dependencies may be required depending on your system configuration.

4. Configure the TWS platform and obtain the necessary API credentials. Refer to the Interactive Brokers documentation for detailed instructions on setting up the TWS API.

## Usage

Follow the steps below to use the TWS API Python program:

1. Open the program in your preferred Python IDE or text editor.

2. Modify the program according to your specific requirements. You can customize the requests made to the TWS API, adjust connection settings, or add additional functionality.

3. Set the `port` variable to the appropriate port number configured in your TWS platform.

4. Run the program:


The program will establish a connection with the TWS platform, retrieve market data, and display the results in the console. The data will also be saved in the `result.txt` file.

5. Analyze the retrieved data, modify the program as needed, or integrate it into your trading strategies.

## Program Structure

The program consists of the following main parts:

1. Importing Required Modules: The program imports necessary modules such as `cgi`, `inspect`, `ibapi`, and specific classes and enums required for interacting with the TWS API.

2. Initializing Global Variables: Global variables are initialized, including `port`, `globalArray`, `clientId`, `indexArray`, and `currentReqId`, which are used throughout the program.

3. Definition of the `TestApp` Class: This class inherits from the `EClient` and `EWrapper` classes provided by the TWS API. It serves as the primary client and event wrapper for handling API interactions.

4. Definition of the `run_loop` Function: This function runs the TWS API event loop using the provided `app_obj` (an instance of the `TestApp` class).

5. Definition of the `startInvesting` Class: This class contains static methods used for making different types of API requests, such as retrieving market data, historical data, and contract details.

6. Definition of the `printScanner` Function: This function prints and saves the retrieved market data to a file.

7. Main Function: The main function of the program calls the `buildScanner` method of the `startInvesting` class to initiate the retrieval of market data. It then calls the `printScanner` function to display and save the retrieved data.


Make sure to replace `your-username` in the repository URL with your actual GitHub username.



