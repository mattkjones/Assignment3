using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class TempStorage
    {
        private static List<Films> movielist = new List<Films>();

        public static IEnumerable<Films> MovieList = movielist;

        public static void AddMovie(Films movie)
        {
            movielist.Add(movie);
        }
    }
}
