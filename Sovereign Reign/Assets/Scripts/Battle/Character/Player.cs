using TMPro.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{
    int life = 10;

    public GameObject lose;

    private void Start()
    {
        lose = FindObjectOfType<Lose>(true).gameObject;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
            lose.SetActive(true);
        }
    }
}
