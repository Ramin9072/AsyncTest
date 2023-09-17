﻿internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("**** Start main ****");

        ExecureTask();

        Console.WriteLine("**** END main ****");
        Console.ReadKey();
    }

    public static async Task ExecureTask()
    {
        //RunSyncMasoud();

        var i = MethodAsync();
        var i2 = MethodAsyncLongTimer();

        Console.WriteLine("SOME SYNC");

        await Console.Out.WriteLineAsync($" ------------ MethodAsync {i.Result} ------------");
        await Console.Out.WriteLineAsync($"------------  MethodAsync2 {i2.Result} ------------");
    }

    public static async Task<int> MethodAsync()
    {
        int i = 0;
        await Task.Run(() =>
        {
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine($" MethodAsync => {i.ToString()}");
                Task.Delay(1000).Wait();
            }
        });
        return i;
    }

    public static async Task RunSyncMasoud()
    {
        int i = 0, j = 0;
        var task1 = Task.Run(() =>
        {
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine($" MethodAsync => {i.ToString()}");
                Task.Delay(1000).Wait();
            }
        });
        var task2 = Task.Run(() =>
        {
            for (j = 0; j < 10; j++)
            {
                Console.WriteLine($" MethodAsync => {j.ToString()}");
                Task.Delay(1000).Wait();
            }
        });
        var result = Task.WhenAll(task1, task2);
        if (result.IsCompleted)
        {
            Console.WriteLine("SOME SYNC");

            await Console.Out.WriteLineAsync($" ------------ MethodAsync {i} ------------");
            await Console.Out.WriteLineAsync($"------------  MethodAsync2 {j} ------------");
        }
    }


    public static async Task<int> MethodAsyncLongTimer()
    {
        int i = 0;
        await Task.Run(() =>
        {
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine($" MethodAsyncLongTimer => {i.ToString()}");
                Task.Delay(2000).Wait();
            }
        });
        return i;
    }

    public static int MethodSync()
    {
        int i = 0;
        for (i = 0; i < 10; i++)
        {
            Console.WriteLine($" MethodNotAsync => {i.ToString()}");
            // Do something
            Task.Delay(5000).Wait();
        }
        return i;
    }


    public static async Task<List<Person>> Task1()
    {
        Thread.Sleep(5000);

        var perspnList = new List<Person>();
        for (int i = 0; i < 10; i++)
        {
            var pers1 = new Person { Id = i, Name = i.ToString() + "A" };
            perspnList.Add(pers1);
        }
        return perspnList.ToList();
    }


    public static async void Operation()
    {
        var person = Task.Run(Task1);
        Console.WriteLine($"**** total person count  : {person} ****");

        Console.WriteLine("**** Start Operation ****");
        var task1 = Delay(5000);
        var task2 = DelayAsync(5000);
        int[] result = await Task.WhenAll(task2);

        Console.WriteLine($"**** total times : {result.Sum()} ****");

    }

    static int Delay(int ms)
    {
        Console.WriteLine($"start delay for {ms} ms");
        Thread.Sleep(5000);
        Console.WriteLine($"end delay for {ms} ms");
        return ms;
    }

    static async Task<int> DelayAsync(int ms)
    {
        Console.WriteLine($"start delay for {ms} ms");
        await Task.Delay(ms);
        Console.WriteLine($"end delay for {ms} ms");
        return ms;
    }

}
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}