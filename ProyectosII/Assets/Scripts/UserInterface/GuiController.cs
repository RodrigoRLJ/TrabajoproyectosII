using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UserInterface
{
    public class GuiController : MonoBehaviour
    {
        #region Atributes

        private bool _menuActive = false;

        #endregion

        #region State manager functions

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

        #endregion

        #region User accesible functios

        public void QuitGame()
        {
            Debug.Log("I'm clicked!!!");
            GameManager.QuitGame();
        }

        public void CloseMenu()
        {
            this.ChangeMenuStateState();
        }

        public void GoToHomeScreen()
        {
            GameManager.ChangeScene("MainMenu");
        }

        #endregion
    }
}