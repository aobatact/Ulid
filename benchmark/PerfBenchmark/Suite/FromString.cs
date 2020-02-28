extern alias Ulid_1_0_0;
extern alias newUlid;
using BenchmarkDotNet.Attributes;
using System;
using OldUlid = Ulid_1_0_0::System.Ulid;
using NewUlid = newUlid::System.Ulid;

namespace PerfBenchmark.Suite
{
    [Config(typeof(BenchmarkConfig))]
    public class FromString
    {
        string guidStr;
        string ulidStr;
        Guid guid;
        OldUlid oldUlid;
        NewUlid ulid;
        NUlid.Ulid nulid;

        [GlobalSetup]
        public void SetUp()
        {
            guidStr = Guid.NewGuid().ToString();
            ulidStr = OldUlid.NewUlid().ToString();
        }

        [Benchmark(Baseline = true)]
        public void Guid_()
        {
            guid = new Guid(guidStr);
        }

        [Benchmark]
        public void OldUlid_()
        {
            oldUlid = OldUlid.Parse(ulidStr);
        }

        [Benchmark]
        public void Ulid_()
        {
            ulid = NewUlid.Parse(ulidStr);
        }

        [Benchmark]
        public void NUlid_()
        {
            nulid = NUlid.Ulid.Parse(ulidStr);
        }
    }
}
