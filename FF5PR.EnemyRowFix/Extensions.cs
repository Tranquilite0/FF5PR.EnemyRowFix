using Last.Battle;
using Last.Data.Master;
using Last.Data.User;
using Last.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace FF5PR.EnemyRowFix
{
    public static class Extensions
    {
        /// <summary>
        /// Fetches the Units name. Should work as long as <paramref name="unitData"/> has a non-null result for
        /// <see cref="BattleUnitData.GetOwnedCharacterData"/> or <see cref="BattleUnitData.GetMonster"/>.
        /// </summary>
        /// <param name="unitData"></param>
        /// <returns></returns>
        public static string GetUnitName(this BattleUnitData unitData)
        {
            //Check if player character
            if (unitData.GetOwnedCharacterData() is OwnedCharacterData ownedCharacterData)
            {
                return ownedCharacterData.Name;
            }
            else if (unitData.GetMonster() is Monster monster)
            {
                return MessageManager.Instance.GetMessage(monster.MesIdName);
            }

            return "<unknown unit>";
        }

        /// <summary>
        /// Gets enemy unit position. Appears to be the same even if you are ambushed.
        /// </summary>
        /// <param name="enemyData"></param>
        /// <returns></returns>
        public static UnityEngine.Vector2 GetPos(this BattleEnemyData enemyData) =>
            BattlePlugManager.instance.InstantiateManager.battleEnemyInstanceData.GetEnemyPos(enemyData.UniqueId);

        /// <summary>
        /// Gets X position of the middle of enemy sprite.
        /// </summary>
        /// <param name="enemyData"></param>
        /// <returns></returns>
        public static float GetXCenter(this BattleEnemyData enemyData) =>
            BattlePlugManager.instance.InstantiateManager.battleEnemyInstanceData.GetEnemyPos(enemyData.UniqueId).x +
            //Center x is typically zero, but use it anyway in case sprite anchor differs for some enemy.
            enemyData.BattleUnitDataInfo.BattleSpriteEntity.CharacterSR.bounds.center.x; 

        /// <summary>
        /// Gets X position of minimum (left edge) of enemy sprite.
        /// </summary>
        /// <param name="enemyData"></param>
        /// <returns></returns>
        public static float GetXMin(this BattleEnemyData enemyData) =>
            BattlePlugManager.instance.InstantiateManager.battleEnemyInstanceData.GetEnemyPos(enemyData.UniqueId).x +
            enemyData.BattleUnitDataInfo.BattleSpriteEntity.CharacterSR.bounds.min.x;

        /// <summary>
        /// Gets X position of maximum (right edge) of enemy sprite.
        /// </summary>
        /// <param name="enemyData"></param>
        /// <returns></returns>
        public static float GetXMax(this BattleEnemyData enemyData) =>
            BattlePlugManager.instance.InstantiateManager.battleEnemyInstanceData.GetEnemyPos(enemyData.UniqueId).x +
            enemyData.BattleUnitDataInfo.BattleSpriteEntity.CharacterSR.bounds.max.x;

        /// <summary>
        /// Gets width of enemy sprite.
        /// </summary>
        /// <param name="enemyData"></param>
        /// <returns></returns>
        public static int GetWidth(this BattleEnemyData enemyData) =>
            enemyData.BattleUnitDataInfo.BattleSpriteEntity.CharacterSR.Width;

    }
}
