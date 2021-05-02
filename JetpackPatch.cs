using System;
using UnityEngine;
using HarmonyLib;

namespace Crouching
{
    [HarmonyPatch(typeof(EnergyJetpack))]
    [HarmonyPatch("CanStart_Jetpack")]
    static class JetpackPatch
    {
        public static bool Prefix(EnergyJetpack __instance)
        {
            if (__instance.playerEvents.Crouch.Active)
                return false;
            else
                return true;
        }
    }
}
