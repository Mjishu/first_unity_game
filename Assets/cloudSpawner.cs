using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cloudPrefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float horizontalOffset = 10;
    public float deadzone = 10;

    void Start()
    {
        spawnCloud();
    }


    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            timer = 0;
        }
        if (transform.position.y > deadzone)
        {
            Destroy(gameObject);
        }
    }

    private void spawnCloud()
    {
        float lowestPoint = transform.position.x - horizontalOffset;
        float highestPoint = transform.position.x + horizontalOffset;
        if (cloudPrefab != null)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y, 0), transform.rotation);
        }
        else
        {
            Debug.LogError("Cloud prefab is not set in the inspector");
        }
    }
}
