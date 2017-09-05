﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    //define delegate
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Program
    {
        static void Main(string[] args)
        {
            //create delegate instance wired to a handler method
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            ////invoke delegate to call its handler method
            //del1(5, WorkType.Golf);
            //del2(10, WorkType.GenerateReports);

            ////pass delegate instance to a method
            ////DoWork(del1);
            //DoWork(del1);

            //add multipe delegates to invocation list of multicast delegate; there are multiple subscribers
            //del1 += del2;
            //del1 += del3;
            del1 += del2 + del3;

            ////invoke delegate to call its handler methods from its invocation list; there are multiple subscribers
            int finalHours = del1(10, WorkType.GenerateReports);
            //finalHours only holds the value returned by the last method invoked
            Console.WriteLine(finalHours);

            Console.Read();

        }

        static void DoWork(WorkPerformedHandler del)
        {
            //invoke passed delegate to call its handler method
            del(5, WorkType.GoToMeetings);
        }

        //handler method for del1 delegate instance
        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called " + hours.ToString());
            return hours + 1;
        }

        //handler method for del2 delegate instance
        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + hours.ToString());
            return hours + 2;
        }

        //handler method for del3 delegate instance
        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 called " + hours.ToString());
            return hours + 3;
        }

    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

}
