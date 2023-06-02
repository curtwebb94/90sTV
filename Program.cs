using System;
using System.Collections.Generic;
using System.Linq;

namespace NinetiesTV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Show> shows = DataLoader.GetShows();

            Print("All Names", Names(shows));
            Print("Alphabetical Names", NamesAlphabetically(shows));
            Print("Ordered by Popularity", ShowsByPopularity(shows));
            Print("Shows with an '&'", ShowsWithAmpersand(shows));
            Print("Latest year a show aired", MostRecentYear(shows));
            Print("Average Rating", AverageRating(shows));
            Print("Shows only aired in the 90s", OnlyInNineties(shows));
            Print("Top Three Shows", TopThreeByRating(shows));
            Print("Shows starting with 'The'", TheShows(shows));
            Print("All But the Worst", AllButWorst(shows));
            Print("Shows with Few Episodes", FewEpisodes(shows));
            Print("Shows Sorted By Duration", ShowsByDuration(shows));
            Print("Comedies Sorted By Rating", ComediesByRating(shows));
            Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
            Print("Most Episodes", MostEpisodes(shows));
            Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
            Print("Best Drama", BestDrama(shows));
            Print("All But Best Drama", AllButBestDrama(shows));
            Print("Good Crime Shows", GoodCrimeShows(shows));
            Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
            Print("Most Words in Title", WordieastName(shows));
            Print("All Names", AllNamesWithCommas(shows));
            Print("All Names with And", AllNamesWithCommasPlsAnd(shows));
            Print("Genre of Shows Starting in the 80s", GenresOfShowsIn80s(shows));
            Print("Unique Genres", GetUniqueGenres(shows));
            Print("Total Watch Time", TotalWatchTime(shows).ToString());
            Print("Year With Highest Average Rating", YearWithHighestAverageRating(shows));
        }

        /**************************************************************************************************
         The Exercises

         Above each method listed below, you'll find a comment that describes what the method should do.
         Your task is to write the appropriate LINQ code to make each method return the correct result.

        **************************************************************************************************/

        // 1. Return a list of each of show names.
        static List<string> Names(List<Show> shows)
        {
            return shows.Select(s => s.Name).ToList(); // Extracts the name of each show and returns it as a list
        }

        // 2. Return a list of show names ordered alphabetically.
        static List<string> NamesAlphabetically(List<Show> shows)
        {
            return shows.Select(s => s.Name).OrderBy(name => name).ToList(); // Extracts the name of each show, orders them alphabetically, and returns as a list
        }

        // 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
        static List<Show> ShowsByPopularity(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating).ToList(); // Orders the shows by their IMDB rating in descending order and returns as a list
        }

        // 4. Return a list of shows whose title contains an & character.
        static List<Show> ShowsWithAmpersand(List<Show> shows)
        {
            return shows.Where(s => s.Name.Contains("&")).ToList(); // Filters the shows to include only those whose title contains an '&' character and returns as a list
        }

        // 5. Return the most recent year that any of the shows aired.
        static int MostRecentYear(List<Show> shows)
        {
            return shows.Max(s => s.EndYear); // Returns the maximum value of the 'EndYear' property among all shows
        }

        // 6. Return the average IMDB rating for all the shows.
        static double AverageRating(List<Show> shows)
        {
            return shows.Select(s => s.ImdbRating).Average(); // Calculates the average of the IMDB ratings for all shows
        }

        // 7. Return the shows that started and ended in the 90s.
        static List<Show> OnlyInNineties(List<Show> shows)
        {
            return shows.Where(s => s.StartYear >= 1990 && s.EndYear <= 1999).ToList(); // Filters the shows to include only those that started and ended within the 90s decade and returns as a list
        }

        // 8. Return the top three highest rated shows.
        static List<Show> TopThreeByRating(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating).Take(3).ToList(); // Orders the shows by their IMDB rating in descending order, takes the top three, and returns as a list
        }

        // 9. Return the shows whose name starts with the word "The".
        static List<Show> TheShows(List<Show> shows)
        {
            return shows.Where(s => s.Name.StartsWith("The ", StringComparison.OrdinalIgnoreCase)).ToList(); // Filters the shows to include only those whose name starts with "The" (case-insensitive) and returns as a list
        }

        // 10. Return all shows except for the lowest rated show.
        static List<Show> AllButWorst(List<Show> shows)
        {
            var lowestRating = shows.Min(s => s.ImdbRating); // Finds the minimum IMDB rating among all shows
            return shows.Where(s => s.ImdbRating > lowestRating).ToList(); // Filters the shows to exclude the one with the lowest rating and returns as a list
        }

        // 11. Return the names of the shows that had fewer than 100 episodes.
        static List<string> FewEpisodes(List<Show> shows)
        {
            return shows.Where(s => s.EpisodeCount < 100).Select(s => s.Name).ToList(); // Filters the shows to include only those with fewer than 100 episodes, extracts their names, and returns as a list
        }

        // 12. Return all shows ordered by the number of years on air.
        // Assume the number of years between the start and end years is the number of years the show was on.
        static List<Show> ShowsByDuration(List<Show> shows)
        {
            return shows.OrderBy(s => s.EndYear - s.StartYear).ToList(); // Orders the shows by the duration (end year minus start year) in ascending order and returns as a list
        }

        // 13. Return the names of the comedy shows sorted by IMDB rating.
        static List<string> ComediesByRating(List<Show> shows)
        {
            return shows.Where(s => s.Genres.Contains("Comedy")).OrderByDescending(s => s.ImdbRating).Select(s => s.Name).ToList(); // Filters the shows to include only comedies, orders them by IMDB rating in descending order, extracts their names, and returns as a list
        }

        // 14. Return the shows with more than one genre ordered by their starting year.
        static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
        {
            return shows.Where(s => s.Genres.Count > 1).OrderBy(s => s.StartYear).ToList(); // Filters the shows to include only those with more than one genre, orders them by starting year in ascending order, and returns as a list
        }

        // 15. Return the show with the most episodes.
        static Show MostEpisodes(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.EpisodeCount).FirstOrDefault(); // Orders the shows by the number of episodes in descending order and returns the first (top) show or null if the list is empty
        }

        // 16. Order the shows by their ending year then return the first show that ended on or after the year 2000.
        static Show EndedFirstAfterTheMillennium(List<Show> shows)
        {
            return shows.OrderBy(s => s.EndYear).FirstOrDefault(s => s.EndYear >= 2000); // Orders the shows by the ending year in ascending order and returns the first (top) show that ended on or after the year 2000, or null if no such show exists
        }

        // 17. Order the shows by rating (highest first) and return the first show with the genre of drama.
        static Show BestDrama(List<Show> shows)
        {
            return shows.Where(s => s.Genres.Contains("Drama")).OrderByDescending(s => s.ImdbRating).FirstOrDefault(); // Filters the shows to include only those with the genre of drama, orders them by IMDB rating in descending order, and returns the first (top) show or null if no such show exists
        }

        // 18. Return all dramas except for the highest rated.
        static List<Show> AllButBestDrama(List<Show> shows)
        {
            var highestDramaRating = shows.Where(s => s.Genres.Contains("Drama")).Max(s => s.ImdbRating); // Finds the maximum IMDB rating among dramas
            return shows.Where(s => s.Genres.Contains("Drama") && s.ImdbRating < highestDramaRating).ToList(); // Filters the shows to include only dramas with a rating lower than the highest drama rating and returns as a list
        }

        // 19. Return the number of crime shows with an IMDB rating greater than 7.0.
        static int GoodCrimeShows(List<Show> shows)
        {
            return shows.Count(s => s.Genres.Contains("Crime") && s.ImdbRating > 7.0); // Counts the shows that have the genre of crime and an IMDB rating greater than 7.0
        }

        // 20. Return the first show that ran for more than 10 years with an IMDB rating of less than 8.0, ordered alphabetically.
        static Show FirstLongRunningTopRated(List<Show> shows)
        {
            return shows.Where(s => s.EndYear - s.StartYear > 10 && s.ImdbRating < 8.0)
                        .OrderBy(s => s.Name)
                        .FirstOrDefault(); // Filters the shows to include only those that ran for more than 10 years and have an IMDB rating less than 8.0, orders them alphabetically by name, and returns the first (top) show or null if no such show exists
        }

        // 21. Return the show with the most words in the name.
        static Show WordieastName(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.Name.Split(' ').Length).FirstOrDefault(); // Orders the shows by the number of words in the name in descending order and returns the first (top) show or null if the list is empty
        }

        // 22. Return the names of all shows as a single string separated by a comma and a space.
        static string AllNamesWithCommas(List<Show> shows)
        {
            return string.Join(", ", shows.Select(s => s.Name)); // Concatenates the names of all shows into a single string separated by a comma and a space
        }

        // 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
        static string AllNamesWithCommasPlsAnd(List<Show> shows)
        {
            int count = shows.Count;
            if (count <= 1)
                return string.Join(", ", shows.Select(s => s.Name)); // If there is only one show or the list is empty, concatenate the names as before

            return string.Join(", ", shows.Select((s, index) => index == count - 2 ? s.Name + " and" : s.Name)); // Concatenates the names of all shows into a single string separated by a comma and a space, but replaces the comma before the last name with the word "and"
        }


        /**************************************************************************************************
         CHALLENGES

         These challenges are very difficult and may require you to research LINQ methods that we haven't
         talked about. Such as:

            GroupBy()
            SelectMany()
            Count()

        **************************************************************************************************/

        // 1. Return the genres of the shows that started in the 80s.
        static List<string> GenresOfShowsIn80s(List<Show> shows)
        {
            return shows
                .Where(s => s.StartYear >= 1980 && s.StartYear <= 1989)  // Filter shows that started in the 80s
                .SelectMany(s => s.Genres)  // Flatten the genres of the shows into a single list
                .Distinct()  // Remove any duplicate genres
                .ToList();  // Convert the result to a list and return it
        }

        // 2. Print a unique list of genres.
        static List<string> GetUniqueGenres(List<Show> shows)
        {
            List<string> uniqueGenres = shows
                .SelectMany(s => s.Genres)  // Flatten the genres of all shows into a single list
                .Distinct()  // Remove any duplicate genres
                .ToList();  // Convert the result to a list and return it

            return uniqueGenres;
        }

        // 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
        // 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
        static TimeSpan TotalWatchTime(List<Show> shows)
        {
            TimeSpan totalDuration = TimeSpan.Zero;  // Initialize the total duration as zero

            foreach (Show show in shows)  // Iterate over each show in the list
            {
                int episodeDuration = (show.Genres.Contains("Comedy")) ? 22 : 42;  // Set episode duration based on the genre
                int episodeCount = show.EpisodeCount;  // Get the episode count of the show

                TimeSpan showDuration = TimeSpan.FromMinutes(episodeDuration * episodeCount);  // Calculate the duration of the show
                totalDuration += showDuration;  // Add the show's duration to the total duration
            }

            return totalDuration;  // Return the total watch time as a TimeSpan
        }

        // 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.
        static int YearWithHighestAverageRating(List<Show> shows)
        {
            int highestYear = 0;  // Initialize the highest year as zero
            double highestAverageRating = 0;  // Initialize the highest average rating as zero

            for (int year = 1987; year <= 2018; year++)  // Iterate over the years 1987 - 2018
            {
                List<Show> showsInYear = shows.Where(s => year >= s.StartYear && year <= s.EndYear).ToList();  // Filter shows that ran in the current year

                if (showsInYear.Count > 0)  // Check if there are shows in the current year
                {
                    double averageRating = showsInYear.Average(s => s.ImdbRating);  // Calculate the average IMDB rating of the shows in the current year

                    if (averageRating > highestAverageRating)  // Check if the average rating is higher than the current highest average rating
                    {
                        highestAverageRating = averageRating;  // Update the highest average rating
                        highestYear = year;  // Update the highest year
                    }
                }
            }

            return highestYear;  // Return the year with the highest average IMDB rating

        }




        /**************************************************************************************************
         There is no code to write or change below this line, but you might want to read it.
        **************************************************************************************************/

        static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);  // Print the header text with the specified title
            foreach (Show show in shows)
            {
                Console.WriteLine(show);  // Print each show object
            }

            Console.WriteLine();  // Print an empty line
        }

        static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);  // Print the header text with the specified title
            foreach (string str in strings)
            {
                Console.WriteLine(str);  // Print each string in the list
            }

            Console.WriteLine();  // Print an empty line
        }

        static void Print(string title, Show show)
        {
            PrintHeaderText(title);  // Print the header text with the specified title
            Console.WriteLine(show);  // Print the show object

            Console.WriteLine();  // Print an empty line
        }

        static void Print(string title, string str)
        {
            PrintHeaderText(title);  // Print the header text with the specified title
            Console.WriteLine(str);  // Print the string

            Console.WriteLine();  // Print an empty line
        }

        static void Print(string title, int number)
        {
            PrintHeaderText(title);  // Print the header text with the specified title
            Console.WriteLine(number);  // Print the number

            Console.WriteLine();  // Print an empty line
        }

        static void Print(string title, double number)
        {
            PrintHeaderText(title);  // Print the header text with the specified title
            Console.WriteLine(number);  // Print the number

            Console.WriteLine();  // Print an empty line
        }

        static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);  // Print the title
            Console.WriteLine("--------------------------------------------");
        }

    }
}