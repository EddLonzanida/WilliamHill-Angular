# TechChallenge
* Test project for William Hill Australia using Angular 7
* Demo app using [Eml*](https://www.nuget.org/packages?q=EddLonzanida) NuGets.
* Check out [EmlExtensions.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.EmlExtensions) to automate the creation of controllers, views, seeders, and more!.

## Seed the database
1. Open the solution using Visual Studio 2017, compile and build (don't run yet)
2. Right click TechChallenge.Api project and Set as **startup project**
3. Open Package manager console
4. In the 'Default project' **drop down**, select **TechChallenge.DataMigration** (this is important)
5. In the console, type the command below then press enter to execute. 
```javascript
update-database -verbose
```

## Run the application
1. Press F5 to run the back-end webapi using **IIS Express**
2. Open **Powershell**
3. Navigate to TechChallenge\Hosts\TechChallenge.Spa
4. In the console, type the command below then press enter to execute
```javascript
npm start
```
## Documentation [here](https://raw.githubusercontent.com/EddLonzanida/TechChallenge-WebApi/master/Docs/TechChallenge%20-%20SolutionArchitecture.docx)

### Quick View
![](https://github.com/EddLonzanida/TechChallenge-WebApi/blob/master/Docs/Art/QuickView.png)

