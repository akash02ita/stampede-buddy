using System.Globalization;
using System.Text.RegularExpressions;

namespace stampede_buddy
{
    public class SimpleSearch
{
        /// <summary>
        /// So that you don't try and instantiate it.
        /// </summary>
        private SimpleSearch() { }


        /// <summary>
        /// Takes a list of events and a string search phrase, returns a list of valid events.
        /// </summary>
        /// <param name="allEvents">The list of events</param>
        /// <param name="searchPhrase">The search phrase</param>
        /// <returns>The list of valid results</returns>
        public static List<BaseEvent>? search(List<BaseEvent>? allEvents, String searchPhrase)
        {
            // filters by whether the item matches the query. simple and clean.
            List<BaseEvent>? result = allEvents?.Where(x => match(x,searchPhrase)).ToList();
            return result;
        }

        /// <summary>
        /// Checks if an item matches a search query
        /// </summary>
        /// <param name="e">the event to check</param>
        /// <param name="sp">the search query</param>
        /// <returns>true if there is a match, false otherwise.</returns>
        private static bool match(BaseEvent e, String sp)
        {
            // Handle cases where anything is null.
            if (sp == null) return false;
            if (e == null) return false;
            if (e.EventName == null) return false;
            if (e.BriefDescription == null) return false;
            if (e.Location == null) return false;
            if (e.Description== null) return false;

            // Handle possible matches.
            // I'm looking for possible matches only, cuz I'm lazy.
            if (inStr(e.EventName,sp)) return true;
            if (inStr(e.BriefDescription,sp)) return true;
            if (inStr(e.Location,sp)) return true;
            if (inStr(e.Description,sp)) return true;

            // No match found.
            return false;
        }

        /// <summary>
        /// Checks if a string is in another string, in a case-insensitive way.
        /// </summary>
        /// <param name="haystack">The string to search</param>
        /// <param name="needle">The string to look for</param>
        /// <returns>True, if the needle is in the haystack</returns>
        private static bool inStr(String haystack, String needle)
        {
            return haystack.ToLower().Contains(needle.ToLower());
        }
}
}
