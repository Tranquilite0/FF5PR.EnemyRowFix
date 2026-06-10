using BepInEx.Configuration;
using System.ComponentModel;

namespace FF5PR.EnemyRowFix;

public sealed class ModConfiguration(ConfigFile config)
{
    //Main
    public ConfigEntry<bool> PluginEnabled;

    public void Init()
    {
        PluginEnabled = config.Bind(
             "Main",
             nameof(PluginEnabled),
             true,
             "Enables or disables the plugin."
        );
    }
}
