using System;
using System.Collections.Generic;
using PSCBuddy.Behaviors.Utils;

namespace archive2chd
{
    public class NullPlaylistManager : IPlaylistManager
    {
        private static readonly Lazy<NullPlaylistManager> _instance = 
            new Lazy<NullPlaylistManager>(() => new NullPlaylistManager());
        public static NullPlaylistManager Instance => _instance.Value;
        private NullPlaylistManager() {}
        public bool TryUpdatePlaylist(string driveRoot, string playlistName, IEnumerable<string> gamePaths, string corePath = "DETECT",
            string coreName = "DETECT", bool overwrite = false, string readableNameXml = null)
        {
            return true;
        }
    }
}