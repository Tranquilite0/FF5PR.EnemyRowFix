using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using FF5PR.EnemyRowFix.Patches;
using HarmonyLib;
using System;

namespace FF5PR.EnemyRowFix
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public partial class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;
        internal static new ModConfiguration Config;

        public override void Load()
        {
            Log = base.Log;

            Log.LogInfo($"Game detected: {GameDetection.Version}");
            Log.LogInfo("Loading...");

            Config = new ModConfiguration(base.Config);
            Config.Init();
            if (ModComponent.Inject())
            {
                ApplyPatches();
            }

            // Plugin startup logic
            Log = base.Log;
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        private static void ApplyPatches()
        {
            ApplyPatch(typeof(TestPatches), GameVersion.FF5);

            Log.LogInfo("Patches applied!");
        }

        private static void ApplyPatch(Type type, GameVersion versionsFlag = GameVersion.Any)
        {
            if ((GameDetection.Version & versionsFlag) != GameDetection.Version)
            {
                return;
            }

            Log.LogInfo($"Patching {type.Name}...");

            Harmony.CreateAndPatchAll(type);
        }
    }
}
