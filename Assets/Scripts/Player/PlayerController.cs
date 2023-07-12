using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputActionAsset actions;
    public Rigidbody mainRigidbody;
    public Transform playerTransform;

    [Header("Movement Modifiers")]
    public float moveSpeed = 5f;
    public Dash dash;

    [HideInInspector] public bool immobile = false;
    private InputAction moveAction;

    private Quaternion forwardRotation = Quaternion.AngleAxis(45, Vector3.up);

    void Awake()
    {
        // find the "move" action, and keep the reference to it, for use in Update
        moveAction = actions.FindActionMap("gameplay").FindAction("move");
        actions.FindActionMap("gameplay").FindAction("dash").performed += OnDash;
    }

    private void Start()
    {
        dash = new BasicDash(this);
    }

    void Update()
    {
        if (immobile) return;
        // our update loop polls the "move" action value each frame
        Vector2 moveVector2 = moveAction.ReadValue<Vector2>() * 15;
        Vector3 moveVector3 = forwardRotation * new Vector3(moveVector2.x, 0, moveVector2.y);
        mainRigidbody.velocity = moveVector3;
        if (moveVector3 == Vector3.zero)
            return;
        playerTransform.rotation = Quaternion.LookRotation(moveVector3, Vector3.up);
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        dash.dash();
    }

    public void CallableImmobolize(float duration)
    {
        StartCoroutine(Immobolize(duration));
    }
        
    IEnumerator Immobolize(float duration)
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
