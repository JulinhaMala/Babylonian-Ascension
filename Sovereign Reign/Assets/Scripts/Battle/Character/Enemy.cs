using UnityEngine;

public class Enemy : MonoBehaviour
{
    int life = 10;

    public GameObject win;
    public GameObject particle;

    private void Start()
    {
        win = FindObjectOfType<Win>(true).gameObject;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Instantiate(particle, transform.position, Quaternion.identity);
        if (life <= 0)
        {
            Destroy(gameObject);
            win.SetActive(true);
        }
    }
}
