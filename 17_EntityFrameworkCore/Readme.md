# Phoesion Glow Sample - Interop


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/)


### Introduction
This sample demonstrated the basic concepts of a background worker in your services.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/articles/Getting_Started_DevMachine_Setup.html)


## Sumarry
In this sample, we create a services **SampleService1** with a background worker that counts up every 0.5 second. The *DefaultModule.cs* displays the counter value.

You **don't have to** to expose any modules/action from your service, if you just want it to be a worker service that is unreachable from the outside world.


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/SampleService1/SampleModule1/](http://localhost:16000/SampleService1/SampleModule1/) 



