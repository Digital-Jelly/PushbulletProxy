# PushbulletProxy

This is my submission for the "myBBC Coding Test".

The solution has been written in C#, .NET 4.6.1, using Web API 2. I have also utlisied Newtonsoft JSON (https://www.newtonsoft.com/json), and Unity - for dependency injection. As a result, the code should be SOLID, compile and run successfully. This can be acheived by pulling the latest code, and loading the solution file in Visual Studio 2017, or utilising the urls below (hosted on Azure Cloud).

The code is structured such that the elements can be unit tested, but due to time constraints, no unit tests have been included.

I have successfully tested the solution, using Telerik Fiddler (http://www.telerik.com/fiddler), such that it satisfies the following:

Task 1: 

A user can be added by sending a POST request to: 

http://pushbulletproxy.azurewebsites.net/api/pushbulletproxy/users

using the format of the JSON provided in the task:
  
{
  "username": "YOUR USERNAME",
  "accessToken": "YOUR ACCESS TOKEN"
}

It should be noted all users added will only be available for the uptime of the server. The users collection is held in memory, as a list. Users must have a non-empty username, must not have a duplicate username, and an accessToken that is not empty.

A successful 200 response code should be returned, if the user was added successfully.

Task 2:

The collection of current users can be retrieved by submitting a GET request to: 

http://pushbulletproxy.azurewebsites.net/api/pushbulletproxy/users

This should publish a JSON collection of users such:

[
{
"username": "YOUR USERNAME",
"accessToken": "YOUR ACCESSTOKEN",
“creationTime”: “2011-02-01T10:30:20”,
“numOfNotificationsPushed”: 0
}
...
]

Task 3: 

A notification can be sent to a user, through pushbullet, by submitting a POST request to: 

http://pushbulletproxy.azurewebsites.net/api/pushbulletproxy/notifications

The body must take the form:
  
{
  "username": "YOUR USERNAME",
  "title" : "YOUR TITLE",
  "body" : "YOUR MESSAGE"
}

If no title or body is defined (empty message), then a default is added. This can be changed, obviously.

A successful 200 response code should be returned, if the message was sent successfully. If a username is given that doesn't match a registered user then a 400 is returned.
