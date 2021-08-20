using TMPro;
using UnityEngine;

public class LevelsSceneHighScores : MonoBehaviour
{
    public TextMeshPro level1HighScoreText;
    public TextMeshPro level2HighScoreText;
    public TextMeshPro level3HighScoreText;
    public TextMeshPro level4HighScoreText;
    public TextMeshPro level5HighScoreText;
    public TextMeshPro level6HighScoreText;
    public TextMeshPro level7HighScoreText;
    public TextMeshPro level8HighScoreText;
    public TextMeshPro level9HighScoreText;
    public TextMeshPro level10HighScoreText;
    public TextMeshPro level11HighScoreText;
    public TextMeshPro level12HighScoreText;

    public GameObject level1Cube;
    public GameObject level2Cube;
    public GameObject level3Cube;
    public GameObject level4Cube;
    public GameObject level5Cube;
    public GameObject level6Cube;
    public GameObject level7Cube;
    public GameObject level8Cube;
    public GameObject level9Cube;
    public GameObject level10Cube;
    public GameObject level11Cube;
    public GameObject level12Cube;

    public GameObject goToNextPageCube;

    public Material disabledColorMaterial;
    public Material enabledColorMaterial;

    void Start()
    {
        // This is for Levels Scene
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
                goToNextPageCube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level2 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel2").ToString("f1") == "0.0")
            {
                level3Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level4Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                goToNextPageCube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level3 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel3").ToString("f1") == "0.0")
            {
                level4Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                goToNextPageCube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level4 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel4").ToString("f1") == "0.0")
            {
                goToNextPageCube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

        }

        // This is for Levels2 Scene
        else if (level5HighScoreText)
        {
            // This sets the text in the scene to something like: "BEST: 10.3s"
            level5HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel5").ToString("f1") + "s";
            level6HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel6").ToString("f1") + "s";
            level7HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel7").ToString("f1") + "s";
            level8HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel8").ToString("f1") + "s";

            // This part is to check which levels the player can access, depending on the previous levels they have completed
            // Check if the highScore for Level1 is == 0.0 If it is, then the level is incomplete
            if (PlayerPrefs.GetFloat("highScoreLevel5").ToString("f1") == "0.0")
            {
                // We take all the cubes after the last incomplete level and set them to the disabled color
                level6Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level7Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level8Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level2 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel6").ToString("f1") == "0.0")
            {
                level7Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level8Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level3 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel7").ToString("f1") == "0.0")
            {
                level8Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level4 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel8").ToString("f1") == "0.0")
            {
                goToNextPageCube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }
        }


        // This is for Levels3 Scene
        else if (level9HighScoreText)
        {
            // This sets the text in the scene to something like: "BEST: 10.3s"
            level5HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel9").ToString("f1") + "s";
            level6HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel10").ToString("f1") + "s";
            level7HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel11").ToString("f1") + "s";
            level8HighScoreText.text = "BEST: " + PlayerPrefs.GetFloat("highScoreLevel12").ToString("f1") + "s";

            // This part is to check which levels the player can access, depending on the previous levels they have completed
            // Check if the highScore for Level1 is == 0.0 If it is, then the level is incomplete
            if (PlayerPrefs.GetFloat("highScoreLevel9").ToString("f1") == "0.0")
            {
                // We take all the cubes after the last incomplete level and set them to the disabled color
                level10Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level11Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level12Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level2 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel10").ToString("f1") == "0.0")
            {
                level11Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
                level12Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level3 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel11").ToString("f1") == "0.0")
            {
                level12Cube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

            // Check if the highScore for Level4 is == 0.0 If it is, then the level is incomplete
            else if (PlayerPrefs.GetFloat("highScoreLevel12").ToString("f1") == "0.0")
            {
                //goToNextPageCube.GetComponent<MeshRenderer>().material = disabledColorMaterial;
            }

        }
    }
}
