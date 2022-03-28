# Phoesion Glow Sample - Static Files


#### [Documentation : Read the full tutorial here](https://glow-docs.phoesion.com/tutorials/Static_Content.html)


### Introduction
**Static content** or **Static Files** refers to any file that will be publicly accessible and cannot change _(until you deploy a new version of the service)_.
An example of static content is a JavaScript (.js) file or an image (eg. a png file) or even an html file.

### How does Static Content work?
Static content will be distributed to the **Prism** entities _(edge nodes)_, to be as close to the client/browser as possible.
When a client/browser requests a static file for a service, the **Prism will already have the file cached locally** and can provide it directly, thus avoiding putting any pressure on the other entities, _like the Kaleidoscope (Service bus) or Fireflies (Services)_. \
This means for Static Content the **Prisms** act as a [**content delivery network (CDN)**](https://en.wikipedia.org/wiki/Content_delivery_network)

### Run business logic for static files
In many cases it's useful to be able to run some business logic, for example Authorization middleware, when serving static files.
This can be accomplished using the **[[RunMiddlewareForStaticFiles](https://glow-docs.phoesion.com/api/Phoesion.Glow.SDK.Firefly.RunMiddlewareForStaticFilesAttribute.html)]** attribute.
In this case the **Prism** will query the **Firefly** service that will run the middleware pipeline and if it returns **200 OK** the **Prism** will serve the file to the client.

### How to run
- Build the **Sample.sln** solution
- Deploy the **project** (*Project.pgproject*) to your glow cloud using Phoesion Glow **Blaze**. For more information how to setup you cloud you can [read the getting started guide](https://glow-docs.phoesion.com/getting_started/DevMachine_Setup.html)
- Apply your configurations in the deployment wizard


### How to test
After you deploy your **glow project** you can test it using the following paths *(assuming local deployment)* :

from **Content** directory :
- [http://localhost:16000/HelloWorld/Content/SomeImage.png](http://localhost:16000/HelloWorld/Content/SomeImage.png) 
- [http://localhost:16000/HelloWorld/Content/TextFile.txt](http://localhost:16000/HelloWorld/Content/TextFile.txt)

from **wwwroot** directory :
- [http://localhost:16000/HelloWorld/SomeFile.txt](http://localhost:16000/HelloWorld/SomeFile.txt)

using **[RunMiddlewareForStaticFiles]** and **Content/Protected** directory :
- [http://localhost:16000/HelloWorld/Content/Protected/TextFile.txt?pass=abc](http://localhost:16000/HelloWorld/Content/Protected/TextFile.txt?pass=abc)

with incorrect password
- [http://localhost:16000/HelloWorld/Content/Protected/TextFile.txt?pass=wrong](http://localhost:16000/HelloWorld/Content/Protected/TextFile.txt?pass=wrong)
