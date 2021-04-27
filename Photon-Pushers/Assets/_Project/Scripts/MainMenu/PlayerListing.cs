using TMPro;
using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class PlayerListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        public void SetInfo(string name)
        {
            nameText.text = name;
        }
    }
}
