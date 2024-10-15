Turebi agency where companies post their turebi on tha site . 
in this project frond and back is mixed together working on new project where backend is seperated from fronted.


Requerments to run this repo in local machine (Linux Deb based):
*Net SDK

Step 1 -
install net Sdk if not installed and ef tool
sudo apt install net-sdk-8.0
dotnet tool install -g dotnet-ef

Step 2 -clone my git repo and enter it
git clone  https://github.com/CollabarationIooo/TravelTo.git
cd TravelTo

Step 3 change appsettings.json find "UseSqlite" and change it to "true" . if not then you will need sql server.
nano appsettings.json //or any other editor like vim , vs ,vs code .. etc

from "UseSqlite":"false" to "UseSqlite":"true"

Step 4 restore build and run-
dotnet restore
dotnet build
dotnet run
