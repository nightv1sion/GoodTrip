# ASP.NET CORE 6 MVC Application is a project on the subject "OOP" 
http://nightv1sion-001-site1.ctempurl.com

To test the project you can go to the link above, but I recommend to follow instruction at the end of description.
#

**goodtrip is a platform that allows:**
- Tour operators to post their tours
- Tourists buy these tours

# How work with this application
- click on login button or search button (non-authorized users can look for toors but can't order and comment)

For a quick overview you can use: 
'operatorEngland@1' username and 'operatorEngland@1' password (tour operator account);

'customer' username and 'Qwerty123$' password (customer account)
- sign up, then sign in (if you choose customer type of account you'll be able to order, operator - you'll be able to create your own tours)
- now you can go to profile (customers can fill personal info and check sended requests to operators, operators can create tours, fill in personal info, created tours and check incoming requests)
- after authorization customer can order and comment tours, operator can create tours and receive requests
- request is info about date of creation, status and tour link (operator can reject or apply tour, after that status of request will change)

**ER-diagram for a database:**
![image](https://user-images.githubusercontent.com/92179208/169150496-79128102-82ed-413a-8c58-7836f40f946f.png)

# To run the project you need
- pull this project to your local repository
- open command line in project folder
- write `dotnet ef migrations add "MigrationName"` and `dotnet ef database update`
- download sql script with database dump https://drive.google.com/file/d/1rm1-i3t21VsOOWG-5h77SG9usiCY9oFk/
- open SQL Server Management Studio and create a query to GoodTripDatabase with this sql script and run it
- run the project and enjoy!
