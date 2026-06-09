using Last.Battle;
using Last.Data.Master;
using Last.Data.User;
using Last.Management;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
