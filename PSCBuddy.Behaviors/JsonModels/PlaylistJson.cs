using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCBuddy.Behaviors.JsonModels
{
  public class PlaylistJson
  {
    public string version { get; set; }
    public IList<PlaylistItemJson> items { get; set; }
  }

  public class PlaylistItemJson
  {
    public string path { get; set; }
    public string label { get; set; }
    public string core_path { get; set; }
    public string core_name { get; set; }
    public string crc32 { get; set; }
    public string db_name { get; set; }
  }
}