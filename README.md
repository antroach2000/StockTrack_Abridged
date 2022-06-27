# StockTrade_Abridged

A shortened repo of StockTracker

Before running the script BuildStockLiveV1DB.sql, change the following destination path on line 7 and 9 for your own environments:

'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\StockLiveV1.mdf'

Run the script to restore the StockLiveV1 database to SQL Server 2017 or greater


# StockTrade_dotNet

Load the .Net Core 6 project StockTrade_dotNet/StockTrade.Web.API.sln


Change the appsettings.json->dbConnection and point to the database


Fully functional Web API, use any stock code listed on the ASX

NAB       -   NATIONAL AUSTRALIA BANK LIMITED

MQG       -   MACQUARIE GROUP LIMITED

ANZ       -   AUSTRALIA AND NEW ZEALAND BANKING GROUP LIMITED

FMG       -   FORTESCUE METALS GROUP LTD

SQ2       -   BLOCK INC

WDS       -   WOODSIDE ENERGY GROUP LTD

WES       -   WESFARMERS LIMITED


API Version is 1 for all requests

For example:

Stock Code:   BHP

Api Version:  1




# StockTrade_React

The application does not run at all it is example code only, it has a section of code where we are able to Add/Edit/Remove a portfolio.

The Project is NextJS using Typescript, a demo can be found at:

# https://stock-tracker-react.vercel.app


# If you get a Serverless timeout 

This Serverless Function has crashed

Your connection is working correctly

Vercel is working correctly


Clear all cookies, local storage for https://stock-tracker-react.vercel.app in the browser and refresh

Login process being changed from AWS Cognito to another provider
          
