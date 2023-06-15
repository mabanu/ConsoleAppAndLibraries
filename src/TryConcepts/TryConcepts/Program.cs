// See https://aka.ms/new-console-template for more information

using System.Reflection;
using TryConcepts;
using BindingFlags = System.Reflection.BindingFlags;

Console.WriteLine("Hello, World!");

var instance = new MultiMethodCall();

var methods = instance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(item => item.Name.StartsWith("Call"));
Console.WriteLine(methods.Count());

foreach (var method in methods)
{
    method.Invoke(instance, Array.Empty<object>());
}
