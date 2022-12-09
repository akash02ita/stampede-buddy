namespace stampede_buddy
{

    public abstract class BaseEvent
    {

        public BaseEvent()
        {
            EventName = "Superdogs";
            Description = "A totally rad dog show.";
            BriefDescription = "lololol";
            Dates = new string[] { "1", "2", "3" };
            Location = "Midway";
            Type = "event";
            Image = "https://www.amusementsofamerica.com/aoa/midway/images/66L.jpg";
        }

        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? BriefDescription { get; set; }
        public string[]? Dates { get; set; }
        public string? Location { get; set; }
        public string? Type { get; set; }
    }

    public class Event : BaseEvent
    {
        public Event() : base()
        {
        }
    }

    public class ScheduledEvent : Event
    {
        public ScheduledEvent() : base()
        {
            Times = new string[] { "1:00pm, 2:00pm, 3:00pm" };
        }
        public string[]? Times { get; set; }
    }

    public enum ScheduleScreen
    {
        DAY_PICKER,
        EVENT_BROWSER,
        SCHEDULE_PICKER,
        ATTEND,
    }

    public enum AppTab
    {
        EXPLORE,
        SCHEDULE
    }



    /// <summary>
    /// Manages the entire state of the application.
    /// </summary>
    public class AppState
    {

        #region state updates
        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        #endregion



        #region tab management
        public AppTab CurrentTab { get; private set; } = AppTab.EXPLORE;

        public void setTab(AppTab tab)
        {
            CurrentTab = tab;
            NotifyStateChanged();
        }
        #endregion


        #region schedule screen management


        public int SelectedDay {get; private set;}

        public void setSelectedDay(int newDay)
        {
            SelectedDay = newDay;
        }

        public ScheduleScreen CurrentScheduleScreen { get; private set; } = ScheduleScreen.DAY_PICKER;

        public void setScheduleScreen(ScheduleScreen newScreen)
        {
            // need to create a warning step here for when the user tries to go back to the day picker screen
            CurrentScheduleScreen = newScreen;
            NotifyStateChanged();

        }

        public List<Event> Favorites { get; set; } = new List<Event> { };
        public List<ScheduledEvent> Schedule { get; set; } = new List<ScheduledEvent> { };


        public void addToFavorites(Event e)
        {
            Favorites.Add(e);
            NotifyStateChanged();

        }

        public void removeFromFavorites(Event e)
        {
            Favorites.Remove(e);
            NotifyStateChanged();

        }

        public void addToSchedule(ScheduledEvent e)
        {
            Schedule.Add(e);
            NotifyStateChanged();

        }

        public void removeFromSchedule(ScheduledEvent e)
        {
            Schedule.Remove(e);
            NotifyStateChanged();

        }

        public void GoToPreviousScreen()
        { 
            if (CurrentScheduleScreen >= 0)
            {
                CurrentScheduleScreen -= 1;
            }
            NotifyStateChanged();
        }

        public void GoToNextScreen()
        {
            CurrentScheduleScreen += 1;
            Console.WriteLine(CurrentScheduleScreen);
            NotifyStateChanged();
        }

        #endregion


        #region explore screen management

        public bool isDiscoverCollapsed { get; private set; } = false;

        public void ToggleCollapsed()
        {
            isDiscoverCollapsed = !isDiscoverCollapsed;
            NotifyStateChanged();
        }

        #endregion

    }




}
