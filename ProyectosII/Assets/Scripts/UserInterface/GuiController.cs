using UnityEngine;

namespace UserInterface
{
    public class GuiController : MonoBehaviour
    {
        private bool _menuActive = false;

        private void Awake()
        {
            EventSystem.ChangeFastMenuState += this.ChangeMenuStateState;
            this.gameObject.SetActive(_menuActive);
        }

        private void OnDestroy()
        {
            EventSystem.ChangeFastMenuState -= this.ChangeMenuStateState;
        }

        private void ChangeMenuStateState()
        {
            this._menuActive = !this._menuActive;
            if (this._menuActive)
            {
                GameManager.PauseGame();
            }
            else
            {
                GameManager.ResumeGame();
            }

            this.gameObject.SetActive(_menuActive);
        }
    }
}