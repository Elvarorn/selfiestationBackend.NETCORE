# Selfie Station Backend
The Selfie Station system is a photobooth web application which allows user to take photos with a canon DSLR camera in an easy and fun way. 
This is the backend for that system, it is a API. it handles information flow throughout the system, our database, image handling and delivery.

## Getting started
To get the program up and running on your computer you must clone this repository. Once you have done that you open the project in an editor of your choice. We recommend using Visual Studio Code like we did while developing this project. The following sections of this README will cover how to build and run this project from scratch.

**Attention** to get access to the Azure database your ip address needs to be registered in the database server firewall. if you are not located in The University of Reykjavík you need to talk to the developers to get access to the server or tell them to add your specific ip address. 

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


