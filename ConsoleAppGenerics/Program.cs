using ClassLibraryGenerics;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();

sw.Restart();
Console.WriteLine(Mathematics.Integral((x) => x * x, 0, 1, 100_000_000));
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);

sw.Restart();
Console.WriteLine(Mathematics.IntegralParallel((x) => x * x, 0, 1, 100_000_000));
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
var s = new Student();
Console.WriteLine(s.ToString());