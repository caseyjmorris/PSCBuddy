using System.Collections.Generic;

namespace PSCBuddy.Behaviors.Utils
{
    public interface IPlaylistManager
    {
        bool TryUpdatePlaylist(string driveRoot, string playlistName, IEnumerable<string> gamePaths,
            string corePath = "DETECT", string coreName = "DETECT", bool overwrite = false, string readableNameXml = null);
    }
}