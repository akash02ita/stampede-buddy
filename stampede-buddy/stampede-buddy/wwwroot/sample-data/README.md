# Events.json
Regarding the section for Schedule where user

    1. picks a date
    2. browses list of events
    3. gets generated schedule

events.json hardcoded data may be used.
## api description:
- **eventName**: as it says the name of the event
- **description**: a full detailed description of event. This is when user wants to, let's say, click a card and see more information about the event.
- **brief-description**: when user scrolls through cards each card should give a brief one line description. So should consist of just a few words.
- **location**: the location in stampede of the event
- **dates**: the list of dates (based on days of july month)

## assumptions
- stampede always occurs in july so dates we just put "int" number that represent day of month of july

- there are 2 main ideas we have for events.json file
  1. either use key = date and that key stores list of evnets
  2. either use key = event and event stores list of dates

  We decided to use option 2.

