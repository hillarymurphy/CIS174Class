using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Areas.Agile.Models
{
    public class PointCheck
    {
        public static string PointValid(TicketContext ctx, int Point)
        {
            string msg = "";
            List<int> PointList = new List<int>() { 0, 1, 2, 3, 5, 8, 12 };
            if (!PointList.Contains(Point))
            {
                msg = $"Point value of {Point} is not valid. Must be 0, 1, 2, 3, 5, 8, or 12.";
            }
            return msg;
        }
    }
}
