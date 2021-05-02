using HarmonyLib;

namespace Crouching
{
	[HarmonyPatch(typeof(GamepadPanel))]
	[HarmonyPatch("SetupBindings")]
	static class SetupBindingsPatch
    {
		public static void Postfix(GamepadPanel __instance)
        {
            __instance.CreateGamepadBindingLine("key.crouch", Main.CrouchActions.crouch);
        }
	}
}
