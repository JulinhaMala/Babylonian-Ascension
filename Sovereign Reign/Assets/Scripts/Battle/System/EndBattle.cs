using UnityEngine.SceneManagement;
using UnityEngine;

public class EndBattle : MonoBehaviour
{
    
    public void Lose()
    {
        Stats.militaS -= 30;
        SceneManager.LoadScene("Game");
    }

    public void Win()
    {
        Stats.militaS += 20;
        SceneManager.LoadScene("Game");
    }
}
