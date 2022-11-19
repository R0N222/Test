using UnityEditor;
using UnityEngine;
using Assets;
using System;
using System.Collections;
namespace Assets.power
{
    public abstract class ActivePower : PowerUp 
    {

        public float cooldown = 1f;
        private bool allowUsage = true;
        public void TryDo(Player player)
        {
            if (allowUsage)
            {
                DoIt(player);
                allowUsage = false;
                GameManager.ExecuteAfterTime(() =>
                {
                    allowUsage = true;
                },cooldown);
            }
        }
        protected abstract void DoIt(Player player);


    }
}