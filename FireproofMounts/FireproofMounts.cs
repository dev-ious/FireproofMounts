using System.Reflection;
using BepInEx;
using HarmonyLib;
using JetBrains.Annotations;

namespace FireproofMounts
{
    [BepInPlugin(PluginId, "Fireproof Mounts", "0.0.1")]
    public class FireproofMounts : BaseUnityPlugin
    {
        public const string PluginId = "nullex.mods.fireproofmounts";
        private Harmony _harmony;

        [UsedImplicitly]
        private void Awake()
        {
            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginId);
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }
    }
}