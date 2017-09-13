# PushbulletProxy

This is my submission for the "myBBC Coding Test".

The solution has been written in C#, .NET 4.6.1, using Web API 2. I have also utlisied Newtonsoft JSON (https://www.newtonsoft.com/json), and Unity - for dependency injection. As a result, the code should be SOLID, compile and run successfully. This can be acheived by pulling the latest code, and loading the solution file in Visual Studio 2017.

The code is structured such that the elements can be unit tested, but due to time constraints, no unit tests have been included.

I have successfully tested the solution, using Telerik Fiddler (http://www.telerik.com/fiddler), such that it satisfies the following:

Task 1: 

A user can be added by sending a POST request to: http://<DOMAIN>/api/pushbulletproxy/users
using the format of the JSON provided in the task:
  
{
  "username": "bbcUser1",
  "accessToken": "YOUR ACCESS TOKEN"
}

It should be noted all users added will only be available for the uptime of the server. The users collection is held in memory, as a list. Users must have a non-empty username, and an accessToken that matches a whitelisted collection of accessTokens (and by implication, be noy empty).

Task 2:

The collection of current users can be retrieved by submitting a GET request to: http://<DOMAIN>/api/pushbulletproxy/users
This should publish a JSON collection of users such:

[
{
"username": "bbcUser1",
"accessToken": "anAccessToken",
“creationTime”: “2011-02-01T10:30:20”,
“numOfNotificationsPushed”: 0
}
...
]

Task 3: 

A notification can be sent to a user, through pushbullet, by submitting a POST request to: http://<DOMAIN>/api/pushbulletproxy/send
The body must take the form:
  
{
  "username": "bbcUser1"
}
