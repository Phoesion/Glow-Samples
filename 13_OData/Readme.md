# Phoesion Glow Sample - OData


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/articles/xxx.html)


### Introduction
This sample demonstrates the most basic and fundamental concepts of OData.


### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

For simple IEnumerable types :
- http://localhost:16000/BookStore/Inventory/GetBooks?$select=Title&$orderby=Id%20desc
- http://localhost:16000/BookStore/Inventory/GetBooks?$filter=id%20eq%201&$select=Title

For IQueryable types (from EFCore queries) : 
- http://localhost:16000/BookStore/Inventory/GetBooksFromDB?$select=Title&$orderby=Id%20desc
- http://localhost:16000/BookStore/Inventory/GetBooksFromDB?$filter=id%20eq%201&$select=Title
