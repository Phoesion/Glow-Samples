# Phoesion Glow Sample - Kubernetes Basic Setup

<!--
#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/XXXX.html)
-->

### Introduction
This sample demonstrated how setup a complete **Glow** ecosystem in Kubernetes.


### How to run
- Generate **Entity AuthKey** from **Blaze** tools for each entity and copy-paste them in to its respective entry in the **02.deploy-secrets.yaml** file.
- Run the commands to apply deployments
 ``` sh
 kubectl apply -k .
 ```
- Connect to the **Lighthouse** using **Blaze** using **username "admin" and password "123qweASD!"**.
- Deploy the **1_REST** sample into the new **"Default" Quantum Space**.
  

### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

---

- [http://localhost/SampleService1/SampleModule1/](http://localhost:16000/SampleService1/SampleModule1/) 
- [http://localhost/SampleService1/SampleModule1/Action1](http://localhost:16000/SampleService1/SampleModule1/Action1) 
- [http://localhost/SampleService1/SampleModule1/Action2/test?myKey=myValue](http://localhost:16000/SampleService1/SampleModule1/Action2/test?myKey=myValue) 

---

- [http://localhost/SampleService1/SampleModule2/Action1](http://localhost:16000/SampleService1/SampleModule2/Action1) 
- [http://localhost/SampleService1/SampleModule2/AsyncAction](http://localhost:16000/SampleService1/SampleModule2/AsyncAction) 

... (more sample routes in the **1_REST** sample readme.md)