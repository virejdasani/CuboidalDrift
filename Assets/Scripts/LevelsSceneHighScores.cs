using UnityEngine;
using TMPro;

public class LevelsSceneHighScores : MonoBehaviour
{
    public TextMeshPro level1HighScoreText;
    public TextMeshPro level2HighScoreText;
    public TextMeshPro level3HighScoreText;
    public TextMeshPro level4HighScoreText;
    //public TextMeshPro level5HighScoreText;


    void Start()
    {
        // Check if atleast 1 of these texts exist
        if (level1HighScoreText)
        {
            // This sets the text in the scene to something like: "BEST: 10.3s"
            level1HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel1").ToString("f1") + "s";
            level2HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel2").ToString("f1") + "s";
            level3HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel3").ToString("f1") + "s";
            level4HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel4").ToString("f1") + "s";
            //level5HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel5").ToString("f1") + "s";
        }
    }

}
