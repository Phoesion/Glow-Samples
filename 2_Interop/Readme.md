# Phoesion Glow Sample - Interop


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/Tutorials_Service_Interop.html)


### Introduction
This sample demonstrated the basic concepts of communication between your services.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/articles/Getting_Started_DevMachine_Setup.html)


## Sumarry
In this sample, we create two services. **SampleService2** implements a set of interop action, which it exposes for consumption using the service's api *(in project Foompany.Services.API.SampleService2)*.

**SampleService1** references that api and can consume it *(call the actions)* using the **Call(apimethod).InvokeAsync()** function. *[(sample code)](https://github.com/Phoesion/Glow-Samples/blob/master/2_Interop/Services/Foompany.Services.SampleService1/Modules/SampleModule1.cs#L23)*


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

**This list does not contain all possible paths**

---

- [http://localhost:16000/SampleService1/SampleModule1/](http://localhost:16000/SampleService1/SampleModule1/) 
- [http://localhost:16000/SampleService1/SampleModule1/Action1](http://localhost:16000/SampleService1/SampleModule1/Action1) 
- [http://localhost:16000/SampleService1/SampleModule1/Action2](http://localhost:16000/SampleService1/SampleModule1/Action2) 
- [http://localhost:16000/SampleService1/SampleModule1/Action3](http://localhost:16000/SampleService1/SampleModule1/Action3) 
- [http://localhost:16000/SampleService1/SampleModule1/Action4](http://localhost:16000/SampleService1/SampleModule1/Action4) 
- [http://localhost:16000/SampleService1/SampleModule1/Action5](http://localhost:16000/SampleService1/SampleModule1/Action5) 
- [http://localhost:16000/SampleService1/SampleModule1/StreamingInteropAction](http://localhost:16000/SampleService1/SampleModule1/StreamingInteropAction) 

---

- [http://localhost:16000/SampleService2/InteropSample1/InteropAction3](http://localhost:16000/SampleService2/InteropSample1/InteropAction3) 

---



