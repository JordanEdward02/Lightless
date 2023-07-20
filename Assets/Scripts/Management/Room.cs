using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject roomPrefab;
    public Door[] doors;
    public Transform roomOrigin;

    [HideInInspector] public RoomManager roomManager;
    [HideInInspector] public bool currentRoom = false;

    public void spawnNewRoom(Vector3 position){
        if (currentRoom){
            roomManager.spawnNewRoom(position, roomOrigin);
            currentRoom = false;
        }
        else{
            currentRoom = true;
        }
    }
}
