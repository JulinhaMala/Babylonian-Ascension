using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject destiny;
    public MeshRenderer render;
    public Material[] materials;

    void Update()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if(raycastHit.collider.CompareTag("Water"))
            {
                return;
            }
            transform.position = raycastHit.transform.position;
            destiny = raycastHit.collider.gameObject;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                player.GetComponent<CharacterBehaviour>().ClearPath();
                player.GetComponent<CharacterBehaviour>().PlainToPosition((int)destiny.transform.position.x, (int)destiny.transform.position.z, render, materials[0], materials[1]);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                player.GetComponent<CharacterBehaviour>().ClearPath();
                player.GetComponent<CharacterBehaviour>().MoveToPosition((int)destiny.transform.position.x, (int) destiny.transform.position.z);
            }
        }
    }
}
