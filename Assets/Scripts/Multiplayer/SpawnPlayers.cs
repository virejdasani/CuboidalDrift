using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject onlinePlayerPrefab;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3(0, 8, 0);

        PhotonNetwork.Instantiate(onlinePlayerPrefab.name, spawnPosition, Quaternion.identity);
    }
}
