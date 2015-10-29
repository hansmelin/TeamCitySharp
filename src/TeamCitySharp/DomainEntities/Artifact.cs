using System;

namespace TeamCitySharp.DomainEntities
{
    public class Artifact
    {
        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime ModificationTime { get; set; }
        public string Href { set; get; }
    }
}