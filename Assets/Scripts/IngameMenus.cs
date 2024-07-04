using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenus : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void DoubleSpeed()
    {
        if (Time.timeScale == 1) Time.timeScale = 2;
        else if (Time.timeScale == 2) Time.timeScale = 1;
    }
}
