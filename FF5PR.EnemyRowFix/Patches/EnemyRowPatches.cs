using HarmonyLib;
using Last.Battle;
using Last.Defaine.User;
using Last.Management;
using Serial.FF5.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF5PR.EnemyRowFix.Patches
{
    public static class EnemyRowPatches
    {
        [HarmonyPatch(typeof(SerialBattleUtility), nameof(SerialBattleUtility.GetCorpsIdEnemy))]
        [HarmonyPostfix]
        static void GetCorpsIdEnemyPost(ref CorpsId __result, int uniqueId)
        {
            Plugin.Log.LogInfo($"{typeof(SerialBattleUtility).FullName}.{nameof(SerialBattleUtility.GetCorpsIdEnemy)}({uniqueId})->{__result}");

            var enemyUnits = BattlePlugManager.instance.GetEnemyUnits().ToManagedList();
            var targetEnemy = enemyUnits.First(x => x.UniqueId == uniqueId);
            var targetEffectiveX = targetEnemy.GetEffectiveX();
            var forwardMost = enemyUnits.MaxBy(x => x.GetCenterX()); //.Where(x => !BattleUtility.IsNotTargeting(x)) //TODO: consider putting this back in to desregard nontargetable units.
            Plugin.Log.LogInfo($"TargetEnemy=({uniqueId}) {targetEnemy.GetUnitName()}: Pos: {targetEnemy.GetPos()} W: {targetEnemy.GetWidth()} EffectiveX:{targetEffectiveX}");
            Plugin.Log.LogInfo($"ForwardMost=({forwardMost.UniqueId}) {forwardMost.GetUnitName()}: Pos: {forwardMost.GetPos()} CenterX: {forwardMost.GetCenterX()}");
            var corpsId = targetEffectiveX >= forwardMost.GetPos().x ? CorpsId.Front : CorpsId.Back;
            if (__result != corpsId)
            {
                Plugin.Log.LogInfo($"Changing enemy {uniqueId} CorpsId from {__result} to {corpsId}");
            }
            __result = corpsId;
        }

    }
}
