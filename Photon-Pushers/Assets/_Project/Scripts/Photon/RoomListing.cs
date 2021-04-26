using TMPro;
using UnityEngine;

namespace Gisha.Pushers.Photon
{
    public class RoomListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomNameText;
        [SerializeField] private TMP_Text roomOwnerText;
        [SerializeField] private TMP_Text roomPlayersCountText;

        public void SetInfo(string roomName, string roomOwner, int currentPlayersCount, int maxPlayersCount)
        {
            roomNameText.text = roomName;
            roomOwnerText.text = roomOwner;
            roomPlayersCountText.text = $"[{currentPlayersCount}/{maxPlayersCount}]";
        }
    }
}
