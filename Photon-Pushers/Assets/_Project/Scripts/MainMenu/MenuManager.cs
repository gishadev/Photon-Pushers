using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] menus;

        public void OnClick_ChangeMenu(int menuToChange)
        {
            for (int i = 0; i < menus.Length; i++)
                menus[i].SetActive(false);
            menus[menuToChange].SetActive(true);
        }
    }
}
