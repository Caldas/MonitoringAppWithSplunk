# MonitoringAppWithSplunk
Sample C# MVC application used to demonstrate how is possible to monitore application using Splunk

## Project

This is a small C# project that log when a new or returning user render the page and also log when user call rename button.
![image](https://user-images.githubusercontent.com/938045/65654156-3a030e00-dfee-11e9-88fe-af105fd3dabd.png)

## EventType

4 eventtypes were create: `newuser`, `olduser`, `renamed`, `request`

![image](https://user-images.githubusercontent.com/938045/65653820-fcea4c00-dfec-11e9-8b93-839ff52d5a87.png)

## Dashboard Sample

Here is the dashboard sample used to demonstrate user usage and iteraction

![image](https://user-images.githubusercontent.com/938045/65653678-83525e00-dfec-11e9-946f-88668f6452d3.png)

### Count - Total Requests
Count all Asp .Net requests logs

### Request Time - Average (miliseconds)
Get average time in miliseconds to all requests

### Count Page Rendering - New Users
Count amount of new users that are rendering the page

### Count Page Rendering - Returning Users
Count amount of returning users that are rendering the page

### Count Page Rendering - Renamed Users
Count amount of users that called renamed function

### Status Code - Over time
Count requests by status code
