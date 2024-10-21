using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public InputAction playerInput;
    public LogicScript Logic;

    public float flapStrength = 7.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxWidth = 15;
    public float minWidth = -15;
    public float deathZone = -9;
    public bool isDead = false;

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

    void GameOverLogic()
    {
        Vector2 position = myRigidbody.position;
        if (position.y < deathZone || position.y > -deathZone && !isDead)
        {
            isDead = true;
            Logic.GameOver();
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
            GameOverLogic();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        Logic.GameOver();
    }
}
