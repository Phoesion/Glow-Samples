# Phoesion Glow Sample - Docker Basic Setup

<!--
#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Static_Content.html)
-->

### Introduction
This sample demonstrated how setup a complete **Glow** ecosystem in Docker using docker-compose.


### How to run
- Generate **Entity AuthKey** from **Blaze** tools for each entity and copy-paste them in to its respective txt file.
- Run `docker compose -f "docker-compose.yml" up -d` to start the containers.
- Connect to the **Lighthouse** using **Blaze** using **username "admin" and password "123qweASD!"**.
- Deploy the **1_REST** sample into the new **"Default" Quantum Space**.
  

### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

---

- [http://localhost:16000/SampleService1/SampleModule1/](http://localhost:16000/SampleService1/SampleModule1/) 
- [http://localhost:16000/SampleService1/SampleModule1/Action1](http://localhost:16000/SampleService1/SampleModule1/Action1) 
- [http://localhost:16000/SampleService1/SampleModule1/Action2/test?myKey=myValue](http://localhost:16000/SampleService1/SampleModule1/Action2/test?myKey=myValue) 

---

- [http://localhost:16000/SampleService1/SampleModule2/Action1](http://localhost:16000/SampleService1/SampleModule2/Action1) 
- [http://localhost:16000/SampleService1/SampleModule2/AsyncAction](http://localhost:16000/SampleService1/SampleModule2/AsyncAction) 

... (more sample routes in the **1_REST** sample readme.md)