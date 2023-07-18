using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public Room[] possibleRooms;

    private List<GameObject> currentRooms;

    void Start()
    {
        currentRooms = new List<GameObject>();
        GameObject newRoom = Instantiate(possibleRooms[0].roomPrefab);
        newRoom.GetComponent<Room>().roomManager = this;
        currentRooms.Add(newRoom);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnNewRoom(Vector3 position)
    {
        Debug.Log(position);
    }
}
