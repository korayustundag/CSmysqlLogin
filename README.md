
# CSmysqlLogin
MySQL database connection and user operations with C#.
## Requirements
- [Apache for Windows](https://httpd.apache.org/docs/2.4/platform/windows.html)
- [MySQL for Windows](https://dev.mysql.com/downloads/installer/)
- [phpMyAdmin (Optional)](https://www.phpmyadmin.net/downloads/)
- [XAMPP (Recommended but Optional)](https://www.apachefriends.org/download.html)

> If you install XAMPP software, it comes with Apache, MySQL and phpMyAdmin.

- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET Framework 4.6](https://dotnet.microsoft.com/download/dotnet-framework/net46)
- [MySQL :: Connector/NET](https://dev.mysql.com/downloads/connector/net/)
## Installations :: PHP and MySQL Database
1. Import `FULL_DB.sql` file located in the `DATABASE` folder.
2. Put the files in the `PHP` folder to the directory where the local server is running.
3. Edit the `config.php` file according to you.
4. You can log into your local server and experiment.
## Installations :: C#
1. Copy the files in the `CSHARP` file to any location.
2. Open the `CSmysqlLogin.sln` file with Visual Studio.
3. Edit the `ConnectionString` variable in the Settings.cs file according to you.
#### Example:
```
public static readonly string ConnectionString = "server=localhost;user=root;database=mydatabase;port=3306;password=****";
```
> If you change the database name or change the table name, you will need to make changes to all the codes in the project.
4. You can start the project and try it out.
## Security Notes
• The **passwords** in the database are **stored** with the **SHA256** algorithm.
## Developer Notes
This page is not completely finished.  Page update continues.
KORAY ÜSTÜNDAĞ
[LICENSE](https://github.com/korayustundag/CSmysqlLogin/blob/main/LICENSE)
