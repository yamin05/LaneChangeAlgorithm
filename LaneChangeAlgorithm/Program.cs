using System;
using System.Collections;
using System.Collections.Generic;

namespace LaneChangeAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputs = new double[] { 0.01, 0.001, 0.04, 0.09, 0.11, -0.15, 0.06, 0.01, 0.01, 0.001 };

            double eventThresholdPositve = 0.05;
            double eventThresholdNegative = -0.05;

            double safetyThresholdPositive = 0.1;
            double safetyThresholdNegative = -0.1;

            bool isPositiveEventCreated = false;
            bool isNegativeEventCreated = false;

            List<double> eventAccelarations = new List<double>();
            ArrayList events = new ArrayList();

            foreach (double x in inputs)
            {
                //starting with postive values
                if (x > eventThresholdPositve)
                {
                    if (isPositiveEventCreated)
                    {
                        if (x > safetyThresholdPositive)
                        {
                            eventAccelarations.Add(x);
                        }
                    }
                    else if (isNegativeEventCreated)
                    {
                        isNegativeEventCreated = false;
                        eventAccelarations.Add(x);
                        events.Add(eventAccelarations);
                    }
                    else if (!isPositiveEventCreated)
                    {
                        isPositiveEventCreated = true;
                        if (x > safetyThresholdPositive)
                        {
                            eventAccelarations.Add(x);
                        }

                    }
                    else if (!isNegativeEventCreated)
                    {

                    }
                }

                //starting with negative values
                if (x < eventThresholdNegative)
                {
                    if (isNegativeEventCreated)
                    {

                        if (x < safetyThresholdNegative)
                        {
                            eventAccelarations.Add(x);
                        }
                    }
                    else if (isPositiveEventCreated)
                    {
                        isPositiveEventCreated = false;
                        eventAccelarations.Add(x);
                        events.Add(eventAccelarations);
                    }
                    else if (!isNegativeEventCreated)
                    {
                        isNegativeEventCreated = true;
                        if (x < safetyThresholdNegative)
                        {
                            eventAccelarations.Add(x);
                        }
                    }
                    else if (!isPositiveEventCreated)
                    {

                    }

                }
            }

            Console.WriteLine("Total Events: " + events.Count);
            foreach (List<double> xa in events)
            {
                foreach (double xaa in xa)
                {
                    Console.WriteLine(xaa);
                }
            }
            Console.ReadKey();
        }
    }
}
