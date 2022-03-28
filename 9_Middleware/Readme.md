# Phoesion Glow Sample - Middleware


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Middleware.html)


### Introduction
Middleware is software that's assembled into an app pipeline to handle requests and responses. \
Each component:
 - Chooses whether to pass the request to the next component in the pipeline.
 - Can perform work before and after the next component in the pipeline
Each middleware component in the request pipeline is responsible for invoking the next component in the pipeline or short-circuiting the pipeline.
When a middleware short-circuits, it's called a terminal middleware because it prevents further middleware from processing the request.

The middleware pipeline architecture in **Phoesion Glow** is modeled after **ASP.net core** pipelines. [Read the ASP.net core documentation for more in-depth understanding](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware)


### How to run
- Build the **Sample.sln** solution
- Run the **Foompany.Services.SampleService1** service.
- 

### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

- [http://localhost:16000/SampleService1/SampleModule1/Action1](http://localhost:16000/SampleService1/SampleModule1/Action1) 

> [!NOTE]
> The output will be printed in the Console (when running in debugger), or you can see the **Logs** from **Blaze** you if you deployed the sample.