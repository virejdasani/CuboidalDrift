using UnityEngine;

public class AboutModalCaller : MonoBehaviour
{

    public GameObject AboutModal;

    private bool aboutModalVisible;

    private void Start()
    {
        aboutModalVisible = false;
    }

    public void toggleAboutModal()
    {
        if (!aboutModalVisible)
        {
            AboutModal.gameObject.SetActive(true);
        }
        else
        {
            AboutModal.gameObject.SetActive(false);
        }
    }
}
