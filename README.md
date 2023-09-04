# BycicleRental
How to run the application on your PC:

 1.Make sure you have .Net Core 3.1 Installed.
 
 2.Download the zip file or pull the repository with a version control.
 
 3.Connect the AppDbContext to your server name.
 
 4.Open the package manager console and run the following commands (Make sure you have chosen BicycleRental.Data)
 
 5.Install-Package Microsoft.EntityFrameworkCore -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.Design -Version 3.1.32 Install-Package Microsoft.EntityFrameworkCore.Proxies -Version 3.1.32
 
 6.In the package mannager console type "Update-Database" (Make sure you have chosen BicycleRental.Data)
 
 7.Run the seeder in "BicycleRental.Seeder" if you want to fill the database with example data.
 
 8.Use the app!
