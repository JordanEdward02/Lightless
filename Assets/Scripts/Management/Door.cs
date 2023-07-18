using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Room parentRoom;

    private void OnTriggerEnter(Collider other) {
        parentRoom.spawnNewRoom(transform.localPosition);
    }
}
