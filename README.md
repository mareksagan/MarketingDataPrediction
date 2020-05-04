# MarketingDataPrediction
User friendly marketing campaign supporting system with AI capabilities (Random Forest, Accord.NET, .NET Core, Web API 2, ReactJS and Recharter)

## Description

The project aims at optimizing the telephone marketing campaign process by creating a Machine Learning system. 
The system predicts which clients would potentially be interested in a term deposit.
It utilizes an anonymized dataset coming from a bankrupt Portuguese bank.
It reduces the campaign costs and the burden put on the potential bank clients (unwanted calls).

## Database

Based upon [the following dataset](http://archive.ics.uci.edu/ml/datasets/Bank+Marketing).
It underwent the data wrangling process which is a standard practice in data analysis.

## Installation
* Set up MS SQL Server and NodeJS on your machine
* Generate a DB table hierarchy using Entity Framework and import sample records
* Use `dotnet run` from .NET Core 2 or compile the project in Visual Studio 2017
* Go to [localhost:44309](https://localhost:44309)
