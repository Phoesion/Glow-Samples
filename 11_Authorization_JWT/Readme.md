# Phoesion Glow Sample - Authorization using JWT


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/XXXX.html)


### Introduction
This sample demonstrates the basic of Authorization using JWT in Phoesion Glow.

### How to run
- Build the **Sample.sln** solution
- Run the **Foompany.Services.SampleService1** service.
- Open a console and go to the **Service's project path** _( Samples\11_Authorization_JWT\Services\Foompany.Services.SampleService1 )_
- Create a **developer jwt token** by running `dotnet user-jwts create --name "glow_demo" --audience "myApi" --valid-for "365d"`
- **Use** the **generated token** for testing your api

### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/SampleService1/SampleModule1/DoTheThing?input=some_input](http://localhost:16000/SampleService1/SampleModule1/DoTheThing?input=some_input) 

> [!NOTE]
> Make sure you use the generated token, otherwise you will get a **401** response