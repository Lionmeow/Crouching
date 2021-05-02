using System;
using HarmonyLib;
using System.Reflection;
using InControl;

namespace Crouching
{
    [HarmonyPatch(typeof(SRInput.PlayerActions))]
    [HarmonyPatch(MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(SRInput) })]
    static class PlayerActionsConstructorPatch
    {
        public static void Postfix(SRInput.PlayerActions __instance, SRInput srInput)
        {
            var CreatePlayerAction = __instance.GetType().GetMethod("CreatePlayerAction", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            Main.CrouchActions.crouch = (PlayerAction)CreatePlayerAction.Invoke(__instance, new object[] { "Crouch" });
        }
    }
}
