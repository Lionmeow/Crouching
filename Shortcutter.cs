using System.IO;
using System.Linq;
using System.Reflection;
using SRML.SR;
using UnityEngine;

namespace Crouching
{
    public class Shortcutter
    {
        public static void RegisterFullVaccable(Identifiable.Id id, Color32 color, Sprite icon)
        {
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(id));
            LookupRegistry.RegisterVacEntry(id, color, icon);
            GameObject Object = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(id);
            Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            if (Identifiable.SLIME_CLASS.Contains(id))
            {
                SlimeDefinition slimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(id);
                SlimeAppearance slimeAppearance = slimeDefinition.Appearances.First();
                slimeAppearance.Icon = icon;
                slimeAppearance.ColorPalette.Ammo = color;
            }
        }

        public static void RegisterPlortEntry(Identifiable.Id id, float price, float saturated, ProgressDirector.ProgressType progressType = ProgressDirector.ProgressType.NONE)
        {
            PlortRegistry.AddEconomyEntry(id, price, saturated);
            if (progressType == ProgressDirector.ProgressType.NONE)
            {
                PlortRegistry.AddPlortEntry(id);
            }
            else
            {
                PlortRegistry.AddPlortEntry(id, new ProgressDirector.ProgressType[]
                {
                    progressType
                });
            }
        }

        public static Sprite FindPediaIcon(PediaDirector.Id id)
        {
            return SRSingleton<SceneContext>.Instance.PediaDirector.entries.First((PediaDirector.IdEntry x) => x.id == id).icon;
        }

        public static AssetBundle LoadAssetbundle(string name)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Main), name);
            return AssetBundle.LoadFromStream(manifestResourceStream);
        }

    }
}
