﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FreeImageAPI;
using ImageMagick;
using DS = DevILSharp;

namespace Pfim.Benchmarks
{
    public class DdsBenchmark
    {
        [Params("dxt1-simple.dds", "dxt3-simple.dds", "dxt5-simple.dds", "32-bit-uncompressed.dds")]
        public string Payload { get; set; }

        private byte[] data;

        [GlobalSetup]
        public void SetupData()
        {
            data = File.ReadAllBytes(Payload);
            DS.Bootstrap.Init();
        }

        [Benchmark]
        public IImage Pfim() => Dds.Create(new MemoryStream(data));

        [Benchmark]
        public FreeImageBitmap FreeImage() => FreeImageAPI.FreeImageBitmap.FromStream(new MemoryStream(data));

        [Benchmark]
        public int ImageMagick()
        {
            var settings = new MagickReadSettings { Format = MagickFormat.Dds };
            using (var image = new MagickImage(new MemoryStream(data), settings))
            {
                return image.Width;
            }
        }

        [Benchmark]
        public int DevILSharp()
        {
            using (var image = DS.Image.Load(data, DS.ImageType.Dds))
            {
                return image.Width;
            }
        }
    }
}
