using UnityEngine;
using TMPro;

public class TimeScore : MonoBehaviour
{
    // In every level, there are 4 TextMeshPros
    // 2 at the start, 2 at the finish. They show the time passed and lowest time to complete that level
    public TextMeshPro thisScoreText;
    public TextMeshPro highScoreText;
    public TextMeshPro thisScoreText2;
    public TextMeshPro highScoreText2;

    public string thisSceneName;

    private float thisScore;
    private float highScore;
    private float startTime;

    void Start()
    {
        // This is the time when the scene starts
        startTime = Time.time;

        // The initial score is 0.0(seconds)
        thisScore = 0.0f;

        // This works like localStorage.getItem(). The key is highScore+thisSceneName so that we can store different highscores for different levels. We have to set thisSceneName from the unity editor. The key would look like this: "highScoreLevel1" for level 1
        highScore = PlayerPrefs.GetFloat("highscore" + thisSceneName);

        // We set the highscore to 1 d.p. It looks like this: "BEST TIME: 13.8"
        highScoreText.text = "BEST TIME: " + highScore.ToString("f1");
        highScoreText2.text = "BEST TIME: " + highScore.ToString("f1");
    }

    void Update()
    {
        // This is the current score/time. It is basically the start time - the current time = time elapsed
        thisScore = Time.time - startTime;

        // This time text is updated in realtime, unlike the highscore
        thisScoreText.text = "TIME: " + thisScore.ToString("f1");
        thisScoreText2.text = "TIME: " + thisScore.ToString("f1");
    }

    // This is so that when the playerCube hits the finishCube, we can check if the timeScore this attempt was lesser than the highScore. If it is, we have a new highScore. 
    private void OnCollisionEnter(Collision collision)
    {
        // Check if player hit the finishCube
        if (collision.gameObject.tag == "FinishCube")
        {
            // Check if new highScore. The highScore is the time taken to complete the level. So, lower time is better. If highScore == 0, this means the level hasn't been completed even once yet.
            if (thisScore < highScore || highScore == 0)
            {
                // Save the new highScore
                PlayerPrefs.SetFloat("highscore" + thisSceneName, thisScore);
            }

        }
    }
}
