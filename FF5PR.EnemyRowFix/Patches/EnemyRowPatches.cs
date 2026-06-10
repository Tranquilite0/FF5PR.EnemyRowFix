using HarmonyLib;
using Last.Battle;
using Last.Defaine.User;
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
            var targetEntity = targetEnemy.BattleUnitDataInfo.BattleSpriteEntity.CharacterSR;
            var targetEffectiveX = targetEnemy.GetEnemyPos().x + targetEntity.Width;
            var forwardMost = enemyUnits.Where(x => !BattleUtility.IsNotTargeting(x)).MaxBy(x => x.GetEnemyPos().x);
            Plugin.Log.LogInfo($"TargetEnemy=({uniqueId}) {targetEnemy.GetUnitName()}: Pos: {targetEnemy.GetEnemyPos()} W,H: {targetEntity.Width},{targetEntity.Height} EffectiveX:{targetEffectiveX}");
            Plugin.Log.LogInfo($"ForwardMost=({uniqueId}) {forwardMost.GetUnitName()}: Pos: {forwardMost.GetEnemyPos()}");
            var corpsId = targetEffectiveX >= forwardMost.GetEnemyPos().x ? CorpsId.Front : CorpsId.Back;
            if (__result != corpsId)
            {
                Plugin.Log.LogInfo($"Changing enemy {uniqueId} CorpsId from {__result} to {corpsId}");
            }
            __result = corpsId;
        }

    }
}
