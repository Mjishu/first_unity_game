using UnityEngine;
using System.Collections;
using System.Numerics;

public class cloudScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D player;
    public float bounciness = 10;
    public float moveSpeed = 1;
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        if (collision.relativeVelocity.magnitude > 2)
        {
            player.linearVelocityY += bounciness;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (UnityEngine.Vector3.up * moveSpeed) * Time.deltaTime;
    }
}
