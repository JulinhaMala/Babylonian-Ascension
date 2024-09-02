using UnityEngine;

public class Enemy : MonoBehaviour
{
    int life = 10;

    public GameObject win;

    private void Start()
    {
        win = FindObjectOfType<Win>(true).gameObject;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
            win.SetActive(true);
        }
    }
}
