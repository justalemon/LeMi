#if FIVEM
using CitizenFX.Core;
using System.Threading.Tasks;
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
    /// <summary>
    /// Repairs the current vehicle.
    /// </summary>
    public static void FixCurrent() => Game.Player.Character.CurrentVehicle?.Repair();
    /// <summary>
    /// Spawns a vehicle by it's model.
    /// </summary>
    /// <param name="model">The model of the vehicle.</param>
    /// <param name="getInto">Whether to get the player into the vehicle or not.</param>
    #if FIVEM
    public static async Task<Vehicle> SpawnVehicle(Model model, bool getInto)
    #elif SHVDN3
    public static Vehicle SpawnVehicle(Model model, bool getInto)
    #endif
    {
        if (!model.IsCar)
        {
            return null;
        }

        while (!model.IsLoaded)
        {
            model.Request();
            
            #if FIVEM
            await BaseScript.Delay(0);
            #elif SHVDN3
            Script.Yield();
            #endif
        }

        #if FIVEM
        Vehicle vehicle = await World.CreateVehicle(model, Game.Player.Character.Position, Game.Player.Character.Heading);
        #elif SHVDN3
        Vehicle vehicle = World.CreateVehicle(model, Game.Player.Character.Position, Game.Player.Character.Heading);
        #endif

        if (getInto)
        {
            Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
        }

        return vehicle;
    }
}
