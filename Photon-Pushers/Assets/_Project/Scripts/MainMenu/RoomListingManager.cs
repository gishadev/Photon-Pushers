using Gisha.Pushers.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class RoomListingManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform contentTrans;
        [SerializeField] private GameObject roomListingPrefab;
        [SerializeField] private TMP_Text nameInputText;

        List<RoomListing> _listings = new List<RoomListing>();

        public void OnClick_CreateRoom()
        {
            PhotonMaster.Instance.CreateRoom(nameInputText.text);
            Debug.Log("Creating room...");
        }

        public void OnClick_Refresh()
        {
            RefreshListings(PhotonMaster.Instance.Rooms);
        }

        public override void OnJoinedRoom()
        {
            MenuManager.Instance.ChangeMenu(2);
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            RefreshListings(roomList);
        }

        private void RefreshListings(List<RoomInfo> roomList)
        {
            foreach (RoomInfo info in roomList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);

                // Destroying listing if room was removed.
                if (info.RemovedFromList && index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }

                else if (!info.RemovedFromList)
                {
                    // Adding a new room listing.
                    if (index == -1)
                    {
                        RoomListing listing = Instantiate(roomListingPrefab, contentTrans).GetComponent<RoomListing>();
                        listing.SetInfo(info);

                        _listings.Add(listing);
                    }

                    // Modifying room listing info.
                    else
                        _listings[index].SetInfo(info);
                }
            }
        }
    }
}
