using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Gisha.Pushers.Photon
{
    public class PhotonMaster : MonoBehaviourPunCallbacks
    {
        #region Singleton
        public static PhotonMaster Instance { get; private set; }
        #endregion

        private void Awake()
        {
            CreateInstance();
            ConnectToPhoton();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                if (Instance != this)
                {
                    Destroy(Instance.gameObject);
                    Instance = this;
                }
            }
            DontDestroyOnLoad(gameObject);
        }

        private void ConnectToPhoton()
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connecting to Photon...");
        }

        #region Callbacks
        public override void OnConnectedToMaster()
        {
            Debug.Log("Successfully connected to Photon.");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            var roomName = Random.Range(0, 1000).ToString();
            var options = new RoomOptions() { MaxPlayers = 2, IsOpen = true, IsVisible = true };

            PhotonNetwork.CreateRoom(roomName, options);

            Debug.Log("Failed to join random room. Creating a new one.");
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Successfully connected to room.");
            PhotonNetwork.Instantiate("PlayerManager", new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        #endregion
    }
}