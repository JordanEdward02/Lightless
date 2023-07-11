using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;
    public Rigidbody body;

    [Header("Movement Modifiers")]
    public float moveSpeed = 5f;
    public float dashDistance = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 4f;

    // private field to store move action reference
    private InputAction moveAction;

    void Awake()
    {
        // find the "move" action, and keep the reference to it, for use in Update
        moveAction = actions.FindActionMap("gameplay").FindAction("move");
    }

    void Update()
    {
        // our update loop polls the "move" action value each frame
        Vector2 moveVector = moveAction.ReadValue<Vector2>() * 15;
        body.velocity = Quaternion.AngleAxis(45, Vector3.up) * new Vector3(moveVector.x, 0, moveVector.y);
    }

    void OnEnable()
    {
        actions.FindActionMap("gameplay").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("gameplay").Disable();
    }
}
