using UnityEngine;
using Photon.Pun;

public class OnlinePlayerCollisionHandler : MonoBehaviour
{
    protected Rigidbody rb;

    // This is the transition time when changing scenes (Faster this number = less time for transition)
    public float fadeSpeed = 2.0f;

    public GameObject AboutModal;
    public GameObject SettingsModal;

    PhotonView view;

    void Start()
    {
        // Get the rigidbody
        rb = GetComponent<Rigidbody>();

        // If settings modal exists in this scene
        if (SettingsModal)
        {
            // At the start, we dont show the settings modal
            SettingsModal.gameObject.SetActive(false);
        }

        // Get the photon view component attached to online player
        view = GetComponent<PhotonView>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FinishCube")
        {
            Debug.Log(view.sceneViewId);

            if (view.sceneViewId == 0)
            {
                Initiate.Fade("0win", Color.black, fadeSpeed);
                PhotonNetwork.DestroyPlayerObjects(0);
            }

            else if (view.sceneViewId == 1)
            {
                Initiate.Fade("0win", Color.black, fadeSpeed);
                PhotonNetwork.DestroyPlayerObjects(1);
            }

            //PhotonNetwork.DestroyAll();

        }

        if (collision.gameObject.name == "GoToHomeCube")
        {
            LoadScene("HomePage");
        }

        else if (collision.gameObject.name == "GoToLevelsCube")
        {
            LoadScene("Levels");
        }

        else if (collision.gameObject.name == "MultiplayerCube")
        {
            LoadScene("Loading");
        }
    }

    // This transitions to the passed in scene
    private void LoadScene(string sceneName)
    {
        // This (Initiate.Fade) function in from the Simple Fade Scene asset (from asset store)
        // It does this: "SceneManager.LoadScene("Levels");" and also adds transition animation to current scene and the scene we are transitioning to
        Initiate.Fade(sceneName, Color.black, fadeSpeed);
    }


}
