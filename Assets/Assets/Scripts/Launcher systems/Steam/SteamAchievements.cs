using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using System.Net.Http.Headers;

/// <b>Authors</b>
/// <br>Arad Bozorgmehr (Vrglab)</br>
public class SteamAchievements : Instancable<SteamAchievements>
{
    /// <summary>
    /// Unlocks a steam Achievement
    /// </summary>
    /// <param name="achID">Steam's achievement id</param>
    /// <b>Authors</b>
    /// <br>Arad Bozorgmehr (Vrglab)</br>
    public void Achieve(string achID)
    {
        foreach (var achievements in SteamUserStats.Achievements)
        {
            if (achievements.Identifier.Equals(achID)){
                achievements.Trigger();
                break;
            }
        }
        SteamUserStats.StoreStats();
    }

    /// <summary>
    /// Get's the current state of the achievement
    /// </summary>
    /// <param name="achID">Steam's achievement id</param>
    /// <returns>True if achievement is unlocked</returns>
    /// <b>Authors</b>
    /// <br>Arad Bozorgmehr (Vrglab)</br>
    public bool GetAchievementState(string achID)
    {
        foreach (var achievements in SteamUserStats.Achievements)
        {
            if (achievements.Identifier.Equals(achID))
            {
                return achievements.State;
            }
        }
        return false;
    }
    
}
