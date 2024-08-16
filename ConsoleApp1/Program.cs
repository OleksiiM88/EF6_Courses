// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);
string str = "I want to split this";
string[] s = str.Split();
EventExample eventExample = new EventExample();
eventExample.Execute();

Console.WriteLine("Before Main");
await Func1();
Console.WriteLine("After Main");
Console.ReadLine();

async Task Func1()
{
    Console.WriteLine("Before 1");
    await Func2();
    Console.WriteLine("After 1");
}

Task Func2()
{
    Console.WriteLine("Before 2");
    Task task = Func3();
    Console.WriteLine("After 2");
    return task;
}

async Task Func3()
{
    Console.WriteLine("Before 3");
    await Func4();
    Console.WriteLine("After 3");
}

Task Func4()
{
    Console.WriteLine("Before 4");
    Task task = Func5();
    Console.WriteLine("After 4");
    return task;
}

async Task Func5()
{
    Console.WriteLine("Before 5");
    await Task.Delay(5000);
    Console.WriteLine("After 5");
}