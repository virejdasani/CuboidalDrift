using UnityEngine;

public class HamburgerMenuController : MonoBehaviour
{
    public GameObject SettingsModal;

    private bool settingsActive = false;

    public void OpenSettings()
    {
        if (!settingsActive)
        {
            // Show the modal
            SettingsModal.gameObject.SetActive(true);

            settingsActive = true;
        }

        else
        {
            // Hide the modal
            SettingsModal.gameObject.SetActive(false);

            settingsActive = false;
        }
    }
}