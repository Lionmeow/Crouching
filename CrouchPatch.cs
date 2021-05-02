using System;
using HarmonyLib;
using UnityEngine;
using SRML.SR;

namespace Crouching
{
    [HarmonyPatch(typeof(vp_FPInput))]
    [HarmonyPatch("InputCrouch")]
    static class CrouchPatch
    {
        public static void Prefix(vp_FPInput __instance)
        {
            if (Main.CrouchActions.crouch && !__instance.FPPlayer.Jetpack.Active)
            {
                __instance.FPPlayer.Crouch.TryStart(true);
                return;
            }
            else
            {
                __instance.FPPlayer.Crouch.Stop(0f);
            }
        }
    }
}
