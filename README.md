# HackerNews

Steps to run application

1. Set both the projects as statup projects.
2. To to get access token call api with url:
   https://localhost:44379/api/Identity
3. To access swagger UI url is :
  https://localhost:44379/swagger/index.html
  
  Due to time limitation I was not able add authentication to swagger in order excecute api's.
  
4. API Urls are as follow:

  4.1 https://localhost:44379/api/HackerNews to get all new and top stories default is 100 stories.
  4.2 https://localhost:44379/api/HackerNews?pageNumber=1&pageSize=20 for pagination.
  4.3 https://localhost:44379/api/HackerNews/{id} to get single record. 
