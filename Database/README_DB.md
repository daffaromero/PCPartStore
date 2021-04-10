#### This folder contains the database tables (SQL files), which you should also download and connect with the SQL connection syntax in the program.
#### Steps:
#### Change this line: SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Daffa Romero\Documents\pcpartsdb.mdf;Integrated Security=True;Connect Timeout=30");
### Change that line in each form (.cs file) which contains that exact line. There should be somewhere around three or four forms with that line.
#### In that line, change the directory: 
### C:\Users\Daffa Romero\Documents\pcpartsdb.mdf
#### and replace it with the location of your own database (.mdf) file.
#### Afterwards, create four new tables and name them exactly like the database file names, i.e. "dbo.ProdTable" or "dbo.BillTable" and copy+paste the T-SQL code into the appropriate T-SQL editor for each table.
#### Do not forget to update the database and hit refresh in the server explorer.
#### The program should work as intended now, with the local database connected.
