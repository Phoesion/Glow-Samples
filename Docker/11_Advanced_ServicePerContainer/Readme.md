# Phoesion Glow Sample - Docker Advanced Setup : Service Per Container

<!--
#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Static_Content.html)
-->

### Introduction
This sample demonstrated how a **firefly entity** can be configure to **pull/host** only a **specific service** from a **specific quantum space**. 
This way you can configure the containerization grouping level, from a firefly entity hosting **all Services from all QuantumSpaces**, to **all** Services from a **single** QuantumSpace, to a **single** Service from a **specific** Quantum Space.

### Configuring
The desired configuration can be achieved using either the **config.json** file or **environment variable**. In this sample the dockerfile uses **environment variable** for configuring the entity, though a json sample is also available in this document for reference.

The configuration section **"QuantumSpaces"** allows the configuration per-QuantumSpace or a global filtering using the **"*"**. 

``` json
"QuantumSpaces": {
    // Setup default global rules
    "*": {
        "IsEnabled": false // by-default disable all QuantumSpaces
    },
    // Setup specific rules for QuantumSpace 'MySampleSpace'
    "MySampleSpace": {
        "IsEnabled": true, // enable this QuantumSpace
        "Services": {
            "*" : {
                "IsEnabled": false // by-default disable all services in this
            },
            "SampleService2" : {
                "IsEnabled": true // enable this service
            }
        }
    }
}
```

Breakdown :
1. Disable **All** Quantum Spaces for this **Entity**.
2. Enable **MySampleSpace**.
3. Disable **All** Services for Quantum Space **MySampleSpace**
4. Enable **SampleService2** for this Quantum Space.


### How to run
- Generate **Entity AuthKey** from **Blaze** tools for each entity and copy-paste them in to its respective txt file.
- Run `docker compose -f "docker-compose.yml" up -d` to start the containers.
- Connect to the **Lighthouse** using **Blaze** using **username "admin" and password "123qweASD!"**.
- Create a new **Quantum Space** with the name **MySampleSpace**.
- Deploy the **1_REST** sample into the new **"MySampleSpace" Quantum Space**.
  
If you examine each **Firefly Entity** from either **Blaze** or its container logs, you should see only one service running/hosted in each container.