# Phoesion Glow Sample - Service Tags


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Service_Tags.html)


### Introduction
This sample demonstrated the basic concepts of request routing to a service instance using runtime tagging.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproj*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


## Summary
In this sample, we create two services. **MyGame** service implements a simple game server manager for game **MyGame**, with a **GameRooms** module that allows use to create a new game room. 
Since we care about ping/latency we can to create a game room in a server in a geo-region that the player has requested ( eg, europe,us-east, etc).
To accomplish this our service declares a **ServerLocationTag** that during initialization it set the appropriate value, `europe` in this sample. The game client *(or other services using interop)* can request a new game room and provide a tag value for the **ServerLocationTag** that the glow system will use to route the request to appropriate service.


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- Create a room in 'europe' : \
  [http://localhost:16000/MyGame/GameRooms/CreateGameRoom?**tag:serverlocation=europe**&roomname=MyRoomName/](http://localhost:16000/MyGame/GameRooms/CreateGameRoom?tag:serverlocation=europe&roomname=MyRoomName/) 

- Attempt to create a room in 'us-east'. No service instance has set this tag, so this request will fail with HTTP 502 BadGateway : \
  [http://localhost:16000/MyGame/GameRooms/CreateGameRoom?**tag:serverlocation=us-east**&roomname=MyRoomName/](http://localhost:16000/MyGame/GameRooms/CreateGameRoom?tag:serverlocation=us-east&roomname=MyRoomName/) 


- Create a room without specifying a tag :  *(a world-wide random instance will be selected)* : \
  [http://localhost:16000/MyGame/GameRooms/CreateGameRoom?roomname=MyRoomName/](http://localhost:16000/MyGame/GameRooms/CreateGameRoom?roomname=MyRoomName/) 


