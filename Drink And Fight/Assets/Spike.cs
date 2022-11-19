using UnityEditor;
using UnityEngine;

namespace Assets.power
{
    [CreateAssetMenu(fileName = "new spike", menuName = "PowerUP/Active/Spike")]
    public class Spike : ActivePower
    {

        [SerializeField] private GameObject spike;
        private GameObject g;
        protected override void DoIt(Player player)
        {
            Vector3 velo = player.rigid.velocity;
            Vector2 position = player.transform.position - velo.normalized * 2 + new Vector3(0,10,0);
            g = Instantiate(spike,position, Quaternion.identity, GameManager.instance.transform);
        }
    }
}