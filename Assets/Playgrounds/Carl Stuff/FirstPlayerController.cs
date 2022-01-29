using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class FirstPlayerController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] public PlayerActions playerActions;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Rigidbody rBody;

    void Awake()
    {
        playerActions = new PlayerActions();
        rBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerActions.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        playerActions.PlayerMap.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

    }

    void MovePlayer()
    {
        if(playerActions.PlayerMap.Movement1.IsPressed())
        {
            moveInput = playerActions.PlayerMap.Movement1.ReadValue<Vector2>();
            transform.forward = new Vector3(moveInput.x, 0, moveInput.y);
            rBody.velocity = transform.forward * speed;
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}