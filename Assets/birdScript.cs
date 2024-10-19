using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;
    public float movementSpeed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

    }
}
