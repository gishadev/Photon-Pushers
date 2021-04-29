using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Gisha.Pushers.MainMenu
{
    public class MenuManager : MonoBehaviourPunCallbacks
    {
        #region Singleton
        public static MenuManager Instance { get; private set; }
        #endregion

        [SerializeField] private GameObject[] menus;
        [SerializeField] private GameObject connectingText;
        [SerializeField] private Button playBtn;

        private void Awake()
        {
            Instance = this;
        }

        public override void OnJoinedLobby()
        {
            connectingText.SetActive(false);
            playBtn.interactable = true;
        }

        public override void OnLeftLobby()
        {
            connectingText.SetActive(true);
            playBtn.interactable = false;
        }

        public void ChangeMenu(int menuToChange)
        {
            for (int i = 0; i < menus.Length; i++)
                menus[i].SetActive(false);
            menus[menuToChange].SetActive(true);
        }
    }
}
