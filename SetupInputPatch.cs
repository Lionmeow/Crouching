using System;
using HarmonyLib;
using SRML;
using UnityEngine.UI;

namespace Crouching
{
	[HarmonyPatch(typeof(OptionsUI))]
	[HarmonyPatch("SetupInput")]
	static class SetupInputPatch
    {
		public static void Postfix(OptionsUI __instance)
        {
            __instance.CreateKeyBindingLine("key.crouch", Main.CrouchActions.crouch);
			RefreshButtonFunctionality(__instance);
        }

		static void RefreshButtonFunctionality(OptionsUI __instance)
		{
			Button[] componentsInChildren = __instance.bindingsPanel.GetComponentsInChildren<Button>(false);    // Changed to false
			for (int j = 0; j < componentsInChildren.Length; j += 2)
			{
				Navigation navigation = default(Navigation);
				navigation.mode = Navigation.Mode.Explicit;
				navigation.selectOnRight = componentsInChildren[j + 1];
				if (j < componentsInChildren.Length - 2)
				{
					navigation.selectOnDown = componentsInChildren[j + 2];
				}
				else
				{
					navigation.selectOnDown = __instance.sensitivitySlider;
					Navigation navigation2 = __instance.sensitivitySlider.navigation;
					navigation2.mode = Navigation.Mode.Explicit;
					navigation2.selectOnUp = componentsInChildren[j];
					__instance.sensitivitySlider.navigation = navigation2;
				}
				if (j > 0)
				{
					navigation.selectOnUp = componentsInChildren[j - 2];
				}
				else
				{
					navigation.selectOnUp = __instance.defaultKeyBtn;
					Navigation navigation3 = __instance.defaultKeyBtn.navigation;
					navigation3.mode = Navigation.Mode.Explicit;
					navigation3.selectOnDown = componentsInChildren[j];
					__instance.defaultKeyBtn.navigation = navigation3;
				}
				componentsInChildren[j].navigation = navigation;
				Navigation navigation4 = default(Navigation);
				navigation4.mode = Navigation.Mode.Explicit;
				navigation4.selectOnLeft = componentsInChildren[j];
				if (j < componentsInChildren.Length - 2)
				{
					navigation4.selectOnDown = componentsInChildren[j + 3];
				}
				else
				{
					navigation4.selectOnDown = __instance.sensitivitySlider;
				}
				if (j > 0)
				{
					navigation4.selectOnUp = componentsInChildren[j - 1];
				}
				else
				{
					navigation4.selectOnUp = __instance.defaultKeyBtn;
				}
				componentsInChildren[j + 1].navigation = navigation4;
			}
		}

	}
}
