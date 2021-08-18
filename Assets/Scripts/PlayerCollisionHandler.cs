using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    protected Rigidbody rb;

    // This is the transition time when changing scenes (Faster this number = less time for transition)
    public float fadeSpeed = 2.0f;

    public GameObject AboutModal;
    public GameObject SettingsModal;

    void Start()
    {
        // Get the rigidbody
        rb = GetComponent<Rigidbody>();

        // If about modal exists in this scene
        if (AboutModal)
        {
            // At the start, we dont show the about modal
            AboutModal.gameObject.SetActive(false);
        }

        // If settings modal exists in this scene
        if (SettingsModal)
        {
            // At the start, we dont show the settings modal
            SettingsModal.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "GoToHomeCube")
        {
            LoadScene("HomePage");
        }

        else if (collision.gameObject.name == "GoToLevelsCube")
        {
            LoadScene("Levels");
        }

        // Levels
        else if (collision.gameObject.name == "GoToLevel1")
        {
            LoadScene("Level1");
        }

        else if (collision.gameObject.name == "GoToLevel2")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel1").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level2");
        }

        else if (collision.gameObject.name == "GoToLevel3")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel2").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level3");
        }

        else if (collision.gameObject.name == "GoToLevel4")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel3").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level4");
        }

        else if (collision.gameObject.name == "LastLevelFinishCube")
        {
            LoadScene("MoreLevelsComingSoon");
        }

        else if (collision.gameObject.name == "GitHubCube")
        {
            Application.OpenURL("http://github.com/virejdasani/CuboidalDrift");
        }

        else if (collision.gameObject.name == "AboutCube")
        {
            // When the user hits the about cube, the modal pops up by unhiding the canvas that was previously set to hidden = SetActive(false);
            AboutModal.gameObject.SetActive(true);
        }

        else if (collision.gameObject.name == "SettingsCube")
        {
            // When the user hits the settings cube, the modal pops up by unhiding the canvas that was previously set to hidden = SetActive(false);
            SettingsModal.gameObject.SetActive(true);
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
