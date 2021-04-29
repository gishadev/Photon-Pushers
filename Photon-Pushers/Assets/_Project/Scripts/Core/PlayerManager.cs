using Photon.Pun;
using UnityEngine;
using System.Linq;

namespace Gisha.Pushers.Core
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerHighlightPrefab;

        public Transform Spawnpoint { get; private set; }
        public GameObject Player { get; private set; }

        Transform _playerHighlight;
        PhotonView _pv;

        private void Awake()
        {
            _pv = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (!_pv.IsMine)
                return;

            int index = PhotonNetwork.PlayerList.ToList().FindIndex(x => x == PhotonNetwork.LocalPlayer);
            Spawnpoint = GameManager.Spawnpoints[index];
            Player = PhotonNetwork.Instantiate("Player", Spawnpoint.position, Quaternion.identity);
            _playerHighlight = Instantiate(playerHighlightPrefab, Player.transform.position, playerHighlightPrefab.transform.rotation).transform;
        }

        private void LateUpdate()
        {
            if (!_pv.IsMine)
                return;

            if (Player.transform.position.y < -25f)
                PlayerRespawn();

            UpdateHighlightPosition();
        }

        private void PlayerRespawn()
        {
            Player.transform.position = Spawnpoint.position;
        }

        private void UpdateHighlightPosition()
        {
            _playerHighlight.position = Player.transform.position - Vector3.up * 0.85f;
        }
    }
}
