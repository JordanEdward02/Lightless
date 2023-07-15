using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public Room[] possibleRooms;

    private List<Object> currentRooms;

    void Start()
    {
        Object newRoom = Instantiate(possibleRooms[0].roomPrefab);
        //currentRooms.Add(newRoom);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
