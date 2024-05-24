// See https://aka.ms/new-console-template for more information
using System;
using ParsExemple;
using System.Threading.Tasks;
class Program
{
    static List<Task> tasks = new List<Task>();
    static List<int> pages = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55 };
    static int countTasks = pages.Count / 7;
    static async Task Main()
    {
        Console.WriteLine($"Starting tasks");
        Runner runner = new Runner(new List<int> { 1, 2, 3, 4, 5, 6, 7, }, "1.txt");
        Task task = Task.Run(async () => await runner.GoWork());
        tasks.Add(task);

        Runner runner1 = new Runner(new List<int> { 8, 9, 10, 11, 12, 13, 14 }, "2.txt");
        Task task2 = Task.Run(async () => await runner1.GoWork());
        tasks.Add(task2);

        Runner runner3 = new Runner(new List<int> { 15, 16, 17, 18, 19, 20, 21 }, "3.txt");
        Task task3 = Task.Run(async () => await runner3.GoWork());
        tasks.Add(task3);

        foreach (var tas in tasks)
        {
            tas.Wait();
        }
    }
}

