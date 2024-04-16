# Phoesion Glow Sample - Entity Framework Core


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/)


### Introduction
This sample demonstrated the basic concepts of using EFCore in your services.


### How to run
- Setup a local MySQL server with a user **root** and password **root**, and a database schema with name **localhost** *(or change the connection string to your own)*
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


## Summary
In this sample, we create simple schema of a blog with some posts. We can use them to perform *add-migration*, *update-database* etc. using the scripts provided in the **Scripts** directory in the **Foompany.Database** project


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/SampleService1/](http://localhost:16000/SampleService1/) 



