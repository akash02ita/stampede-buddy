# Stampede Buddy: the Stampede Companion app!

## Authors:


| Name            | Email                        |
|-----------------|------------------------------|
| Dylan Leclair   | dylan.leclair1@ucalgary.ca   |
| Cameron Hermann | cam.hermann1@ucalgary.ca     |
| Akashdeep Singh | akashdeep.singh4@ucalgary.ca |
| Braden Foxcroft | braden.foxcroft@ucalgary.ca  |
| Shabnam Kaur    | shabnamjit.kaur@ucalgary.ca  |


## Our demo video

https://www.youtube.com/watch?v=vUzn0Ieu7CY

## Our deployed live link

https://stampede-buddy.netlify.app/

## Running the Project

Our project is Blazor WebAssembly Project, which was started and developed in Visual Studio 2022. 

You can run it by opening up: 

[https://github.com/dylanleclair/stampede-buddy/blob/main/stampede-buddy/stampede-buddy.sln](stampede-buddy/stampede-buddy.sln) in Visual Studio 2022. From there, launch the project with either the debug or release profile and it should just work. 

Most of the features actually do work:
* All of the search menus use a search algorithm that considers event location, name and so on. 
* Filtering is done based on event type. 
* There do exist some Sample Rides / Events / Foods that we made mostly to get a better idea of how our system scaled. 
* Our schedule generation algorithm is not a true implementation, since we wanted to focus more on other parts of the UI. It will randomly scramble scheduled events into timeslots. 
* **To trigger the timeslot warning screen**, the easiest way is to simply add two Sample Events to your schedule in the Event Browser. 
* You should try stepping through the whole scheduling workflow at least once, by:
  * selecting only "Add to Schedule" in the Event Browser
  * selecting only "Add to Favorites" in the Event Browser
  * each of these have a special case in the attend screen that will prompt you to return to the Event Browser! 
* if in the Schedule Tab, you can select one of the red numbers at the very top to jump to a previous step in the workflow.
  * there are also back buttons if you prefer. 
  * *jumping back to previous steps is the only way to edit your schedule/favorites.*
* none of the map features were implemented in this prototype, since they were deemed too labor intensive and we figured it would be worthwhile to iterate on our prototype some more before committing so much time to this task. 


Other than pressing some buttons, our UI is really light on user input so you should hopefully be able to get a good feel for it just from navigating around! We didn't really program set paths for you to follow in. 

One last thing: *refreshing resets the state of the app. this is not how our app would work when deployed (it would persist on the users device or in the cloud), but we kept the refresh to clear it in case of any issues & to make testing various states easier.* 

If you have any issues getting our project running, please shoot me an email! I disabled the web compiler we were using for custom SASS, so you should be able to run it like any other Blazor project. VS2022 might be required.  

Here we go!

## Publishing command for setting up deployment

In directory `./stampede-buddy/stampede-buddy` execute following command:
-  `dotnet publish -c ../../../Release`

`./Release/net6.0/publish/wwwroot` or similar, is the directory to host website.
We currently decided to copy the contents of this path to `./dist` directory to be deployed on netlify.
