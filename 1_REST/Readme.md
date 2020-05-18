# Phoesion Glow Sample - REST Basics


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/Tutorials_REST_Services_Action_Basics.html)


### Introduction
This sample demonstrated the basic concepts of writing **REST** services.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/articles/Getting_Started_DevMachine_Setup.html)


## Routes
when trying to consume an action from a web-browser/rest-client, the basic Uri rule you can use is :

- http[*s*]://*hostname*/**ServiceName**/[*v0*]/**ModuleName**/[*v0*]/**ActionName**/[*other path*][?queryString]

Where fields in brackets **[xx] are optional**. 


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

**This list does not contain all possible paths**

---

- [http://localhost:16000/SampleService1/SampleModule1/](http://localhost:16000/SampleService1/SampleModule1/) 
- [http://localhost:16000/SampleService1/SampleModule1/Action1](http://localhost:16000/SampleService1/SampleModule1/Action1) 
- [http://localhost:16000/SampleService1/SampleModule1/Action2/test?myKey=myValue](http://localhost:16000/SampleService1/SampleModule1/Action2/test?myKey=myValue) 
- [http://localhost:16000/SampleService1/SampleModule1/Action3?value1=hi&value2=true](http://localhost:16000/SampleService1/SampleModule1/Action3?value1=hi&value2=true) 
- [http://localhost:16000/SampleService1/SampleModule1/DoTheThing?username=john](http://localhost:16000/SampleService1/SampleModule1/DoTheThing?username=john) 

---

- [http://localhost:16000/SampleService1/SampleModule2/Action1](http://localhost:16000/SampleService1/SampleModule2/Action1) 
- [http://localhost:16000/SampleService1/SampleModule2/AsyncAction](http://localhost:16000/SampleService1/SampleModule2/AsyncAction) 
- [http://localhost:16000/SampleService1/SampleModule2/SampleStrongType](http://localhost:16000/SampleService1/SampleModule2/SampleStrongType) 
- [http://localhost:16000/SampleService1/SampleModule2/SampleObjectType?retType=1](http://localhost:16000/SampleService1/SampleModule2/SampleObjectType?retType=1) 

---

- [http://localhost:16000/SampleService2/SampleModule1/Action1](http://localhost:16000/SampleService2/SampleModule1/Action1) 
- [http://localhost:16000/SampleService2/SampleModule1/RedirectMe](http://localhost:16000/SampleService2/SampleModule1/RedirectMe) 
- [http://localhost:16000/SampleService2/SampleModule1/SampleStatusCode?command=hi](http://localhost:16000/SampleService2/SampleModule1/SampleStatusCode?command=hi) 
- [http://localhost:16000/SampleService2/SampleModule1/SampleStatusCode?command=banana](http://localhost:16000/SampleService2/SampleModule1/SampleStatusCode?command=banana) 
- [http://localhost:16000/SampleService2/SampleModule1/StreamingSample1](http://localhost:16000/SampleService2/SampleModule1/StreamingSample1) 
- [http://localhost:16000/SampleService2/SampleModule1/](http://localhost:16000/SampleService2/SampleModule1/) 

---



