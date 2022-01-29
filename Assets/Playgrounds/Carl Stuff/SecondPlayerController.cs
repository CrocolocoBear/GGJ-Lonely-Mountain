using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;



public class SecondPlayerController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private FirstPlayerController firstPlayer;
    [SerializeField] public PlayerActions playerActions;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Rigidbody rBody;

    void Awake()
    {
        playerActions = new PlayerActions();
        rBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        speed = firstPlayer.speed;
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
        if (playerActions.PlayerMap.Movement2.IsPressed())
        {
            moveInput = playerActions.PlayerMap.Movement2.ReadValue<Vector2>();
            transform.forward = new Vector3(moveInput.x, 0, moveInput.y);
            rBody.velocity = transform.forward * speed;
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}