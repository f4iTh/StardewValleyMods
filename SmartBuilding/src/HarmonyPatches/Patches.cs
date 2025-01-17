﻿using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Objects;

// ReSharper disable InconsistentNaming

namespace SmartBuilding.HarmonyPatches
{
    public static class Patches
    {
        public static bool CurrentlyInBuildMode { get; set; }

        public static bool AllowPlacement { get; set; }

        private static bool ShouldPerformAction()
        {
            if (CurrentlyInBuildMode) return AllowPlacement;

            // If we're not in build mode, we always want to continue on to the regular methods.
            return true;
        }

        public static bool PlacementAction_Prefix(Object __instance, GameLocation location, int x, int y, Farmer who)
        {
            return ShouldPerformAction();
        }

        public static bool Chest_CheckForAction_Prefix(Chest __instance, Farmer who, bool justCheckingForActivity)
        {
            return ShouldPerformAction();
        }

        public static bool FishPond_DoAction_Prefix(FishPond __instance, Vector2 tileLocation, Farmer who)
        {
            return ShouldPerformAction();
        }

        public static bool StorageFurniture_DoAction_Prefix(StorageFurniture __instance, Farmer who,
            bool justCheckingForActivity)
        {
            return ShouldPerformAction();
        }
    }
}
