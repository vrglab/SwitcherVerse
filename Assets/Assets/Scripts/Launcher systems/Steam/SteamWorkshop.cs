using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamWorkshop : Instancable<SteamWorkshop>
{

    /// <summary>
    /// Downloads content from the steam workshop
    /// </summary>
    /// <param name="id"></param>
    public async void WorkshopDownload(uint id)
    {
       var res = await SteamUGC.DownloadAsync(id);
       if (!res)
       {
           throw new System.Exception("failed to download content from steam");
       }
    }

}
