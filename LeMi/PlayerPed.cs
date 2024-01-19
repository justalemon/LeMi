#if FIVEM
using CitizenFX.Core;
using CitizenFX.Core.Native;
#elif SHVDN3
using GTA;
using GTA.Native;
#endif

namespace LeMi.Client;

/// <summary>
/// Class for handling the Player and it's Ped
/// </summary>
public static class PlayerPed
{
    /// <summary>
    /// Revives the local player ped.
    /// </summary>
    public static void Revive()
    {
        Ped ped = Game.Player.Character;
        
        #if FIVEM
        API.ResurrectPed(ped.Handle);
        #elif SHVDN3
        Function.Call(Hash.RESURRECT_PED, ped.Handle);
        #endif
        ped.Task.ClearAllImmediately();
    }
}
