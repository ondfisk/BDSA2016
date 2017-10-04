﻿using System;

namespace BDSA2016.Lecture06.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Threads.SpawnThread();
            //Threads.SpawnMultipleThreads(1000);
            //Threads.Overlapping();
            //Threads.OverlappingWithArguments();
            //Threads.Join();

            //RaceCondition.Race();
            //FixedRace.Race();
            //BehindTheScenes.Race();

            //Deadlock.Run();
            //Deadlock.RunWithComments();

            //Tasks.TaskFactory();
            //Tasks.Wait();
            //Tasks.WaitAll();
            //Tasks.Attached();
            //Tasks.Continuation();
            //Tasks.Result();
            //Tasks.Cancellation();
            //Tasks.ResultCancelled();
            //Tasks.Fail();

            //TaskParallelLibrary.For();
            //TaskParallelLibrary.ForEach();
            //TaskParallelLibrary.Invoke();

            //ParallelLinq.Run();

            ConcurrentCollections.Race();

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
