How to run : 
1. Setup a kubernetes cluster with Glow _(see kubernetes samples)_
2. Apply the **goserver_service.yaml** using command `kubectl apply -f goserver_service.yaml`
3. Deploy **glow.pgproject** to the **Default** quantum space _(or change the quantum-space-id in the goserver_service.yaml match-selector section)_
4. You should see "Hello, World!" message in your browser