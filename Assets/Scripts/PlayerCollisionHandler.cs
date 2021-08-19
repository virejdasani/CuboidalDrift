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

        // For ads
        AdManager.instance.RequestInterstitial();
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

        else if (collision.gameObject.name == "GoToLevels2Cube")
        {
            // Check that the GoToLevels2Cube has the ShowAd tag. This only exits in the Levels2 scene
            if (collision.gameObject.tag == "ShowAd")
                // Shows the interstitial ad
                AdManager.instance.ShowInterstitial();

            // This is the page 2 of the levels scene
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel4").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Levels2");
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
            // If the collision is when player just completed level 3. Don't show ads in the levels scences
            if (collision.gameObject.tag == "FinishCube")
                // Show the interstitial ad
                AdManager.instance.ShowInterstitial();

            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel3").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level4");
        }

        else if (collision.gameObject.name == "GoToLevel5")
        {
            LoadScene("Level5");
        }

        else if (collision.gameObject.name == "GoToLevel6")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel5").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level6");
        }

        else if (collision.gameObject.name == "GoToLevel7")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel6").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level7");
        }

        else if (collision.gameObject.name == "GoToLevel8")
        {
            // If the collision is when player just completed level 7. Don't show ads in the levels scences
            if (collision.gameObject.tag == "FinishCube")
                // Show the interstitial ad
                AdManager.instance.ShowInterstitial();

            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel7").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level8");
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
