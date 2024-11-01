# Angstrom Sports Colleague Clock

## Setup
You will need [Visual Studio](https://visualstudio.microsoft.com/vs/community/) or similar IDE  
You will also need the [DotNet 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  

1. Extract the application to your local machine
2. Open the solution with your editor of choice and build
3. Open Test Explorer, One test should be discovered called "ExampleTest"
4. Run "ExampleTest" and if everything is working, the test should pass

The Application project contains the code for the app under test.

The Tests project contains the example integration test of the
app under test using MSTest


## Returning the exercise

Once you've completed the exercise, please clean the solution to remove
build outputs etc.

ZIP the solution folder and email back to us, we will discuss your answers
as part of your interview

## Requirements

As a user working in a remote team  
I want to see the current time in the UK and Canada  
So I know what time it is for my colleagues  

**Acceptance Criteria**

* Must get the current date and time from https://worldtimeapi.org/
* Must display the current time for the UK and Canada
* Date and time must be displayed in the format `Monday 1 January 2023 17:00:00`
* Must display the difference in time between the UK and Canada


## Exercise

This exercise should take around 30m to 45m maximum.

The goal of this exercise is to gain insights into your thought process when
working on quality related tasks, and your knowledge of testability and best
practises. It is not a "LeetCode" style exercise!  Your recommendations, approach
and reasoning are more important than the written code.

**Q1. Do you think the application satisfies the acceptance criteria?  
_*Run the application to see the output, browse the implementation and write
a short summary of why you think the application does / doesn't meet the
acceptance criteria***

_Below I have added comments against each of the acceptance criteria points, and an indication of whether they have_

_"Must get the current date and time from https://worldtimeapi.org/": **FAILED**

The application has failed to meet his acceptance criteria, as it does not get the current date and time for the UK from "https://worldtimeapi.org/", it uses the local machine's system time.
The app does get the current date and time for 'Canada' from the API, so is only partially meeting the acceptance criteria._

_"Must display the current time for the UK and Canada": **FAILED**
A test case where the user's local machine has the system time set to a different time zone to 'UK' will result in the application not returning the correct current date and time for the UK_

_"Date and time must be displayed in the format `Monday 1 January 2023 17:00:00`": **PASSED**_

_"Must display the difference in time between the UK and Canada": **FAILED**
This has failed to meet the acceptance criteria, as there are scenarios where the correct time for the UK will not be displayed (use of local machine system time for UK) which could show an incorrect difference between correct 'UK' and 'Canada' time zones.
There are some major problems with the current acceptance criteria, a lot of essential  information is missing, and would need to be provided by the stakeholder or product owner of this application_

_The acceptance criteria is not clear for "Must display the current time for the UK and Canada"
It does not clearly detail the precise time zone API to use. Both the UK and Canada have no. of time zones APIs. As an e.g. there are 8 different time zone available for Canada
and there is at least couple of them for UK as well (e.g. London, Isle of Man, GB etc)
So while implementation of the story the time zone API to use needs to clarified correctly_

_The acceptance criteria should have more information for "Must display the difference in time between the UK and Canada".
For e.g. what unit the difference should be like min, hour, seconds. Also the difference of time should be in time only regardless of date. i.e. difference in date time or time only.
If the difference is on datetime than it should have extra acceptance criteria to check that time UK is always ahead in time compare to Canada_

**Q2. Refactor the code to be more testable  
*Code does not have to be perfect, what is important here is your thought
process on what makes code testable. Leaving comments with TODO's if you
do not have enough time to refactor a section is perfectly fine***

_Have left the To Do Comment on Program.js_

**Q3. What types of automated tests, and test cases would you write to test
this application?  
*There is a Unit Test project added already with MSTest (feel free to change
if you want), and an example test case in the Tests.cs file to get you started*
*Again, the code does not have to be perfect, we are looking at the tests you
would write for this user story, not their implementation***

_I have updated the possible test case into Test.cs. Though it has been written with
an assumption that required response is Mocked to get the complete coverage as many of the scenarios are not possible
to run by requesting real API server (e.g. data and time in future or other than current time, 500 response, 404 response)

Also there is lots of room to refactor the test code especially to make it more generic and reusable and avoid any dependency. 
I have only implemented the code from test coverage prospectively only.
To proper implement the testing solution I would separate out the mocking services in separate classes by implementing dependency injection in helper class
to switch between Real API endpoint and Mocking Endpoint_
