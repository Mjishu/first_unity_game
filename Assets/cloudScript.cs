using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BirdScript bird;
    public float bounciness = 10;
    public float moveSpeed = 1;
    private Rigidbody2D playerRigidbody;
    void Start()
    {
        if (bird != null)
        {
            playerRigidbody = bird.myRigidbody;
        }
        else
        {
            Debug.LogError("bird script is not set in the inspector");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BirdScript>() != null && playerRigidbody != null)
        {
            if (collision.relativeVelocity.magnitude > 2)
            {
                playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, bounciness);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.up;
    }
}
