using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuildArtifacts
    {
        void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler);

        ArtifactWrapper ByBuildConfigId(string buildConfigId);

        List<Artifact> ByBuildId(string buildId, string subfolder);
    }
}