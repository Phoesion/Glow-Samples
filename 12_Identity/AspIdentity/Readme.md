# Phoesion Glow Sample - ASP.Net Core Identity Sample

### Introduction
This sample demonstrates how to add **ASP.Net Core Identity** in **Prism**


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


### YARP
The reverse proxy used is **YARP** and you can configure it from the **Glow Project Editor**->select **project.pgproject** file->**Reverse Proxy** tab.


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/AspIdentity/](http://localhost:16000/AspIdentity/)


In "/test" and "/something" routes, you should see google.com, microsoft.com and yahoo.com responses.


