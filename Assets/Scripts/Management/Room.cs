using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject roomPrefab;

    [HideInInspector] public RoomManager roomManager;
    [HideInInspector] public bool currentRoom = false;

    public void spawnNewRoom(Vector3 position){
        roomManager.spawnNewRoom(position);
    }
}
