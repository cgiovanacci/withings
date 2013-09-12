using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Withings
{
    /*
     {"grpid":144737324,"attrib":0,"date":1378728559,"category":1,
"measures":[
{"value":90550,"type":1,"unit":-3},
{"value":67292,"type":5,"unit":-3},
{"value":25686,"type":6,"unit":-3},
{"value":23258,"type":8,"unit":-3}]},
     */
    public class MeasureGroup
    {
        public int Id { get; set; }
        public AttributionType Attribution { get; set; }
        public DateTime Date { get; set; }
        public CategoryType Category { get; set; }

        public List<Measure> Measures { get; set; }
    }
}
