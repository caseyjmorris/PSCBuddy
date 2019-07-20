namespace PSCBuddy.Behaviors.Utils.Systems
{
    public class PCEngineCD : ISystem
    {
        public string CoreName => "NEC - PC Engine / CD (Beetle PCE FAST)";

        public string CoreLocation =>
            "/media/bleemsync/opt/retroarch/.config/retroarch/cores/mednafen_pce_fast_libretro.so";
    }
}
