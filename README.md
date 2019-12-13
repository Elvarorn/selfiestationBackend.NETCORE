# Selfie Station Backend
The Selfie Station system is a photobooth web application which allows user to take photos with a canon DSLR camera in an easy and fun way. 
This is the backend for that system, it is a API. it handles information flow throughout the system, our database, image handling and delivery.

## Getting started
To get the program up and running on your computer you must clone this repository. Once you have done that you open the project in an editor of your choice. We recommend using Visual Studio Code like we did while developing this project. The following sections of this README will cover how to build and run this project from scratch.

**Attention** to get access to the Azure database your ip address needs to be registered in the database server firewall. if you are not located in The University of Reykjavík you need to talk to the developers to get access to the server to add your ip yourself or tell them to add your specific ip address. 

if you want to send custom requests to the API you need to add the header: Key: "Auth"   Value:"644ebb11-2e70-4f94-9b2e-78ca0efaed0c".

## Prerequisites
you must have Visual Studio Code, or your preferred IDE, installed on your computer. you can download it:

**Here: https://visualstudio.microsoft.com/downloads/**

You must have .Net Core 3.x installed on your computer. you can download it:

**Here: https://dotnet.microsoft.com/download**

## Building and running

Open the selfiestationBackend.NETCORE folder in Visual Studio Code. when the project folder is open in the IDE you need to open the SelfieStation.WebApi folder by typing the command below into the terminal:

```
cd .\SelfieStation.WebApi\
```

then you need to get all the packages you need to run the project you run the command:

```
dotnet restore
```

then to build the project you run the command:

```
dotnet build
```

then finally to run the program you need to run the command:

```
dotnet run
```

## Testing
The Integration tests are stored under the folder "Postman Integration Tests". as the name indicates, they are made in Postman and need to be imported to be run.

The tests performed after adding an image or adding an ad needs its URL to be configured after each run of the tests
for example after running the tests for the first time you need to https://localhost:5001/api/images/59 -> https://localhost:5001/api/images/60

Unfortunately there are no Unit tests for this project.



