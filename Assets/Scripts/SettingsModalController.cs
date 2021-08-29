using UnityEngine;

public class SettingsModalController : MonoBehaviour
{
    public GameObject SettingsModal;

    public void AudioOn()
    {
        AudioListener.volume = 1;
    }

    public void AudioOff()
    {
        AudioListener.volume = 0;
    }

    public void BackToLevels()
    {
        Initiate.Fade("LevelsSelector", Color.black, 3.0f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CloseSettingsModal()
    {
        // Hide the modal
        SettingsModal.gameObject.SetActive(false);
    }
}