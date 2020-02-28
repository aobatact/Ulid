﻿extern alias Ulid_1_0_0;
extern alias newUlid;
using BenchmarkDotNet.Attributes;
using System;
using OldUlid = Ulid_1_0_0::System.Ulid;
using NewUlid = newUlid::System.Ulid;
namespace PerfBenchmark.Suite
{
    [Config(typeof(BenchmarkConfig))]
    public class New
    {
        Guid guid;
        OldUlid oldUlid;
        NewUlid ulid;
        NUlid.Ulid nulid;

        [Benchmark(Baseline = true)]
        public void Guid_()
        {
            guid = Guid.NewGuid();
        }

        [Benchmark]
        public void OldUlid_()
        {
            oldUlid = OldUlid.NewUlid();
        }

        [Benchmark]
        public void Ulid_()
        {
            ulid = NewUlid.NewUlid();
        }

        [Benchmark]
        public void NUlid_()
        {
            nulid = NUlid.Ulid.NewUlid();
        }
    }
}
