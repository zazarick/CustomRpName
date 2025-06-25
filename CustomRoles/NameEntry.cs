using System.ComponentModel;

namespace CustomNames
{
    public class NameEntry
    {
        [Description("Имя")]
        public string Name { get; set; }
        [Description("Вес")]
        public int Weight { get; set; }

        public NameEntry() { }
        public NameEntry(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
    }
}