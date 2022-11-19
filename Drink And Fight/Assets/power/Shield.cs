using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace Assets.power
{
    [CreateAssetMenu(fileName = "new shield", menuName = "PowerUP/Active/Shield")]
    public class Shield : ActivePower
    {
        [SerializeField] private GameObject shield;
        [SerializeField] public float protectionTime;
        private GameObject g;
        protected override void DoIt(Player player)
        {
            g = Instantiate(shield,player.transform.position,Quaternion.identity,player.transform);
            g.transform.localScale = new Vector3(2, 2, 2);
            GameManager.ExecuteAfterTime(() =>
            {
                Destroy(g);
            }, protectionTime);
        }
    }
}