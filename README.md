Turebi agency where companies post their turebi on tha site . 
in this project frond and back is mixed together working on new project where backend is seperated from fronted.



## Run Locally

First of all net sdk is needed and ef tools to install it 

```bash
  sudo apt install dotnet-sdk-8.0
  dotnet tool install -g dotnet-ef  
```
Clone My project
```bash
  git clone https://github.com/CollabarationIooo/TravelTo.git
```

Go to the project directory

```bash
  cd TravelTo
```

Update appsettings.json

  Open appsettings.json and Change "UseSqlite" :"False" to "UseSqlite":"True" 

bash
```bash
nano appsettings.json
```
add migrations and update database 

```bash
  dotnet ef migrations add InitialCreate  
  dotnet ef database update

```
restore ,build and run 
```bash
  dotnet restore
  dotnet build 
  dotnet run  
  
```
