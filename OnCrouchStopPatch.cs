using System;
using HarmonyLib;
using UnityEngine;

namespace Crouching
{
    [HarmonyPatch(typeof(vp_Controller))]
    [HarmonyPatch("OnStop_Crouch")]
    static class OnCrouchStopPatch
    {
        public static void Postfix(vp_Controller __instance)
        {
            vp_FPCamera cam = GameObject.Find("FPSCamera").GetComponent<vp_FPCamera>();
            cam.PositionOffset = new Vector3(cam.PositionOffset.x, cam.PositionOffset.y / __instance.PhysicsCrouchHeightModifier, cam.PositionOffset.z);
            cam.Refresh();
        }
    }
}
