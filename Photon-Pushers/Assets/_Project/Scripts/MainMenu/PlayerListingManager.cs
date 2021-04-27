using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class PlayerListingManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform contentTrans;
        [SerializeField] private GameObject playerListingPrefab;

        Dictionary<string, PlayerListing> _listings = new Dictionary<string, PlayerListing>();

        public override void OnJoinedRoom()
        {
            CreateNewListings();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            DeleteOldListings();
            CreateNewListings();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            DeleteOldListings();
            CreateNewListings();
        }

        private void CreateNewListings()
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                var listing = Instantiate(playerListingPrefab, contentTrans).GetComponent<PlayerListing>();
                listing.SetInfo(player.NickName);

                _listings.Add(player.NickName, listing);
            }
        }

        private void DeleteOldListings()
        {
            foreach (var l in _listings)
                Destroy(l.Value.gameObject);

            _listings = new Dictionary<string, PlayerListing>();
        }

        //public override void OnRoomListUpdate(List<RoomInfo> roomList)
        //{
        //    foreach (var info in roomList)
        //    {
        //        // Remove room Listing.
        //        if (listings.ContainsKey(info.Name) && info.RemovedFromList)
        //        {
        //            Destroy(listings[info.Name].gameObject);
        //            listings.Remove(info.Name);
        //        }

        //        if (!info.RemovedFromList)
        //        {
        //            // Add new room listing.
        //            if (!listings.ContainsKey(info.Name))
        //            {
        //                var listing = Instantiate(roomListingPrefab, contentTrans).GetComponent<RoomListing>();
        //                listing.SetInfo(info.Name, "Unknown Player", info.PlayerCount, info.MaxPlayers);

        //                listings.Add(info.Name, listing);
        //            }

        //            // Update room listing.
        //            else
        //            {
        //                listings[info.Name].SetInfo(info.Name, "Unknown Player", info.PlayerCount, info.MaxPlayers);
        //            }
        //        }
        //    }
        //}

    }
}