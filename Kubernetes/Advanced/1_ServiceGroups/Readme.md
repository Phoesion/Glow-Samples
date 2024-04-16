# Phoesion Glow Sample - Kubernetes Basic Setup

<!--
#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/XXXX.html)
-->

### Introduction
This sample demonstrated how setup a complete **Glow** ecosystem in Kubernetes.


### How to run
- Copy **02.setup-secrets___SAMPLE!!.yaml** to a new **02.deploy-secrets.yaml** file
- Generate **Entity AuthKey** from **Blaze** tools for each entity and copy-paste them in to its respective entry in the new **02.deploy-secrets.yaml** file.
- Run the commands to apply deployments
 ``` sh
 kubectl apply -k .
 ```
- Connect to the **Lighthouse** using **Blaze** using **username "admin" and password "123qweASD!"**.
- Deploy the **1_REST** sample into the new **"Default" Quantum Space**.
- In **Blaze GUI->Default(qspace)->ServiceGroups**, edit the group ***(Default)** and remove(unselect) **SampleService2** and then edit **MyGroup** to assign **SampleService2** to group. 
  **SampleService2** will now only be served from **firefly-operator-mygroup**