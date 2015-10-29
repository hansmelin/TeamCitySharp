using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class ArtifactList
    {
        public List<Artifact> File { get; set; }

        public int Count { get; set; }
    }
}