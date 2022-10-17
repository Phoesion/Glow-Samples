# Phoesion Glow Sample - GraphQL


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/xxx.html)


### Introduction
This sample demonstrates the most basic and fundamental concepts of GraphQL in Glow.


### How to run
- Build the **Sample.sln** solution
- Run **Foompany.Services.Example** project


### How to test
After you run/deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

1. Go to url [http://localhost/Example/ui/playground](http://localhost/Example/ui/playground)
2. Use the following json for query
```json
{
  human(id: "1"){
    name
  }
}
```
3. Press the **Play/Run** button in the playground UI
