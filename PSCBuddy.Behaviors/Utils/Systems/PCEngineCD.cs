using System;

namespace PSCBuddy.Behaviors.Utils.Systems
{
    public class PCEngineCD : ISystem
    {
        public static PCEngineCD Instance => InternalInstance.Value;

        private static readonly Lazy<PCEngineCD> InternalInstance = new Lazy<PCEngineCD>(() => new PCEngineCD());

        private PCEngineCD()
        {
        }

        public string CoreName => "NEC - PC Engine / CD (Beetle PCE FAST)";

        public string CoreLocation =>
            "/media/bleemsync/opt/retroarch/.config/retroarch/cores/mednafen_pce_fast_libretro.so";

        public string SettingsFileName => "pcecdchdarchive.json";
    }
}
