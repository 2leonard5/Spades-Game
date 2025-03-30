using JetBrains.Annotations;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    private GameObject Player;
    public Vector3 offset = new Vector3(4f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float speed;
    private Vector3 targetposition = Vector3.zero;
    public float xBoundMin;
    public float xBoundMax;
    public float yBoundMin;
    public float yBoundMax;
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        
        if (Player.transform.localScale.x == 1)
            targetposition.x = Mathf.Clamp(Player.transform.position.x + offset.x, xBoundMin, xBoundMax);
        else
            targetposition.x = Mathf.Clamp(Player.transform.position.x - offset.x, xBoundMin, xBoundMax);
        targetposition.z = Player.transform.position.z + offset.z;
        targetposition.y = Mathf.Clamp(Player.transform.position.y + offset.y, yBoundMin, yBoundMax);
        transform.position = Vector3.Lerp(transform.position, targetposition, speed * Time.deltaTime);

    }
}
