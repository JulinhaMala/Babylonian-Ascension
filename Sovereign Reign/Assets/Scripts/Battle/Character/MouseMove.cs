using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public Transform pastPosition;
    public GameObject destiny;
    public MeshRenderer render;
    public Material wrong, correct;
    bool hasInicied = true;
    public GameObject player;

    void Update()
    {
        if (hasInicied)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            pastPosition = player.transform;
            hasInicied = false;
        }
        if (Turns.actualTurn == Turn.player)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                render.gameObject.SetActive(true);
                if (raycastHit.collider.CompareTag("Water"))
                {
                    return;
                }
                transform.position = raycastHit.transform.position;
                destiny = raycastHit.collider.gameObject;
                if (player)
                {
                    player.GetComponent<CharacterBehaviour>().ClearPlain();
                    player.GetComponent<CharacterBehaviour>().PlainToPosition((int)destiny.transform.position.x, (int)destiny.transform.position.z, render, correct, wrong);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (player)
                    {
                        player.GetComponent<CharacterBehaviour>().ClearPath();
                        player.GetComponent<CharacterBehaviour>().MoveToPosition((int)destiny.transform.position.x, (int)destiny.transform.position.z);
                    }
                }
            }
        }
        if (player.transform != pastPosition)
        {
            Turns.PassTurn();
            hasInicied = true;
            render.gameObject.SetActive(false);
        }
    }
}
