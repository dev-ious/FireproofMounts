using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace FireproofMounts
{
    [HarmonyPatch]
    internal class Burning
    {

        [HarmonyPrefix]
        [HarmonyPatch(typeof(SE_Burning), "UpdateStatusEffect")]
        public static void BurningUpdate_Prefix(ref SE_Burning __instance, float dt)
        {
            Player player = Player.m_localPlayer;
            bool isRiding = player.IsRiding();


            if (player == null || player.IsDead() || !isRiding)
            {
                return;
            }

            Sadle sadle = player.m_doodadController as Sadle;
            
            var tame = sadle.GetTameable();
            if(tame == null )
            {
                return;
            }

            var playerSe = player.GetSEMan().GetStatusEffect("Burning".GetHashCode());
            var mountSe = tame.m_character.GetSEMan().GetStatusEffect("Burning".GetHashCode());

            if (__instance == playerSe)
            {
                player.GetSEMan().RemoveStatusEffect(playerSe);
                return;
            }

            if (__instance == mountSe)
            {
                tame.m_character.GetSEMan().RemoveStatusEffect(mountSe);
                return;
            }

        }
    }
}
