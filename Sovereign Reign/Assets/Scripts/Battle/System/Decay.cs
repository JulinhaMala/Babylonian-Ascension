using System.Collections;
using UnityEngine;

public class Decay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DecayParticle());
    }

    IEnumerator DecayParticle()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
