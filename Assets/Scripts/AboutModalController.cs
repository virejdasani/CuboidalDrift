using UnityEngine;

public class AboutModalController : MonoBehaviour
{
    public void LinkToGitHub()
    {
        Application.OpenURL("http://github.com/virejdasani/CuboidalDrift");
    }

    public void LinkToVirejDasani()
    {
        Application.OpenURL("http://virejdasani.github.io/");
    }
}
