using InControl;
using MonomiPark.SlimeRancher.Persist;
using SRML;
using SRML.SR;
using System;
using UnityEngine;

namespace Crouching
{
    public class Main : ModEntryPoint
    {
        static AssetBundle assetBundle = Shortcutter.LoadAssetbundle("crouch");
        public static SECTR_AudioCue crouchCue = ScriptableObject.CreateInstance<SECTR_AudioCue>();

        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
            TranslationPatcher.AddUITranslation("key.crouch", "Crouch");
            
        }

        public override void Load()
        {
            crouchCue.MaxInstances = 10;
            crouchCue.AudioClips = new System.Collections.Generic.List<SECTR_AudioCue.ClipData>()
            {
                new SECTR_AudioCue.ClipData(assetBundle.LoadAsset<AudioClip>("player_crouch"))
            };

            CrouchActions.crouch.AddDefaultBinding(new Key[] { Key.LeftControl });
            CrouchActions.crouch.AddDefaultBinding(new Key[] { Key.C });
        }

        public override void PostLoad()
        {
            
        }

        public class CrouchActions : SRInput.PlayerLookActions
        {
            public static PlayerAction crouch;
        }
    }
}