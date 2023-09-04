# BycicleRental
How to run the application on your PC:
Make sure you have .Net Core 3.1 Installed.
Download the zip file or pull the repository with a version control.
Connect the AppDbContext to your server name.
Open the package manager console and run the following commands (Make sure you have chosen BicycleRental.Data):
Install-Package Microsoft.EntityFrameworkCore -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.Design -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.Proxies -Version 3.1.32
In the package mannager console type "Update-Database" (Make sure you have chosen BicycleRental.Data).
Run the seeder in "BicycleRental.Seeder" if you want to fill the database with example data.
Use the app!
