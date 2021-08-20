using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public GameObject joinInput;
    public GameObject createInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.GetComponent<TMP_InputField>().text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.GetComponent<TMP_InputField>().text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Level1Multiplayer");
    }
}
