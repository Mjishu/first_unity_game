using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;
    public float movementSpeed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxWidth = 15;
    public float minWidth = -15;
    public float deathZone = -9;
    public GameManagerScript GameManager;
    private bool isDead = false;
    void Start()
    {

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
            GameManager.gameOver();
            Debug.Log("Game over");
            isDead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-movementSpeed, myRigidbody.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(movementSpeed, myRigidbody.linearVelocity.y);
        }
        ScreenBounds();
        GameOverLogic();
    }
}
