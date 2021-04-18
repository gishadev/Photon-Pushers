using Photon.Pun;
using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class PlayerManager : MonoBehaviour
    {
        public Transform Spawnpoint { get; private set; }
        public GameObject Player { get; private set; }

        PhotonView _pv;

        private void Awake()
        {
            _pv = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (!_pv.IsMine)
                return;

            Spawnpoint = GameManager.Spawnpoints[Mathf.Max(PhotonNetwork.PlayerList.Length - 1, 0)];
            Player = PhotonNetwork.Instantiate("Player", Spawnpoint.position, Quaternion.identity);
        }

        private void LateUpdate()
        {
            if (!_pv.IsMine)
                return;

            if (Player.transform.position.y < -25f)
                PlayerRespawn();
        }

        private void PlayerRespawn()
        {
            Player.transform.position = Spawnpoint.position;
        }
    }
}
