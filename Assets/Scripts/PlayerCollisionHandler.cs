using UnityEngine;

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

        else if (collision.gameObject.name == "GoToLevelsSelectorCube")
        {
            LoadScene("LevelsSelector");
        }

        else if (collision.gameObject.name == "GoToLevelsCube")
        {
            LoadScene("Levels");
        }

        else if (collision.gameObject.name == "GoToLevels2Cube")
        {
            // Check that the GoToLevels2Cube has the ShowAd tag. This only exits in the Levels2 scene
            if (collision.gameObject.tag == "ShowAd")
            {
                // 10% of the times, when the player dies, an ad is shown
                // Get a random num from 1 to 10
                System.Random random = new System.Random();
                int randNum = random.Next(1, 10);

                // If the random number is 1, which happens 10% of the times, show an ad
                if (randNum < 2)
                {
                    // Show the interstitial ad
                    AdManager.instance.ShowInterstitial();
                }
            }

            // This is the page 2 of the levels scene
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel4").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Levels2");
        }

        else if (collision.gameObject.name == "GoToLevels3Cube")
        {
            // Check that the GoToLevels2Cube has the ShowAd tag. This only exits in the Levels2 scene
            if (collision.gameObject.tag == "ShowAd")
            {
                // 10% of the times, when the player dies, an ad is shown
                // Get a random num from 1 to 10
                System.Random random = new System.Random();
                int randNum1 = random.Next(1, 10);

                // If the random number is 1, which happens 10% of the times, show an ad
                if (randNum1 < 2)
                {
                    // Show the interstitial ad
                    AdManager.instance.ShowInterstitial();
                }
            }

            // This is the page 3 of the levels scene
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel8").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Levels3");
        }

        else if (collision.gameObject.name == "GoToLevels4Cube")
        {
            // Check that the GoToLevels2Cube has the ShowAd tag. This only exits in the Levels2 scene
            if (collision.gameObject.tag == "ShowAd")
            {
                // 10% of the times, when the player dies, an ad is shown
                // Get a random num from 1 to 10
                System.Random random = new System.Random();
                int randNum1 = random.Next(1, 10);

                // If the random number is 1, which happens 10% of the times, show an ad
                if (randNum1 < 2)
                {
                    // Show the interstitial ad
                    AdManager.instance.ShowInterstitial();
                }
            }

            // This is the page 3 of the levels scene
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel12").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Levels4");
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
            if (PlayerPrefs.GetFloat("highScoreLevel4").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
            {
                LoadScene("Level5");
                // This is the reached Level 5 achievement
                PlayGames.UnlockAchievement("CgkInoKH190DEAIQBg");
            }
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

        else if (collision.gameObject.name == "GoToLevel9")
        {
            if (PlayerPrefs.GetFloat("highScoreLevel8").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
            {
                LoadScene("Level9");
                // This is the reached Level 9 achievement
                PlayGames.UnlockAchievement("CgkInoKH190DEAIQEQ");
            }
        }

        else if (collision.gameObject.name == "GoToLevel10")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel9").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level10");
        }

        else if (collision.gameObject.name == "GoToLevel11")
        {
            // If the collision is when player just completed level 7. Don't show ads in the levels scences
            if (collision.gameObject.tag == "FinishCube")
                // Show the interstitial ad
                AdManager.instance.ShowInterstitial();

            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel10").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level11");
        }

        else if (collision.gameObject.name == "GoToLevel12")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel11").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level12");
        }

        else if (collision.gameObject.name == "GoToLevel13")
        {
            if (PlayerPrefs.GetFloat("highScoreLevel12").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
            {
                LoadScene("Level13");
                // This is the reached Level 13 achievement
                PlayGames.UnlockAchievement("CgkInoKH190DEAIQFg");
            }
        }

        else if (collision.gameObject.name == "GoToLevel14")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel13").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level14");
        }

        else if (collision.gameObject.name == "GoToLevel15")
        {
            if (collision.gameObject.tag == "FinishCube")
                // Show the interstitial ad
                AdManager.instance.ShowInterstitial();

            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel14").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level15");
        }

        else if (collision.gameObject.name == "GoToLevel16")
        {
            // Check if the previous level has a highscore greater than 0.0. This means that level was completed. If this is true, they can access this level
            if (PlayerPrefs.GetFloat("highScoreLevel15").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("Level16");
        }

        else if (collision.gameObject.name == "LastLevelFinishCube")
        {
            if (PlayerPrefs.GetFloat("highScoreLevel16").ToString("f1") != "0.0" || collision.gameObject.tag == "FinishCube")
                LoadScene("MoreLevelsComingSoon");

            // This is the Expert Gamer achievemnet. Unlocked when all levels are completed
            PlayGames.UnlockAchievement("CgkInoKH190DEAIQDw");
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

        else if (collision.gameObject.name == "LeaderboardCube")
        {
            // Show the leaderboard ui
            PlayGames.ShowLeaderboard();
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
