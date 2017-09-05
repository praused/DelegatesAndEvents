﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //define delegate
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //Call helper method to raise the event
                OnWorkPerformed(i + 1, workType);
            }
            //Call helper method to raise the event
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            ////can raise an event using the Event directly...
            //if (WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}
            //////but VS says this delegate invokation can be simplified
            ////WorkPerformed?.Invoke(hours, workType);

            //...or can raise an event by using the delegate, the event must be cast into its delegate type
            var del = WorkPerformed as WorkPerformedHandler;
            if (del != null)
            {
                del(hours, workType);
            }
            ////but VS says this delegate invokation can be simplified
            //(WorkPerformed as WorkPerformedHandler)?.Invoke(hours, workType);
        }

        protected virtual void OnWorkCompleted()
        {
            ////can raise an event using the Event directly...
            //if (WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}
            //////but VS says this delegate invokation can be simplified
            ////WorkCompleted?.Invoke(this, EventArgs.Empty);

            //...or can raise an event by using the delegate, the event must be cast into its delegate type
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
            ////but VS says this delegate invokation can be simplified
            //(WorkCompleted as EventHandler)?.Invoke(this, EventArgs.Empty);
        }
    }
}
