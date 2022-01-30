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
    bool canMove = true;
    public bool interacting = false;
    public Interactable interactItem;
    [SerializeField] Animator animator;
    public AudioClip walk;
    public AudioClip interact;
    public AudioSource audioSrc;

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
        Interact();
        if (playerActions.PlayerMap.Interact1.WasReleasedThisFrame() && interactItem != null)
        {
            interactItem.usedThisRound = false;
        }
    }

    void MovePlayer()
    {
        if (playerActions.PlayerMap.Movement1.IsPressed() && canMove)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.clip = walk;
                audioSrc.loop = true;
                audioSrc.Play();
            }
            animator.SetBool("Walking", true);
            moveInput = playerActions.PlayerMap.Movement1.ReadValue<Vector2>();
            transform.forward = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            rBody.velocity = transform.forward * speed;
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            if (audioSrc.isPlaying)
            {
                audioSrc.clip = walk;
                audioSrc.loop = false;
                audioSrc.Stop();
            }
            animator.SetBool("Walking", false);
        }
    }

    void Interact()
    {
        if (playerActions.PlayerMap.Interact1.WasPressedThisFrame() && interactItem != null && interactItem.usable && !interactItem.used && !interactItem.beingUsed && interactItem.player1 && !interacting)
        {
            audioSrc.clip = interact;
            audioSrc.loop = false;
            audioSrc.Play();
            canMove = false;
            transform.forward = (interactItem.gameObject.transform.position - transform.position).normalized;
            animator.SetBool("Walking", false);
            animator.SetBool("Interacting", true);
            interactItem.Use();
            if (!interactItem.beingUsed)
            {
                StartCoroutine(InteractCooldown(1.5f));
            }
            else
            {
                interacting = true;
            }
        }
        else if (interacting && playerActions.PlayerMap.Interact1.WasPressedThisFrame())
        {
            audioSrc.clip = interact;
            audioSrc.loop = false;
            audioSrc.Play();
            canMove = false;
                interactItem.Use();
                if (interactItem.used)
                {
                    interactItem.beingUsed = false;
                    StartCoroutine(InteractCooldown(1.5f));
                    interacting = false;
                }
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


    public IEnumerator InteractCooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool("Interacting", false);
        canMove = true;
    }
}
