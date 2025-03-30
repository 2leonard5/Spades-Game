using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Change : MonoBehaviour
{
    private GameObject Player1;
    [SerializeField]
    private RoomConnection roomConnection;

    [SerializeField]
    private string targetSceneName;

    [SerializeField]
    private Transform spawnPoint;

    private void Start()
    {
        Player1 = GameObject.Find("Player");
        if (roomConnection == RoomConnection.ActiveConnection)
        {
            Player1.transform.position = spawnPoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<player>();
        if (player != null)
        {
            RoomConnection.ActiveConnection = roomConnection;
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
