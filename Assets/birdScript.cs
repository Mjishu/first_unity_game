using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public InputAction playerInput;
    public LogicScript Logic;

    public float flapStrength = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxWidth = 15;
    public float minWidth = -15;
    public float deathZone = -9;
    private bool isDead = false;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void ScreenBounds()
    {
        Vector2 newPosition = myRigidbody.position;
        if (newPosition.x >= maxWidth)
        {
            newPosition.x = maxWidth - 1;
            myRigidbody.MovePosition(newPosition);
        }
        else if (newPosition.x <= minWidth)
        {
            newPosition.x = minWidth + 1;
            myRigidbody.MovePosition(newPosition);
        }
    }

    void GameOverLogic()
    {
        Vector2 position = myRigidbody.position;
        if (position.y < deathZone && !isDead)
        {
            Debug.Log("Game over");
            isDead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            moveDirection = playerInput.ReadValue<Vector2>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.linearVelocity = new Vector2(moveDirection.x, moveDirection.y * flapStrength);
            }
            ScreenBounds();
            GameOverLogic();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.GameOver();
        isDead = true;
    }
}
