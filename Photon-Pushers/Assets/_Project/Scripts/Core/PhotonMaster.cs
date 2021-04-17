using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class PhotonMaster : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();

            Debug.Log("Connecting to Photon");
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinRandomRoom();

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
            Vector3 position = GameManager.Spawnpoints[PhotonNetwork.PlayerList.Length - 1].position;
            PhotonNetwork.Instantiate("Player", position, Quaternion.identity);
        }
    }
}