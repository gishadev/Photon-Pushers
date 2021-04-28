using Gisha.Pushers.Photon;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gisha.Pushers.MainMenu
{
    public class RoomListing : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TMP_Text roomNameText;
        [SerializeField] private TMP_Text roomPlayersCountText;

        public RoomInfo RoomInfo { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                PhotonMaster.Instance.JoinRoom(RoomInfo.Name);
            }
        }

        public void SetInfo(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            roomNameText.text = roomInfo.Name;
            roomPlayersCountText.text = $"[{roomInfo.PlayerCount}/{roomInfo.MaxPlayers}]";
        }
    }
}
