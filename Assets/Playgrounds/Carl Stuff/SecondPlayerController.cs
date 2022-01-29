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
    //[SerializeField] private AudioClip walkingLoop;
    //[SerializeField] private AudioClip walkingLoop;
    bool canMove = true;
    public Interactable interactItem;
    [SerializeField] Animator animator;

    void Awake()
    {
        playerActions = new PlayerActions();
        rBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //speed = firstPlayer.speed;
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
        Interact();
    }

    void MovePlayer()
    {
        if (playerActions.PlayerMap.Movement2.IsPressed() && canMove)
        {
            //ADD LOOPING WALKING SFX
            animator.SetBool("Walking", true);
            moveInput = playerActions.PlayerMap.Movement2.ReadValue<Vector2>();
            transform.forward = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            rBody.velocity = transform.forward * speed;
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void Interact()
    {
        if (playerActions.PlayerMap.Interact2.WasPressedThisFrame() && interactItem != null && interactItem.usable && !interactItem.used && !interactItem.beingUsed && !interactItem.player1)
        {
            //ADD SINGLE INTERACT SFX
            canMove = false;
            transform.forward = (interactItem.gameObject.transform.position - transform.position).normalized;
            animator.SetBool("Walking", false);
            animator.SetBool("Interacting", true);
            interactItem.Use();
            StartCoroutine(InteractCooldown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactItem = other.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactItem = null;
        }
    }

    IEnumerator InteractCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Interacting", false);
        canMove = true;
    }
}
