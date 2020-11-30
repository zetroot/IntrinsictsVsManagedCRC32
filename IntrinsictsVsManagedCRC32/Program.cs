using BenchmarkDotNet.Running;
using System;

namespace IntrinsictsVsManagedCRC32
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<HashBenches>();
        }
    }
}
