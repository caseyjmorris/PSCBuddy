using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSCBuddy.Behaviors.Utils;

namespace PSCBuddy.UI
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      //var pm = new PlaylistManager();
      //pm.UpdatePlaylist("L:", "PSX CHD", Directory.GetFiles(@"L:\roms\PSX CHD"),
      //  "/media/bleemsync/opt/retroarch/.config/retroarch/cores/pcsx_rearmed_libretro.so", "PCSX ReARMed");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new ArchiveCHDConversionWindow());
    }
  }
}