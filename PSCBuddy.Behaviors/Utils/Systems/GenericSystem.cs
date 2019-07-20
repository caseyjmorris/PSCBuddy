using System;

namespace PSCBuddy.Behaviors.Utils.Systems
{
    public class GenericSystem : ISystem
    {
        public static GenericSystem Instance => InternalInstance.Value;
        
        private static readonly Lazy<GenericSystem> InternalInstance = new Lazy<GenericSystem>(() => new GenericSystem());

        private GenericSystem()
        {
        }

        public string CoreName => "DETECT";
        public string CoreLocation => "DETECT";
        public string SettingsFileName => "genericchdarchive.json";
    }
}
