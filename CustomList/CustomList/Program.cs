// See https://aka.ms/new-console-template for more information
using CustomList;

Console.WriteLine("Hello, World!");

TestClass hans = new("Hans");

VList<TestClass> vList = new();

vList.Add(hans);
vList.Add(new TestClass("Pedro"));
vList.Add(new TestClass("Carl"));

foreach (var v in vList)
{
    Console.WriteLine(v.TellMyName());
}

vList.Remove(hans);

Console.WriteLine("Someone left the building");


foreach (var v in vList)
{
    Console.WriteLine(v.TellMyName());
}