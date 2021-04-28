using TMPro;
using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class RoomListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomNameText;
        [SerializeField] private TMP_Text roomPlayersCountText;

        public void SetInfo(string roomName, int currentPlayersCount, int maxPlayersCount)
        {
            roomNameText.text = roomName;
            roomPlayersCountText.text = $"[{currentPlayersCount}/{maxPlayersCount}]";
        }
    }
}
