using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject roomPrefab;
    public Door[] doors;
    //public Transform roomOrigin; // Change origin so that each individual DOOR has an origin so we can have convex and irregular rooms.
    // Note the origins don't have to be uniique, so existing rooms should work if we assign the origin to all of the doors.

    [HideInInspector] public RoomManager roomManager;
    [HideInInspector] public bool currentRoom = false;

    public void spawnNewRoom(Vector3 position, Transform doorOrigin){
        if (currentRoom){
            roomManager.spawnNewRoom(position, doorOrigin);
            currentRoom = false;
        }
        else{
            currentRoom = true;
        }
    }
}
