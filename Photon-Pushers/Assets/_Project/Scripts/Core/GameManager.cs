using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnpoints;

        public static Transform[] Spawnpoints { private set; get; }

        private void Awake()
        {
            Spawnpoints = spawnpoints;
        }
    }
}
