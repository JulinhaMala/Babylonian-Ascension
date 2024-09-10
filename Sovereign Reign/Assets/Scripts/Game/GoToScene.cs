using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void Teleport(string tp)
    {
        SceneManager.LoadScene(tp);
    }
}
