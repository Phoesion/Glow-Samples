# Phoesion Glow Sample


#### [Documentation : Read the full documentation here](https://glow-docs.phoesion.com/articles/intro.html)


### Introduction
This sample repository for Phoesion Glow, the complete micro-service development solution. 


### What is Phoesion Glow ?
Phoesion Glow is a set of tools and runtime with which your can create scalable cloud services.

Phoesion Glow is a complete solution for developing and managing your services, from libraries and tools in your IDE up to web servers, service bus and service hosts. All components have been created from scratch with the purpose of creating a uniform experience in both developing and managing your services


### Structure
Each folder is a separate sample with an id and a name/description. \
For example :

- **1_REST** is a sample that demonstrates the fundamentals and capabilities of writing **REST** services for your cloud
- **2_Interop** is a sample that demonstrates the fundamentals and capabilities of service-to-service \
  (**inter**nal **op**eration) within your cloud

Each sample has a readme.md file with quick sample-specific instructions of how to setup/test the sample, and a link to a full tutorial to the documentation site.


### How to run
- Build the **Sample_{SampleName}_.sln** solution in the samples folder
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/MyService/MyModule/MyAction]() 

where *MyService*, *MyModule*, *MyAction* in the service/module/action you wish to test

