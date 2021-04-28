using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class RoomGUI : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_Text titleText;

        public void OnClick_LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
            Debug.Log("Leaving room...");
        }

        public void OnClick_Start()
        {
            PhotonNetwork.LoadLevel(1);
        }

        public override void OnJoinedRoom()
        {
            SetGUIInfo(PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnLeftRoom()
        {
            MenuManager.Instance.ChangeMenu(1);
        }

        public void SetGUIInfo(string roomName)
        {
            titleText.text = roomName;
        }
    }
}
