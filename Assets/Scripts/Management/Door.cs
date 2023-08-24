using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Room parentRoom;
    public Transform doorOrigin; // Used to correctly orient the room

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            parentRoom.spawnNewRoom(transform.position, doorOrigin);
    }
}
