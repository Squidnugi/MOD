# WindowsFormsApp6

This a tutorial on how to instal the needed SQL server
first, you add a new item by doing Project>Add New Item

Then you create a server-based database.
![image](https://github.com/Squidnugi/MOD/assets/77162027/c6be80b2-130b-4a87-883a-a1b51a7bf063)

after the database is created in Server Explorer and right click tables and Click Add New Table
![image](https://github.com/Squidnugi/MOD/assets/77162027/8f081a0c-061b-40fb-b8c1-a0de5b34f77f)

copy and paste this into the query:

CREATE TABLE [dbo].[tbl_users]
(
	[Id] INT NOT NULL IDENTITY, 
    [username] NCHAR(50) NULL, 
    [password] NCHAR(50) NULL, 
    [ReactScore] INT NULL, 
    [AimScore] INT NULL, 
    CONSTRAINT [PK_tbl_users] PRIMARY KEY ([Id])
)

and it should look like the img below and once it looks right click update
![image](https://github.com/Squidnugi/MOD/assets/77162027/ad908b6d-165a-4998-b12b-9c501f3e81ac)

after the table have been updated go to the database in Server Explorer and go it its properties where you will find the Connection String and copy it
![image](https://github.com/Squidnugi/MOD/assets/77162027/d751f7d2-ec02-4c70-bc3f-b6274208bb22)

paste the path into where it says Data Source. Each location can be seen below
![image](https://github.com/Squidnugi/MOD/assets/77162027/0397108d-12ab-43d7-8f6a-105f2454f4ac)
![image](https://github.com/Squidnugi/MOD/assets/77162027/425203e2-5d81-4c9a-97ca-8ed762b2ef4d)
![image](https://github.com/Squidnugi/MOD/assets/77162027/35bd35bf-4f86-41f6-8614-198434738d2f)
![image](https://github.com/Squidnugi/MOD/assets/77162027/7275adb1-29ab-4522-954f-7ab241c7b518)
The 4 forms it should be in are frmReaction, frmLogin, Form1, and frmAim
