using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class MenuManager : MonoBehaviour
    {
        #region Singleton
        public static MenuManager Instance { get; private set; }
        #endregion

        [SerializeField] private GameObject[] menus;

        private void Awake()
        {
            Instance = this;
        }

        public void ChangeMenu(int menuToChange)
        {
            for (int i = 0; i < menus.Length; i++)
                menus[i].SetActive(false);
            menus[menuToChange].SetActive(true);
        }
    }
}
