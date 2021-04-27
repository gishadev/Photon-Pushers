using Gisha.Pushers.MainMenu;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gisha.Pushers.Photon
{
    public class RoomListingManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform contentTrans;
        [SerializeField] private GameObject roomListingPrefab;
        [SerializeField] private TMP_Text nameInputText;

        Dictionary<string, RoomListing> _listings = new Dictionary<string, RoomListing>();

        public void OnClick_CreateRoom()
        {
            PhotonMaster.Instance.CreateRoom(nameInputText.text);
            Debug.Log("Creating room...");
        }

        public override void OnCreatedRoom()
        {
            MenuManager.Instance.ChangeMenu(2);
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (var info in roomList)
            {
                // Remove room Listing.
                if (_listings.ContainsKey(info.Name) && info.RemovedFromList)
                {
                    Destroy(_listings[info.Name].gameObject);
                    _listings.Remove(info.Name);
                }

                if (!info.RemovedFromList)
                {
                    // Add new room listing.
                    if (!_listings.ContainsKey(info.Name))
                    {
                        var listing = Instantiate(roomListingPrefab, contentTrans).GetComponent<RoomListing>();
                        listing.SetInfo(info.Name, "Unknown Player", info.PlayerCount, info.MaxPlayers);

                        _listings.Add(info.Name, listing);
                    }

                    // Update room listing.
                    else
                    {
                        _listings[info.Name].SetInfo(info.Name, "Unknown Player", info.PlayerCount, info.MaxPlayers);
                    }
                }
            }
        }
    }
}
