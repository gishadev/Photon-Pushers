using UnityEngine;

namespace Gisha.Pushers.MainMenu
{
    public class CameraRigController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
