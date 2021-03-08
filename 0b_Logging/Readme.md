# Phoesion Glow Sample - Logging


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Logging.html)


### Introduction
Phoesion Glow provides you with a complete **build-in logging solution**, that includes both **producing logs** from your services and **consuming** them using the **Blaze** UI. 
The logging framework is based on the [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging) framework, so if you need more in-depth information you can read the [Logging in .NET documentation](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging)


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)
- Apply your configurations in the deployment wizard


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/HelloWorld/Logging/LogDebug](http://localhost:16000/HelloWorld/Logging/LogDebug) 
- [http://localhost:16000/HelloWorld/Logging/LogInformation](http://localhost:16000/HelloWorld/Logging/LogInformation) 
- [http://localhost:16000/HelloWorld/Logging/LogWarning](http://localhost:16000/HelloWorld/Logging/LogWarning) 
- [http://localhost:16000/HelloWorld/Logging/LogWithContext?username=john&somevalue=foo](http://localhost:16000/HelloWorld/Logging/LogWithContext?username=john&somevalue=foo) 
- [http://localhost:16000/HelloWorld/Logging/LogException](http://localhost:16000/HelloWorld/Logging/LogException) 
- [http://localhost:16000/HelloWorld/Logging/CreateScopedLog](http://localhost:16000/HelloWorld/Logging/CreateScopedLog) 

> [!NOTE]
> To see the logs from **Blaze** you need to deploy the sample to a **Quantum Space** and not just run it using the debugger in Visual studio