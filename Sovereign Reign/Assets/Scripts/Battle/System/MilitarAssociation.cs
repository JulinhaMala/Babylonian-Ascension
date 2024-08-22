using UnityEngine;

public class MilitarAssociation : MonoBehaviour
{
    [SerializeField] int[] movement = new int[5];
    [SerializeField] int[] life = new int[5];
    [SerializeField] int[] damage = new int[5];

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Stats.militaS <= 20)
        {
            player.GetComponent<CharacterBehaviour>().MaxMovements = movement[0];
        }   
        else if (Stats.militaS <= 40)
        {
            player.GetComponent<CharacterBehaviour>().MaxMovements = movement[1];
        }
        else if (Stats.militaS <= 60)
        {
            player.GetComponent<CharacterBehaviour>().MaxMovements = movement[2];
        }
        else if (Stats.militaS <= 80)
        {
            player.GetComponent<CharacterBehaviour>().MaxMovements = movement[3];
        }
        else if (Stats.militaS <= 100)
        {
            player.GetComponent<CharacterBehaviour>().MaxMovements = movement[4];
        }
    }
}
