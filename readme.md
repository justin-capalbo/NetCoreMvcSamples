# NetCoreMvcSamples - Dutch Treat

### What is "Dutch Treat"?

Dutch Treat is a sample ASPNetCore2.0 Project based on a [Pluralsight course](https://app.pluralsight.com/library/courses/aspnetcore-mvc-efcore-bootstrap-angular-web/) by [Shawn Wildermuth](https://wildermuth.com/).

### Branch/Project History

1. [feature/htmlCssBasics](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/htmlCssBasics) HTML and CSS foundation.  Naive styling with limited CSS.  No jQuery, bootstrap, or client side framework.
2. [feature/javascriptBasics](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/javascriptBasics) Adding jQuery and Bootstrap as dependencies and manipulate page elements using both toolsets.
3. [feature/usingMvc](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/usingMvc) Implementing basic MVC6 routing, controllers, Razor Layout and Include, and a mail service.
4. [feature/usingBootstrap](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/usingBootstrap) Adding Twitter Bootstrap and jQuery capability to the project to style page elements and _bootstrappify_ the layout.
5. [feature/addingEfCore](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/addingEfCore) First look at implementing Entity Framework Core with MSSQL Server localdb.  Adds entities, migrations, and a repository pattern that is used by a new controller.
6. [feature/AspnetMvcApi](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/AspnetMvcApi) Here we've added controllers with RESTful verbs only, and no views.  These controllers act as data access APIs for performing CRUD operations on our data.
7. [feature/aspnetCoreIdentity](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/aspnetCoreIdentity) Adding authentication and authorization to our StoreUser.  Enforce through both a cookie scheme for the site and a JWT creation endpoint to obtain a valid token for API calls.
8. [feature/typescriptIntro](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/typescriptIntro) Adding typescript config and a few basic .ts files to play around with.
9. [feature/startingAngular](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/startingAngular) Getting @angular into the project.  Barely scratches the surface of using the outer appcomponent app container and getting it onto our shop page.  This is followed by creating a small component for displaying the list of products in the shop and using markup to get data from the typescript class.
10. [feature/servicesWithAngular](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/servicesWithAngular) Implemented a dataService to centralize the data store for the client app.  Also provides a launch pad for interacting with the server through our APIs via the HTTP stack.  Added summary objects for orders and used mapreduce to summarize data from our classes on the page.
10. [feature/routingWithAngular](https://github.com/justin-capalbo/NetCoreMvcSamples/tree/feature/routingWithAngular) Using angular routes to allow us to navigate around our app to different components.  Still within our shop URL, we are navigating around our various app components by way of router-outlet.  We also used our token to log in and authorize a new order to be placed.


