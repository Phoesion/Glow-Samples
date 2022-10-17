# Phoesion Glow Sample - Serilog

### Introduction
This sample demonstrates how to add Serilog logger to your service


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


### Importand
When you enable Serilog using the `UseSerilog()` extention in `ServiceMain.ConfigureHost()`, make sure to enable the `writeToProviders` option, so the log messages will also 
get emitted to the Glow Firefly host so they can be processed and emmited to the Lighthouse. If you do not enable the `writeToProviders` option Serilog will capture all log messages 
and they will not be _visible_ to the Glow Firefly service _(and thus not visible from Blaze)_


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/HelloWorld/](http://localhost:16000/HelloWorld/)

See logs in the console (when debugging) or in Blaze (for deployed service)

