using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlareGuidelinePrinciple
{
    public class Rootobject
    {
        public Results Results { get; set; }
    }

    public class Results
    {
        [JsonProperty(PropertyName = "Guideline_data")]
        public Guideline_Data Guideline_data { get; set; }

        [JsonProperty(PropertyName = "Plan_data")]
        public Plan_Data Plan_data { get; set; }
    }

    public class Guideline_Data
    {
        public string type { get; set; }
        public Value value { get; set; }
    }


    public class Plan_Data
    {
        public string type { get; set; }
        public Value value { get; set; }
    } 

    public class Value
    {
        public string[][] Values { get; set; }
    }
   
}
