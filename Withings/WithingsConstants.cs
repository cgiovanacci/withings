using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Withings
{

    public enum AttributionType
    {
        ByDeviceAndValid = 0,
        ByDeviceButAmbiguous = 1,
        Manually = 2,
        ManuallyAtCreation = 4,
    }

    public enum CategoryType
    {
        Measure = 1,
        Target = 2,
    }

    public enum MeasureType
    {
        Weight = 1,
        Height = 4,
        FatFreeMass = 5,
        FatRatio = 6,
        FatMassWeight = 8,
        DiastolicBloodPressure = 9,
        SystolicBloodPressure = 10,
        HeartPulse = 11,
    }
}
