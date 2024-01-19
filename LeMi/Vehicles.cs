#if FIVEM
using CitizenFX.Core;
#elif SHVDN3
using GTA;
#endif

namespace LeMi.Client;

/// <summary>
/// Tools for managing vehicles.
/// </summary>
public static class Vehicles
{
    /// <summary>
    /// Deletes the current vehicle.
    /// </summary>
    public static void DeleteCurrent() => Game.Player.Character.CurrentVehicle?.Delete();
}
