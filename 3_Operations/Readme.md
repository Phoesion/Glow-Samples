# Phoesion Glow Sample - Operations


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/Tutorials_Operation_Module.html)


### Introduction
This sample demonstrated the basic concepts of **Operations**, a system to perform in-memory context-sensitive work.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/articles/Getting_Started_DevMachine_Setup.html)


## Sumarry
In this sample, we have two services.

 **SampleService2** implements an **Operation Module**, to create a simple wizard.
 The purpose of this operation is to hold in-memory the key/values of the wizard as the client performs a set of **independent REST request** to our cloud services. A normal **Action** in a basic **Firefly Module** could have been routed to **any** available firefly instance, not the one who created the in-memory dictionary when starting the wizard.

 The **Operation** mechanism in **Phoesion Glow** allows you to preserve a context using the **Operation Id** so all subsequent request/calls will be routed to the same instance. Other usage examples can be, for example, when starting a game room or a game match, where the instance runs the game logic/networking etc.


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

**This list does not contain all possible paths**

1. Start a wizard using [http://localhost:16000/SampleService2/SampleModule1/StartSimpleWizard]() \
   This will return the **operationId** that should be used for subsequent requests

2. See the status using either : [http://localhost:16000/SampleService2/Operations.SimpleWizard/Status/[OPERATIONID]]() \
   Note: make sure to replace **[OPERATIONID]** value in the query string with your own. \
   *(Results should be empty)*

4. Using Postman send a POST request to either :
   - [http://localhost:16000/SampleService1/SampleModule1/SubmitParameterToWizard?id=[OPERATIONID]>&key=sampleKey&value=sampleValue]()\
    or
   - [http://localhost:16000/SampleService1/Operations.SimpleWizard/SubmitParameterToWizard/[OPERATIONID]?key=sampleKey&value=sampleValue]()

   Note: make sure to replace **[OPERATIONID]** value in the query string with your own.

4. See the status again using the url from **Step 2**

5. Complete/Finish the wizard(and destroy the operation) using **POST** to [http://localhost:16000/SampleService1/Operations.SimpleWizard/Finish/[OPERATIONID]]() \
   Note: make sure to replace **[OPERATIONID]** value in the query string with your own.



