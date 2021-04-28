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

        // Dictionary<string, PlayerListing> _listings = new Dictionary<string, PlayerListing>();
        List<PlayerListing> _listings = new List<PlayerListing>();

        public override void OnJoinedRoom()
        {
            DeleteOldListings();
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

                _listings.Add(listing);
            }
        }

        public void DeleteOldListings()
        {
            foreach (var l in _listings)
                Destroy(l.gameObject);

            _listings = new List<PlayerListing>();
        }
    }
}