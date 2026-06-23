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
        private const int NeoExdeathPartyId = 608;
        /// <summary>
        /// Use X tolerance of 8 px to roughly simulate 8px wide tiles.
        /// </summary>
        private const float XTolerance = 8.0f;

        [HarmonyPatch(typeof(SerialBattleUtility), nameof(SerialBattleUtility.GetCorpsIdEnemy))]
        [HarmonyPostfix]
        static void GetCorpsIdEnemyPost(ref CorpsId __result, int uniqueId)
        {
            Plugin.Log.LogInfo($"{typeof(SerialBattleUtility).FullName}.{nameof(SerialBattleUtility.GetCorpsIdEnemy)}({uniqueId})->{__result}");

            var enemyUnits = BattlePlugManager.instance.GetEnemyUnits().ToManagedList();
            var targetEnemy = enemyUnits.First(x => x.UniqueId == uniqueId);
            var forwardMost = enemyUnits.Where(x => !BattleUtility.IsNotTargeting(x)).MaxBy(x => x.GetXCenter());

            var xMin = BattlePlugManager.instance.InstantiateManager.battleEnemyInstanceData.monsterParty.Id switch
            {
                //Kludge to get Neo Exdeath to work like the original.
                NeoExdeathPartyId => -5.0f,
                _ => forwardMost.GetXMin()
            };

            Plugin.Log.LogInfo($"TargetEnemy=({uniqueId}) {targetEnemy.GetUnitName()}: Pos: {targetEnemy.GetPos()} W,MaxX: {targetEnemy.GetWidth()},{targetEnemy.GetXMax()}");
            Plugin.Log.LogInfo($"ForwardMost=({forwardMost.UniqueId}) {forwardMost.GetUnitName()}: Pos: {forwardMost.GetPos()} W,MinX: {forwardMost.GetWidth()},{forwardMost.GetXMin()}");

            var corpsId = xMin - targetEnemy.GetXMax() < XTolerance ? CorpsId.Front : CorpsId.Back;
            if (__result != corpsId)
            {
                Plugin.Log.LogInfo($"Changing enemy {uniqueId} CorpsId from {__result} to {corpsId}");
            }
            __result = corpsId;
        }

    }
}
