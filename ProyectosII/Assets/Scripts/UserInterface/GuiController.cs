using System;
using Unity.VisualScripting;
using UnityEngine;

namespace UserInterface
{
    public class GuiController : MonoBehaviour
    {
        private bool _menuActive = false;

        private void Awake()
        {
            EventSystem.ChangeFastMenuState += this.ChangeMenuStateState;
        }

        private void OnDestroy()
        {
            EventSystem.ChangeFastMenuState -= this.ChangeMenuStateState;
        }

        private void ChangeMenuStateState()
        {
            this._menuActive = !this._menuActive;
            this.gameObject.SetActive(_menuActive);
        }
    }
}