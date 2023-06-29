using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace EldenRingStamina
{
    [BepInPlugin("animegif.eldenring_stamina", "Elden Ring Stamina", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class EldenRingStamina : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("animegif.eldenring_stamina");

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Player), "UseStamina")]
        public static class EldenRing_UseStamina_Patch
        {
            private static void Prefix(ref Player __instance, ref float v)
            {
                if (__instance.IsSensed() || __instance.IsTargeted()) {
                    return;
                }
                v = 0;
            }
        }
    }
}
