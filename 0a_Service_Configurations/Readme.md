# Phoesion Glow Sample - Service Configurations


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Service_Configurations.html)


### Introduction
The **Service Configuration** system allows you to provide **deploy-time** configurations to **your services**.
The configurations can be setup during the deployment process and will be available to your firefly service.
Configuration are only valid for the **Quantum Space you deployed** your services, each **Quantum Space** has it's own configuration set *(even if you deploy the same service assemblies)*.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)
- Apply your configurations in the deployment wizard


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/HelloWorld/ViewConfigs/FromIConfiguration](http://localhost:16000/HelloWorld/ViewConfigs/FromIConfiguration) 
- [http://localhost:16000/HelloWorld/ViewConfigs/FromService](http://localhost:16000/HelloWorld/ViewConfigs/FromService) 

You should see default value for each configuration