using UnityEngine;

[CreateAssetMenu(fileName = "Rooms_connections", menuName = "Rooms/Connection")]
public class RoomConnection : ScriptableObject
{
    public static RoomConnection ActiveConnection { get; set; }
}
