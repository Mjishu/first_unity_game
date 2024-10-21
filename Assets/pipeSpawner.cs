using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2.0f;
    public float minSpawnRate = 0.5f;
    private float timer = 0;
    public float verticalOffset = 3.0f;
    public float spawnRateDecreaseDuration = 60.0f;
    private float elapsedTime = 0.0f;

    void Start()
    {
        SpawnPipe();
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        AdjustSpawnRate();

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
            Instantiate(pipePrefab, new Vector3(transform.position.x, randomY, 0), transform.rotation);
        }
        else
        {
            Debug.LogError("pipe prefab is not set in the inspector");
        }
    }

    private void AdjustSpawnRate()
    {
        float rateFactor = elapsedTime / spawnRateDecreaseDuration;
        spawnRate = Mathf.Max(minSpawnRate, 2.0f - rateFactor);
    }
}
