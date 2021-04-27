using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            CreatePlayerManager();
        }

        private void CreatePlayerManager()
        {
            PhotonNetwork.Instantiate("PlayerManager", new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }
}
