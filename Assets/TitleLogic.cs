using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLogic : MonoBehaviour
{
    public string SceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}
