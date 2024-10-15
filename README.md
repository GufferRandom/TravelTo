Turebi agency where companies post their turebi on tha site . 
in this project frond and back is mixed together working on new project where backend is seperated from fronted.


Requirements to Run the Repo Locally (Linux Debian-based)
Step 1: Install .NET SDK and EF Tool

If you haven't installed the .NET SDK, run the following commands:

bash

sudo apt install dotnet-sdk-8.0
dotnet tool install -g dotnet-ef

Step 2: Clone the Repository

Clone your Git repository and navigate into it:

bash

git clone https://github.com/CollabarationIooo/TravelTo.git
cd TravelTo

Step 3: Update appsettings.json

Open appsettings.json and change "UseSqlite" to "true" to use SQLite. If you prefer to use SQL Server, ensure this is set to "false".

Use any text editor, for example:

bash

nano appsettings.json

Change:

json

"UseSqlite": "false"

to:

json

"UseSqlite": "true"

Step 4: Restore, Build, and Run

Restore dependencies, build the project, and run it:

bash

dotnet restore
dotnet build
dotnet run
