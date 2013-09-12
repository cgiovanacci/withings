using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Withings.Tests.Helpers
{
    public class SampleData
    {
        private static string SampleDataPath = Path.Combine(Path.GetFullPath(@"..\..\"), "SampleData");

        public static string PathFor(string sampleFile)
        {
            return Path.Combine(SampleDataPath, sampleFile);

        }
    }
}
