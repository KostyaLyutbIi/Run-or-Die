using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitHandler()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}