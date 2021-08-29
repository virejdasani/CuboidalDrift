using UnityEngine;
using TMPro;

public class TimeScore : MonoBehaviour
{
    // In every level, there are 4 TextMeshPros
    // 2 at the start, 2 at the finish. They show the time passed and lowest time that was to complete that level (highscore)
    public TextMeshPro thisScoreText;
    public TextMeshPro highScoreText;
    public TextMeshPro thisScoreText2;
    public TextMeshPro highScoreText2;

    public string thisSceneName;

    private float thisScore;
    private float highScore;
    private float startTime;

    private bool levelComplete;
    private bool playerOnSurface;
    private bool isTimerStarted;

    // PlayGames leaderboard ids from play console
    private string leaderboardLevel1 = "CgkInoKH190DEAIQBw";
    private string leaderboardLevel2 = "CgkInoKH190DEAIQCA";
    private string leaderboardLevel3 = "CgkInoKH190DEAIQCQ";
    private string leaderboardLevel4 = "CgkInoKH190DEAIQCg";
    private string leaderboardLevel5 = "CgkInoKH190DEAIQCw";
    private string leaderboardLevel6 = "CgkInoKH190DEAIQDA";
    private string leaderboardLevel7 = "CgkInoKH190DEAIQDQ";
    private string leaderboardLevel8 = "CgkInoKH190DEAIQDg";
    private string leaderboardLevel9 = "CgkInoKH190DEAIQEg";
    private string leaderboardLevel10 = "CgkInoKH190DEAIQEw";
    private string leaderboardLevel11 = "CgkInoKH190DEAIQFA";
    private string leaderboardLevel12 = "CgkInoKH190DEAIQFQ";
    private string leaderboardLevel13 = "CgkInoKH190DEAIQFw";
    private string leaderboardLevel14 = "CgkInoKH190DEAIQGQ";
    private string leaderboardLevel15 = "CgkInoKH190DEAIQGA";
    private string leaderboardLevel16 = "CgkInoKH190DEAIQGg";

    void Start()
    {
        // This bool is needed so we know when to stop thisScoreText from increasing
        levelComplete = false;

        // This is needed so we know when to start the timer (as soon as the player hits the surface)
        playerOnSurface = false;

        // This is so that once the timer is started, we don't restart it everytime we hit a surface
        isTimerStarted = false;

        // The initial score is 0.0(seconds)
        thisScore = 0.0f;

        // This works like localStorage.getItem(). The key is highScore+thisSceneName so that we can store different highscores for different levels. We have to set thisSceneName from the unity editor. The key would look like this: "highScoreLevel1" for level 1
        highScore = PlayerPrefs.GetFloat("highScore" + thisSceneName);

        // Check if the text object where we display the highscore time, exists. It only exists in levels and not in scenes like homepage. Without checking this, there is are 2 errors thrown per scene
        if (highScoreText && highScoreText2)
        {
            // We set the highscore to 1 d.p. It looks like this: "BEST TIME: 13.8"
            highScoreText.text = "BEST TIME: " + highScore.ToString("f1");
            highScoreText2.text = "BEST TIME: " + highScore.ToString("f1");
        }
    }

    void Update()
    {
        // Check if the player has hit the surface and check if the text objects where we display the time, exist. They only exists in levels and not in scenes like homepage. Without checking this, there are errors thrown constantly
        if (playerOnSurface && thisScoreText && thisScoreText2)
        {
            // This is the current score/time. It is basically the start time - the current time = time elapsed
            thisScore = Time.time - startTime;

            // If the level is not finished. If the level is complete, we don't want the timer to keep increasing
            if (!levelComplete)
            {
                // This time text is updated in realtime, unlike the highscore
                thisScoreText.text = "TIME: " + thisScore.ToString("f1");
                thisScoreText2.text = "TIME: " + thisScore.ToString("f1");
            }
        }

    }

    // This is so that when the playerCube hits the finishCube, we can check if the timeScore this attempt was lesser than the highScore. If it is, we have a new highScore. 
    private void OnCollisionEnter(Collision collision)
    {
        // Check if player hit the finishCube
        if (collision.gameObject.tag == "FinishCube")
        {
            // When this becomes true, the timer stops updating the time elapsed
            levelComplete = true;

            // Check if new highScore. The highScore is the time taken to complete the level. So, lower time is better. If highScore == 0, this means the level hasn't been completed even once yet.
            if (thisScore < highScore || highScore == 0)
            {
                Debug.Log("setting" + thisSceneName);
                // Save the new highScore
                PlayerPrefs.SetFloat("highScore" + thisSceneName, thisScore);

                // This is to add the new highscore to the PlayGames leaderboard
                if (thisSceneName == "Level1")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel1 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel1") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel1 / 10, leaderboardLevel1);
                }

                else if (thisSceneName == "Level2")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel2 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel2") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel2 / 10, leaderboardLevel2);
                }

                else if (thisSceneName == "Level3")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel3 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel3") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel3 / 10, leaderboardLevel3);
                }

                else if (thisSceneName == "Level4")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel4 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel4") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel4 / 10, leaderboardLevel4);
                }

                else if (thisSceneName == "Level5")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel5 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel5") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel5 / 10, leaderboardLevel5);
                }

                else if (thisSceneName == "Level6")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel6 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel6") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel6 / 10, leaderboardLevel6);
                }

                else if (thisSceneName == "Level7")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel7 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel7") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel7 / 10, leaderboardLevel7);
                }

                else if (thisSceneName == "Level8")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel8 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel8") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel8 / 10, leaderboardLevel8);
                }

                else if (thisSceneName == "Level9")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel9 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel9") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel9 / 10, leaderboardLevel9);
                }

                else if (thisSceneName == "Level10")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel10 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel10") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel10 / 10, leaderboardLevel10);
                }

                else if (thisSceneName == "Level11")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel11 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel11") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel11 / 10, leaderboardLevel11);
                }

                else if (thisSceneName == "Level12")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel12 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel12") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel12 / 10, leaderboardLevel12);
                }


                else if (thisSceneName == "Level13")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel13 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel13") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel13 / 10, leaderboardLevel13);
                }

                else if (thisSceneName == "Level14")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel14 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel14") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel14 / 10, leaderboardLevel14);
                }

                else if (thisSceneName == "Level15")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel15 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel15") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel15 / 10, leaderboardLevel15);
                }

                else if (thisSceneName == "Level16")
                {
                    // This is needed or else in the leaderboard, there is weird decimal behaviour, DONT TOUCH
                    // When copy pasting these, change level number in 4 places. 2 in the first line and 2 in the next
                    float playGamesLevel16 = Mathf.Floor(PlayerPrefs.GetFloat("highScoreLevel16") * 1000);
                    PlayGames.AddScoreToLeaderboard((long)playGamesLevel16 / 10, leaderboardLevel16);
                }

            }

        }

        if (collision.gameObject.tag == "Surface")
        {
            playerOnSurface = true;

            if (!isTimerStarted)
            {
                // This is the time when the player hits the surface starts
                startTime = Time.time;

                // Once the startTime is set, we set isTimerStarted to true so that we don't reset it
                isTimerStarted = true;
            }
        }

    }
}
