using UnityEngine;

namespace Start_Menu
{
    public class OnStart : MonoBehaviour
    {
        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject configMenu;

        public void Start()
        {
            var startButton = GetComponent<UnityEngine.UI.Button>();
            startButton.onClick.AddListener(StartCarConfig);
        }

        private void StartCarConfig()
        {
            startMenu.SetActive(false);
            configMenu.SetActive(true);
        }
    }
}
