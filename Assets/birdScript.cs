using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
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
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            myRigidBody.linearVelocityX -= movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myRigidBody.linearVelocityX += movementSpeed;
        }

    }
}
