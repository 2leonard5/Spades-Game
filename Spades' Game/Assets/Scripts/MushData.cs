using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class MushData : ScriptableObject 
{
    public int hp;
    public int damage;
    public int speed;
}
