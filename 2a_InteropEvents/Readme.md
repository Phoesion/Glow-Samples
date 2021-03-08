# Phoesion Glow Sample - Service Events


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Service_Interop.html)


### Introduction
This sample demonstrated the basic concepts of raising events between your services.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


## Summary
In this sample, we create two services. **SampleService1** that declares an *Events.cs* class in its API project and adds a [DependsOnAPI] attribute. The second service **SampleService2** that will be the listener, implements the *Events.cs* api, which exposes it for consumption of interop actions.


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

**This list does not contain all possible paths**

---

- [http://localhost:16000/SampleService1/SampleModule1/Action1?data=test](http://localhost:16000/SampleService1/SampleModule1/Action1?data=test) 
- [http://localhost:16000/SampleService1/SampleModule1/Action2?data=test](http://localhost:16000/SampleService1/SampleModule1/Action2?data=test) 
- [http://localhost:16000/SampleService1/SampleModule1/Action3?data=test](http://localhost:16000/SampleService1/SampleModule1/Action3?data=test) 
- [http://localhost:16000/SampleService1/SampleModule1/Action4?data=test](http://localhost:16000/SampleService1/SampleModule1/Action4?data=test) 
- 
---



