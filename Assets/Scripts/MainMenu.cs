using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayStart()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
