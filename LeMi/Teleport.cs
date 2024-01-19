#if FIVEM
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;
#elif SHVDN3
using GTA;
using GTA.Math;
using GTA.Native;
#endif

namespace LeMi.Client;

/// <summary>
/// Tools for teleporting around the map.
/// </summary>
public static class Teleport
{
    private static bool HaveCollisionsLoadedAroundEntity(Entity entity)
    {
        #if FIVEM
        return API.HasCollisionLoadedAroundEntity(entity.Handle);
        #elif SHVDN3
        return Function.Call<bool>(Hash.HAS_COLLISION_LOADED_AROUND_ENTITY, entity.Handle);
        #endif
    }
    
    /// <summary>
    /// Deletes the current vehicle.
    /// </summary>
    #if FIVEM
    public static async Task ToWaypoint()
    #elif SHVDN3
    public static void ToWaypoint()
    #endif
    {
        Vector3 pos = World.WaypointPosition;

        if (pos == Vector3.Zero)
        {
            return;
        }

        pos.Z = 0;

        Entity entity = Game.Player.Character.CurrentVehicle as Entity ?? Game.Player.Character;

        entity.Position = pos;
        entity.IsPositionFrozen = true;
        
        while (true)
        {
            if (HaveCollisionsLoadedAroundEntity(entity))
            {
                float z = World.GetGroundHeight(pos);

                if (z != 0)
                {
                    pos.Z = z;
                    entity.Position = pos;
                    entity.IsPositionFrozen = false;
                    return;
                }

                pos.Z += 1;
                entity.Position = pos;
            }
            
            #if FIVEM
            await BaseScript.Delay(1000);
            #elif SHVDN3
            Script.Wait(1000);
            #endif
        }
    }
}
