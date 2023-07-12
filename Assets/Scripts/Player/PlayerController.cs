using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputActionAsset actions;
    public Rigidbody rigidbody;
    public Transform playerTransform;

    [Header("Movement Modifiers")]
    public float moveSpeed = 5f;
    public float dashDistance = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;

    private float lastDash;
    private bool immobile = false;
    private InputAction moveAction;

    private Quaternion forwardRotation = Quaternion.AngleAxis(45, Vector3.up);

    void Awake()
    {
        // find the "move" action, and keep the reference to it, for use in Update
        moveAction = actions.FindActionMap("gameplay").FindAction("move");
        actions.FindActionMap("gameplay").FindAction("dash").performed += OnDash;
        lastDash = -dashCooldown;
    }

    void Update()
    {
        if (immobile) return;
        // our update loop polls the "move" action value each frame
        Vector2 moveVector2 = moveAction.ReadValue<Vector2>() * 15;
        Vector3 moveVector3 = forwardRotation * new Vector3(moveVector2.x, 0, moveVector2.y);
        rigidbody.velocity = moveVector3;
        if (moveVector3 == Vector3.zero)
            return;
        playerTransform.rotation = Quaternion.LookRotation(moveVector3, Vector3.up);
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        if (lastDash + dashCooldown < Time.time)
        {
            StartCoroutine(Immobolize(dashDuration));
            rigidbody.AddForce(playerTransform.forward * dashDistance * 300);
            lastDash = Time.time;
        }
    }

    public IEnumerator Immobolize(float duration)
    {
        immobile = true;
        yield return new WaitForSeconds(duration);
        immobile = false;
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
