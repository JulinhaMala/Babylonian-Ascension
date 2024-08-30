using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject destiny;
    public MeshRenderer render;
    public Material wrong, correct;
    bool hasInicied = true;
    public GameObject player;

    public static bool canMove;

    void Update()
    {
        if (hasInicied)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            canMove = true;
            hasInicied = false;
        }
        if (Turns.actualTurn == Turn.player)
        {
            if (player.GetComponent<CharacterBehaviour>().hadMove)
            {
                print("já foi");
                render.gameObject.SetActive(false);
                Turns.endedTurn = true;
                canMove = false;
                player.GetComponent<CharacterBehaviour>().hadMove = false;
            }
            if (canMove)
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
        } 
        if (canMove == false)
        {
            return;
        }
    }
}
