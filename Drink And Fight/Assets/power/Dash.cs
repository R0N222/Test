using UnityEditor;
using UnityEngine;

namespace Assets.power
{
    [CreateAssetMenu(fileName = "new dash",menuName ="PowerUP/Active/Dash")]
    public class Dash : ActivePower
    {
        [SerializeField] private float dashPower;
        protected override void DoIt(Player player)
        {
            Vector3 force =  player.rigid.velocity.normalized;
            player.rigid.AddForce(force*dashPower, ForceMode2D.Impulse);
        }
    }
}