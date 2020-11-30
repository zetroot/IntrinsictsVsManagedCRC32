using BenchmarkDotNet.Attributes;
using Force.Crc32;
using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsictsVsManagedCRC32
{
    public class HashBenches
    {
        private static Random rnd = new Random();
        private byte[] data;

        [Params(0x100_0000, 0x1000_0000, 0x1_0000_0000)]        
        public long Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[Size];
            rnd.NextBytes(data);            
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            data = null;
        }

        [Benchmark]
        public byte[] Managed()
        {
            var crc32 = new Crc32Algorithm();
            return crc32.ComputeHash(data);
        }

        [Benchmark]
        public byte[] Intrinsic()
        {
            var crc32 = new CRC32Baremetal();
            return crc32.ComputeHash(data);
        }
    }
}
