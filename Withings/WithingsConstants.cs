using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Withings
{

    public enum AttributionType
    {
        [Description("The measuregroup has been captured by a device and is known to belong to this user (and is not ambiguous).")]
        DeviceAndValid = 0,

        [Description("The measuregroup has been captured by a device but may belong to other users as well as this one (it is ambiguous).")]
        DeviceButAmbiguous = 1,

        [Description("The measuregroup has been entered manually for this particular user.")]
        Manually = 2,

        [Description("The measuregroup has been entered manually during user creation (and may not be accurate).")]
        ManuallyAtCreation = 4,

        [Description("Measure auto, it's only for the Blood Pressure Monitor. This device can make many measures and computed the best value.")]
        DeviceAuto = 5,

        [Description("Measure confirmed. You can get this value if the user confirmed a detected activity.")]
        Confirmed = 7
    }

    public enum CategoryType
    {
        [Description("Real measurements")]
        Measurement = 1,

        [Description("User objectives")]
        Objective = 2
    }

    public enum MeasureType
    {
        [Description("Weight (kg)")]
        Weight = 1,

        [Description("Height (m)")]
        Height = 4,

        [Description("Fat Free Mass (kg)")]
        FatFreeMass = 5,

        [Description("Fat Ratio (%)")]
        FatRatio = 6,

        [Description("Fat Mass Weight (kg)")]
        FatMassWeight = 8,

        [Description("Diastolic Blood Pressure (mmHg)")]
        DiastolicBloodPressure = 9,

        [Description("Systolic Blood Pressure (mmHg)")]
        SystolicBloodPressure = 10,

        [Description("Heart Pulse (bpm)")]
        HeartPulse = 11,

        [Description("Temperature")]
        Temperature = 12,

        [Description("SP02 (%)")]
        Sp02 = 54,

        [Description("Body Temperature")]
        BodyTemperature = 71,

        [Description("Skin Temperature")]
        SkinTemperature = 73,

        [Description("Muscle Mass")]
        MuscleMass = 76,

        [Description("Hydration")]
        Hydration = 77,

        [Description("Bone Mass")]
        BoneMass = 88,

        [Description("Pulse Wave Velocity")]
        PulseWaveVelocity = 91
    }
}
