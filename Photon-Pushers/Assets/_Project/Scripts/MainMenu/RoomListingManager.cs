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

        Dictionary<string, RoomListing> _listings = new Dictionary<string, RoomListing>();

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
            DestroyListings();

            foreach (var info in roomList)
            {
                var listing = Instantiate(roomListingPrefab, contentTrans).GetComponent<RoomListing>();
                listing.SetInfo(info);

                _listings.Add(info.Name, listing);
            }
        }

        private void DestroyListings()
        {
            foreach (var l in _listings)
                Destroy(l.Value.gameObject);

            _listings = new Dictionary<string, RoomListing>();
        }
    }
}
