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
            // filters by whether the item matches the query.
            // Sorts by how well it matches the query.
            List<BaseEvent>? result = allEvents?.Where(x => MatchScore(x,searchPhrase) > 0).ToList();
            // Sort by count
            result = result?.OrderBy(x => -MatchScore(x,searchPhrase)).ToList();
            return result;
        }

        /// <summary>
        /// Checks how many times the string appears in the event description.
        /// </summary>
        /// <param name="e">the event to check</param>
        /// <param name="sp">the search query</param>
        /// <returns>true if there is a match, false otherwise.</returns>
        private static int MatchScore(BaseEvent e, String sp)
        {
            // Handle cases where anything is null.
            if (sp == null) return 0;
            if (e == null) return 0;
            if (e.EventName == null) return 0;
            if (e.BriefDescription == null) return 0;
            if (e.Location == null) return 0;
            if (e.Description== null) return 0;

            // Handle possible matches
            int score = 0;
            score += CountInStr(e.EventName, sp) * 10; // event name matches get higher priority.
            score += CountInStr(e.Location, sp) * 10; // location matches get higher priority.
            score += CountInStr(e.BriefDescription, sp);
            score += CountInStr(e.Description, sp);
            
            return score;
        }

        private static int CountInStr(String haystack, String needle)
        {
            String hs = haystack.ToLower();
            String nd = needle.ToLower();
            int count = 0;
            int pos = 0;
            while(hs.IndexOf(nd,pos) >= 0)
            {
                pos = hs.IndexOf(nd, pos) + 1;
                count++;
            }
            return count;
        }
}
}
