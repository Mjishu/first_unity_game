using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject GameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameOverUI.SetActive(true);

    }
