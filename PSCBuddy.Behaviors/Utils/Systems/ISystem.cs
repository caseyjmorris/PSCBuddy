﻿using System.Collections.Generic;

namespace PSCBuddy.Behaviors.Utils.Systems
{
  public interface ISystem
  {
    string CoreName { get; }
    string CoreLocation { get; }
    string SettingsFileName { get; }
  }

  public interface IForceCueRewritableSystem : ISystem
  {
    string GetPlaylistText(IList<string> tracks);
  }
}