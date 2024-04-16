# Phoesion Glow Sample - Kubernetes Basic Setup

<!--
#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/XXXX.html)
-->

### Introduction
This sample demonstrated how setup a complete **Glow** ecosystem in Kubernetes.


### How does it work
To setup Phoesion Glow in Kubernetes, you need the four entity types *(as Kubernetes deployments)* :
1) **Kaleidoscope** : The service-bus that connects all the entities together.
2) **Lighthouse** : The command-and-control service. It **MUST** have only **1 replica** and be **kind: StatefulSet**
3) **Prism** : It is the **Ingress** service of **type: LoadBalancer**. It will receive external traffic and forward _(load-balance)_ it to the appropriate _(Firefly)_ service
4) **Firefly.k8s.operator** : The **Firefly [operator](https://kubernetes.io/docs/concepts/extend-kubernetes/operator/)** will live in the **[control plane](https://kubernetes.io/docs/concepts/overview/components/#control-plane-components)** and be responsible for creating new **Kubernetes deployments** for your **quantum-space services**.


### How to run
- Copy **02.setup-secrets___SAMPLE!!.yaml** to a new **02.deploy-secrets.yaml** file
- Generate **Entity AuthKey** from **Blaze** tools for each entity and copy-paste them in to its respective entry in the new **02.deploy-secrets.yaml** file.
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