using TMPro.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{
    int life = 10;

    public GameObject lose;
    public GameObject particle;

    private void Start()
    {
        lose = FindObjectOfType<Lose>(true).gameObject;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Instantiate(particle, transform.position, Quaternion.identity);
        if (life <= 0)
        {
            Destroy(gameObject);
            lose.SetActive(true);
        }
    }
}
