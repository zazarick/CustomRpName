using System.ComponentModel;

namespace CustomNames
{
    public class CustomInfoEntry
    {
        [Description("CustomInfo")]
        public string Info { get; set; }
        [Description("Вес")]
        public int Weight { get; set; }

        public CustomInfoEntry() { }
        public CustomInfoEntry(string info, int weight)
        {
            this.Info = info;
            this.Weight = weight;
        }
    }
}