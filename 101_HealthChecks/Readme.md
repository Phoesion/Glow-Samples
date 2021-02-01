# Phoesion Glow Sample - Hello World


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Create_Hello_World.html)


### Introduction
This sample demonstrates the most basic and fundamental concepts of Health checks for a Firefly service. 
For more info about Health Checks you can read [Health checks in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks)


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/SampleService1/Health](http://localhost:16000/SampleService1/Health)

You should see a "Healthy" message in your browser.

