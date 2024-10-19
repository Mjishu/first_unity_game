using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cloud;
    public float spawnRate = 2;
    private float timer = 0;

    public void spawnClouds()
    {
        Instantiate(cloud, transform.position, transform.rotation);
    }
    void Start()
    {
        spawnClouds();
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
            spawnClouds();
            timer = 0;
        }
    }
}
