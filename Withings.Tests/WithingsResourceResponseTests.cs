using System;
using RestSharp;
using NUnit.Framework;
using Withings.Tests.Helpers;
using System.IO;
using Withings;
using System.Collections.Generic;

namespace Withings.Tests
{
    [TestFixture]
    public class WithingsResourceResponseTests
    {
        [Test]
        public void Can_Deserialize_Empty_Measure_Groups()
        {
            string content = File.ReadAllText(SampleData.PathFor("MeasureEmpty.txt"));
            RestResponse resp = new RestResponse() { Content = content };
            List<MeasureGroup> measureGroups = WithingsResourceResponse.DeserializeMeasuresResponse(resp);
            Assert.IsNull(measureGroups);
        }

        [Test]
        public void Can_Deserialize_Measure_Groups()
        {
            string content = File.ReadAllText(SampleData.PathFor("MeasureGroupsResult.txt"));
            RestResponse resp = new RestResponse() { Content = content };
            List<MeasureGroup> measureGroups = WithingsResourceResponse.DeserializeMeasuresResponse(resp);
            Assert.IsNotNull(measureGroups);
            Assert.IsTrue(measureGroups.Count == 2);
            MeasureGroup grp = measureGroups[1];
            Assert.AreEqual(grp.Date, new DateTime(2013, 09, 08, 15, 0, 40, 0, DateTimeKind.Utc));
            Assert.IsTrue(grp.Measures.Count == 4);
            Measure measure = grp.Measures[0];
            Assert.IsTrue(measure.value == 90550);
            Assert.IsTrue(measure.type == MeasureType.Weight);
            Assert.IsTrue(measure.unit == -3);
        }
        [Test]
        public void Can_Deserialize_Response_Status_Erroor()
        {
            string content = File.ReadAllText(SampleData.PathFor("ResponseStatusError.txt"));
            RestResponse resp = new RestResponse() { Content = content };
            List<MeasureGroup> measureGroups = WithingsResourceResponse.DeserializeMeasuresResponse(resp);
            Assert.IsNull(measureGroups);       
        }
    }
}