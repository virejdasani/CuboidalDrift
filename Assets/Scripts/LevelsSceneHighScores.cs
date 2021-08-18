using TMPro;
using UnityEngine;

public class LevelsSceneHighScores : MonoBehaviour
{
    public TextMeshPro level1HighScoreText;
    public TextMeshPro level2HighScoreText;
    public TextMeshPro level3HighScoreText;
    public TextMeshPro level4HighScoreText;

    public GameObject level1Cube;
    public GameObject level2Cube;
    public GameObject level3Cube;
    public GameObject level4Cube;

    public Material disabledColorMaterial;
    public Material enabledColorMaterial;

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

            // This part is to check which levels the player can access, depending on the previous levels they have completed
            // Check if the highScore for Level1 is == 0.0 If it is, then the level is incomplete
            if (PlayerPrefs.GetFloat("highScoreLevel1").ToString("f1") == "0.0")
            {
                // We take all the cubes after the last incomplete level and set them to the disabled color
                level2Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level3Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level4Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level2 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel2").ToString("f1") == "0.0")
            {
                level3Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level4Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level3 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel3").ToString("f1") == "0.0")
            {
                level4Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level4 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel4").ToString("f1") == "0.0")
            {
                //level5Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

        }
    }

}
