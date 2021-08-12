using UnityEngine;

public class AboutModalController : MonoBehaviour
{
    public GameObject AboutModal;

    public void LinkToGitHub()
    {
        Application.OpenURL("http://github.com/virejdasani/CuboidalDrift");
    }

    public void LinkToVirejDasani()
    {
        Application.OpenURL("http://virejdasani.github.io/");
    }

    public void CloseAboutModal()
    {
        // Hide the modal
        AboutModal.gameObject.SetActive(false);
    }
}