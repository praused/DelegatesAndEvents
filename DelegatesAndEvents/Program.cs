﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    class Program
    {
        static void Main(string[] args)
        {
            ////create delegate instance wired to a handler method
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //////invoke delegate to call its handler method
            ////del1(5, WorkType.Golf);
            ////del2(10, WorkType.GenerateReports);

            //////pass delegate instance to a method
            //////DoWork(del1);
            ////DoWork(del1);

            ////add multipe delegates to invocation list of multicast delegate; there are multiple subscribers
            ////del1 += del2;
            ////del1 += del3;
            //del1 += del2 + del3;

            //////invoke delegate to call its handler methods from its invocation list; there are multiple subscribers
            //int finalHours = del1(10, WorkType.GenerateReports);
            ////finalHours only holds the value returned by the last method invoked
            //Console.WriteLine(finalHours);

            var worker = new Worker();

            ////Attach and an Event Handler to and Event through the Event's Delegate. Adds the Handler to the Delegate's Invokation List.
            //////Explicit syntax...
            ////worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            ////worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
            ////...or equivalent statement using delegate inference. The event declaration reveals the delegate type.
            //worker.WorkPerformed += Worker_WorkPerformed;
            //worker.WorkCompleted += Worker_WorkCompleted;
            //...or use an anonymous method instead of calling a handler method. Lambdas are better though.
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            };
            worker.WorkCompleted += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("Worker is done");
            };

            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();

        }

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}

        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " +e.Hours + " " + e.WorkType);
        //}

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    //invoke passed delegate to call its handler method
        //    del(5, WorkType.GoToMeetings);
        //}

        ////handler method for del1 delegate instance
        //static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        //    return hours + 1;
        //}

        ////handler method for del2 delegate instance
        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        //    return hours + 2;
        //}

        ////handler method for del3 delegate instance
        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        //    return hours + 3;
        //}

    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

}
