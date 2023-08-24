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
        Room ourRoom = newRoom.GetComponent<Room>();
        ourRoom.roomManager = this;
        ourRoom.currentRoom = true;
        currentRooms.Add(newRoom);
    }


    /*
    Spawns a random room with external doors relative to the current room.

    Note: By external doors this means that the doors go towards the centre of the room
    */
    public void spawnNewRoom(Vector3 currentPosition, Transform currentOrigin)
    {

        // angle to the current door
        float currentAngle = Mathf.Atan2(currentPosition.x-currentOrigin.position.x, currentPosition.z-currentOrigin.position.z)*180 / Mathf.PI;
        currentAngle = Mathf.Round(currentAngle / 90.0f) * 90.0f; // snaps to nearest 90 degrees

        // select new door from new room
        int randRoom = Random.Range(0,possibleRooms.Length);
        Room chosenRoom = possibleRooms[randRoom];
        int randDoor = Random.Range(0,chosenRoom.doors.Length);
        Door chosenDoor = possibleRooms[randRoom].doors[randDoor];
        Vector3 newRoomPos = -chosenDoor.transform.localPosition;
        newRoomPos.y = 0f;

        // Create new room object
        GameObject newRoom = Instantiate(possibleRooms[randRoom].roomPrefab);

        // Get angle from new room origin to door
        float newAngle = Mathf.Atan2(chosenDoor.transform.localPosition.x-newRoom.transform.position.x, chosenDoor.transform.localPosition.z-newRoom.transform.position.z)*180 / Mathf.PI;
        newAngle = Mathf.Round(newAngle / 90.0f) * 90.0f; // snaps to nearest 90 degrees

        // Position and rotate the new room
        newRoom.transform.position = new Vector3(newRoomPos.x, 0, newRoomPos.z);
        newRoom.transform.position += new Vector3(currentPosition.x, 0f, currentPosition.z);
        newRoom.transform.RotateAround(newRoom.transform.position + chosenDoor.transform.position, Vector3.up, Mathf.DeltaAngle(newAngle, currentAngle)-180);


        /*
        Debug.Log(newRoom.transform.position + chosenDoor.transform.position);
        Debug.Log("CHOSE DOOR:");
        Debug.Log(rand);
        Debug.Log("SO WE ROTATE:");
        Debug.Log("CURRENT ROOM ANGLE = " + currentAngle + " NEW ROOM ANGLE = " + newAngle + " WHICH GIVES US DIFFERENCE OF = " + (Mathf.DeltaAngle(newAngle, currentAngle)-180));
        */

        // Remove old room and store new one within the currentRooms list
        Destroy(currentRooms[0]);
        currentRooms.RemoveAt(0);
        currentRooms.Add(newRoom);

        // Set up the new room correctly
        Room ourRoom = newRoom.GetComponent<Room>();
        ourRoom.roomManager = this;

        // Room manager needs to be centered in the new room so that it's angles work out.
        transform.position = newRoom.transform.position;
    }
}
