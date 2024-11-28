using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
        print("FOI");
    }
    public void NextButton(GameObject button)
    {
        eventSystem.SetSelectedGameObject(button);
    }

    public void Battle()
    {
        SceneManager.LoadScene(2);
    }
}

