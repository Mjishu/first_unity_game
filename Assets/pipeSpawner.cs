using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pipePrefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float verticalOffset = 3;

    void Start()
    {
        SpawnPipe();
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
            SpawnPipe();
            timer = 0;
        }
    }

    private void SpawnPipe()
    {
        float lowestPoint = transform.position.y - verticalOffset;
        float highestPoint = transform.position.y + verticalOffset;
        if (pipePrefab != null)
        {
            float randomY = Random.Range(lowestPoint, highestPoint);
            Debug.Log($"Y position is {randomY}");
            Instantiate(pipePrefab, new Vector3(transform.position.x, randomY, 0), transform.rotation);
        }
        else
        {
            Debug.LogError("pipe prefab is not set in the inspector");
        }
    }
}
