# TestTask_Nova

[![build and test](https://github.com/olnichenko/TestTask_Nova/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/olnichenko/TestTask_Nova/actions/workflows/build-and-test.yml)

Requirements:
- Visual studio 2022 (The test task indicates version 2019, but I don't have it. if it's critical, I'll work on it)
- Node js
  
I tested this on:
- Windows 11
- Visual studio 2022
- node version v20.10.0
- npm version 10.2.3
- Angular CLI version 17.0.6

![Screenshot_2](https://github.com/olnichenko/TestTask_Nova/assets/2253261/cdb66fc1-5ed1-4a84-a2a9-d54d2b760fe4)

Launching the application Backend:
- open file "./TestTask_Nova/InnovaLab_TestTask.sln" in visual studio 2022
- press F5
  
Launching the application Front end:
- open a command prompt in the folder "./TestTask_Nova/innovaLab_angularApp"
- run command "npm install"
- run command "npm start"
- navigate in browser to "http://localhost:4200/"

Instructions for the application:
- After launch you will see a list of countries
- ![Screenshot 2023-12-10 144529](https://github.com/olnichenko/TestTask_Nova/assets/2253261/537d124b-597a-4f57-b3b1-8d06d4c9ffea)
- The Currencies and Languages columns have a tooltip when hovering over a cell.
- Clicking on the Name cell will take you to the detailed information page
- ![Screenshot_3](https://github.com/olnichenko/TestTask_Nova/assets/2253261/fa0c3161-6bf3-49cc-b667-3d5039605611)

How it works:
- When the list of countries is loaded, the browser cache is accessed
- ![Screenshot_4](https://github.com/olnichenko/TestTask_Nova/assets/2253261/683ea80f-c635-44ea-bbc7-12b86f57b415)
- Then a request is sent to the server
- The server requests data in the cache
- ![Screenshot_5](https://github.com/olnichenko/TestTask_Nova/assets/2253261/0aa210d9-6421-4278-9da9-88227ecd82f0)
- If there is no data in the cache, the server requests data from the remote service

Tests are in the project UnitTests and also there is a test indicator in this readme file
![Screenshot_6](https://github.com/olnichenko/TestTask_Nova/assets/2253261/53e39c8b-6d20-4e59-8a9d-74aae43a33d3)

What would I change if this was a real project?
- Write integration test
- Write test for front
- Add sorting and pagination for countries list
- Logging and exception handling, now it's easy
- ![Screenshot_8](https://github.com/olnichenko/TestTask_Nova/assets/2253261/1d89a62b-5407-4dc7-ada0-6fac3aca4d8a)
- I would add docker support for projects
- I would create separate containers for cache, api, logger...
- Add Logging for client application/
