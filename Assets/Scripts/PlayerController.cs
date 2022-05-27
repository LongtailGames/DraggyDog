using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Collider2D feet;

    public bool isActive = true;
    public bool isGhost = false;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    Rigidbody2D rb;
    [SerializeField] private float lift = 5f;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color ghostColor;
    [SerializeField] private Color aliveColor;
    [SerializeField] private GraveStone graveStone;
    private LifeMeter lifeMeter;


    const string platformLayer = "Platform";

    void Awake()
    {
        lifeMeter = GetComponentInChildren<LifeMeter>();
        rb = GetComponent<Rigidbody2D>();
        if (graveStone == null)
        {
            graveStone = FindObjectOfType<GraveStone>();
            graveStone.Deactive();
        }

        UpdateGhostState();
    }

    private void Start()
    {
        lifeMeter.timeout.AddListener(Dead);
    }

    private void Dead()
    {
        LevelManager.Instance.GameOver();
    }

    void FixedUpdate()
    {
        //Move the player
        switch (isGhost)
        {
            case true:
                rb.velocity = new Vector2(rawInput.x * moveSpeed, rawInput.y * moveSpeed);
                break;
            case false:
                rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);
                break;
        }


        //Make the player jump
        if (isJumping)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            isJumping = false;
            Debug.Log("Jumped");
        }
    }

    private void UpdateGhostState()
    {
        switch (isGhost)
        {
            case true:
                sprite.color = ghostColor;
                break;
            case false:
                sprite.color = aliveColor;
                break;
        }
    }

    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive)
        {
            return;
        }

        rawInput = value.Get<Vector2>();
    }

    //Used by the input system
    void OnJump(InputValue value)
    {
        Debug.Log("Jump pressed");
        if (!isActive)
        {
            return;
        }

        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer)))
        {
            return;
        }

        isJumping = true;
    }

    [ContextMenu(nameof(Alive))]
    public void Alive()
    {
        isGhost = false;
        UpdateGhostState();
        graveStone.Deactive();
        lifeMeter.StopCountdownRoutine();
    }


    public IEnumerator StartCountDown()
    {
        yield return null;
    }

    [ContextMenu(nameof(Undead))]
    public void Undead()
    {
        isGhost = true;
        UpdateGhostState();
        var position = transform.position;
        graveStone.Activate(position + Vector3.one);
        lifeMeter.StartCountdownRoutine();
    }
}