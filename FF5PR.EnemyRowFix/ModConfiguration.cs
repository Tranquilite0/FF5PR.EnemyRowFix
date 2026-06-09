using BepInEx.Configuration;
using System.ComponentModel;

namespace FF5PR.EnemyRowFix;

public sealed class ModConfiguration(ConfigFile config)
{
    ////ATB
    //public ConfigEntry<bool> AdvanceFirstTurn;
    //public ConfigEntry<bool> MonsterAgiVariance;

    ////Delay
    //public ConfigEntry<bool> DelayAtTurnStart;
    //public ConfigEntry<float> VerySlowDelayTime;
    //public ConfigEntry<float> SlowDelayTime;
    //public ConfigEntry<float> NormalDelayTime;
    //public ConfigEntry<float> FastDelayTime;
    //public ConfigEntry<float> VeryFastDelayTime;

    ////Duration
    //public ConfigEntry<bool> SingHasteSlow;

    public void Init()
    {
        //MonsterAgiVariance = config.Bind(
        //     "ATB",
        //     nameof(MonsterAgiVariance),
        //     true,
        //     "Add a random 0, +1, or -1 to monster Agility/Speed at the start of battle."
        //);

        //AdvanceFirstTurn = config.Bind(
        //     "ATB",
        //     nameof(AdvanceFirstTurn),
        //     true,
        //     "Automatically Advance ATB at the start of battle to the first Unit's turn."
        //);

        //DelayAtTurnStart = config.Bind(
        //     "Delay Time",
        //     nameof(DelayAtTurnStart),
        //     true,
        //     "Pause the ATB for a short time at the start of a turn. In the original game the duration of this delay was the only thing the battle speed setting affected."
        //);

        //VerySlowDelayTime = config.Bind(
        //     "Delay Time",
        //     nameof(VerySlowDelayTime),
        //     4f,
        //     "Time to delay ATB in the command window when a player gets their turn when battle speed is set to Very Slow."
        //);

        //SlowDelayTime = config.Bind(
        //     "Delay Time",
        //     nameof(SlowDelayTime),
        //     2f,
        //     "Time to delay ATB in the command window when a player gets their turn when battle speed is set to Slow."
        //);

        //NormalDelayTime = config.Bind(
        //     "Delay Time",
        //     nameof(NormalDelayTime),
        //     1f,
        //     "Time to delay ATB in the command window when a player gets their turn when battle speed is set to Normal."
        //);

        //FastDelayTime = config.Bind(
        //     "Delay Time",
        //     nameof(FastDelayTime),
        //     0.5f,
        //     "Time to delay ATB in the command window when a player gets their turn when battle speed is set to Fast."
        //);

        //VeryFastDelayTime = config.Bind(
        //     "Delay Time",
        //     nameof(VeryFastDelayTime),
        //     0.25f,
        //     "Time to delay ATB in the command window when a player gets their turn when battle speed is set to Very Fast."
        //);

        //SingHasteSlow = config.Bind(
        //     "Duration",
        //     nameof(SingHasteSlow),
        //     true,
        //     "Patch the Bard's Sing command to use slow/haste status (like the original)."
        //);
    }
}
