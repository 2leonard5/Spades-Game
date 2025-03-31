using System;
using System.Collections;
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

    public Animator Animator;

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
            StartCoroutine(SceneTrans());
        }
    }

    IEnumerator SceneTrans()
    {
        Animator.SetTrigger("FadeIn");
        SceneManager.LoadSceneAsync(targetSceneName);
        yield return new WaitForSeconds(0.01f);
    }
    
}
