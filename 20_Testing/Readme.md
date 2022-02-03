# Phoesion Glow Sample - Interop


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Testing.html)


### Introduction
This sample demonstrated the basic concepts of Unit/System Testing your services.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


### Github Actions
In the **.github\workflows** you can find a sample **dotnet.yml** that can be used to run system tests as a github workflow action. 
The sample installs and starts the Phoesion Glow Reactor service, that includes the Phoesion.Glow.Reactor.Debugger.exe tool.


## Summary
In this sample, we create two services and some UnitTest project that test either specific units or the entire system.

### How to test
---

---



