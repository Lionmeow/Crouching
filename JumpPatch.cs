using System;
using UnityEngine;
using HarmonyLib;

namespace Crouching
{
    [HarmonyPatch(typeof(vp_FPController))]
    [HarmonyPatch("CanStart_Jump")]
    static class JumpPatch
    {
        public static bool Prefix(vp_FPController __instance)
        {
            if (__instance.Player.Crouch.Active)
                return false;
            else
                return true;
        }
    }
}
