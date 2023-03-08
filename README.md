# BlazingChat - Realtime Chat App using Blazor WASM and SignalR

> BlazingChat is a fullstack realtime chat app using Asp.Net Core Blazor Web Assembly (WASM) and SignalR Core with SQL Server and EF Core - .Net 6


![BlazingChat](https://github.com/Abhayprince/BlazingChat/blob/master/Blazing-Chat-Final.png)

## To Run Locally
- Clone the Repo
    `git clone https://github.com/Abhayprince/BlazingChat `
    
- Restore the packages (Rebuild the solution)
    
- Set the `BlazingChat.Server` project as startup project
    
- Change the Database connection string in `appsettings.Development.json` file in `BlazingChat.Server` Project
    ```
    "ConnectionStrings": {
        "Chat": "Data Source=.;Initial Catalog=BlazingChat; Integrated Security=True; Trusted_Connection=True;"
     }
     ``` 
     
- Run the migrations - to update the database using following Package Manager Console Command
    
    `Update-Database`

- Run the solution

- Congratulations, BlazingChat  app is running
---------------------------------------
## Live Coding Video Series of Blazing Chat
> If you want to see this project build with live coding, checkout the detailed video series on my youtube channel
> [Build Realtime Chat App using Blazor WASM and SignalR from Scratch - Live Coding - YouTube](https://www.youtube.com/playlist?list=PLlgYGDJXMjDYOvwKk4UjmvIUB_z055Tkb)

-------------------------------

> If you like my work and want to support me, buy me a coffee https://www.buymeacoffee.com/abhayprince
