using System;
using System.Collections.Generic;

namespace MyCalendar2
{
    /*
     *
     *
     *Intuition
       
       Maintain a list of bookings and a list of double bookings. 
       When booking a new event [start, end), if it conflicts with a double booking, 
       it will have a triple booking and be invalid. 
       Otherwise, parts that overlap the calendar will be a double booking.
       
       Algorithm
       
       Evidently, two events [s1, e1) and [s2, e2) do not conflict if and only if 
       one of them starts after the other one ends: either e1 <= s2 OR e2 <= s1. 
       By De Morgan's laws, this means the events conflict when s1 < e2 AND s2 < e1.
       
       If our event conflicts with a double booking, it's invalid. Otherwise, 
       we add conflicts with the calendar to our double bookings, and add the event to our calendar.
     *
     */
    public class MyCalendar
    {
        private readonly List<int[]> _calendar;
        private readonly List<int[]> _overlaps;

        public MyCalendar()
        {
            _calendar = new List<int[]>();
            _overlaps = new List<int[]>();
        }

        public bool Book(int start, int end)
        {
            foreach (var iv in _overlaps)
                if (iv[0] < end && start < iv[1])
                    return false;

            foreach (var iv in _calendar)
            {
                if (iv[0] < end && start < iv[1])
                {
                    _overlaps.Add(new[] {Math.Max(start, iv[0]),
                        Math.Min(end, iv[1])});
                }
            }

            _calendar.Add(new[] {start, end});
            return true;
        }
    }
}