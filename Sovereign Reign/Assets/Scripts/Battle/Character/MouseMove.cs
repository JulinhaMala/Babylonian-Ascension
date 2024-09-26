using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject destiny;
    public MeshRenderer render;
    public Material wrong, correct;
    
    public GameObject player;
    public GameObject enemy;

    public static bool canMove;


    bool canAttack = false;
    bool hasInicied = true;
    bool hasChecked = true;

    void Update()
    {
        if (hasInicied)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            canMove = true;
            hasInicied = false;
            player.GetComponent<CharacterBehaviour>().hasMoved = false;
        }
        if (Turns.actualTurn == Turn.player)
        {
            if (canMove)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    render.enabled = true;
                    hasChecked = true;
                    if (raycastHit.collider.CompareTag("Water"))
                    {
                        return;
                    }
                    transform.position = raycastHit.transform.position;
                    destiny = raycastHit.collider.gameObject;
                    if (player)
                    {
                        player.GetComponent<CharacterBehaviour>().ClearPlain();
                        if ((int)destiny.transform.position.x > 15 || (int)destiny.transform.position.z > 15 || (int)destiny.transform.position.x < 0 || (int)destiny.transform.position.z < 0)
                        {
                            return;
                        }
                        else
                        { 
                            player.GetComponent<CharacterBehaviour>().PlainToPosition((int)destiny.transform.position.x, (int)destiny.transform.position.z, render, correct, wrong);
                        }
                        
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
        if (player.GetComponent<CharacterBehaviour>().hasMoved)
        {
            if (hasChecked)
            {
                hasChecked = false;
                var path = FindObjectOfType<GridBehaviour>().GetComponent<GridBehaviour>().GetPathToPosition(player.transform, (int)enemy.transform.position.x, (int)enemy.transform.position.z, 3);
                if (path.Count <= 5)
                {
                    canAttack = true;
                }
            }
            render.enabled = false;
            Turns.endedTurn = true;
            canMove = false;
            if (canAttack)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (raycastHit.collider.CompareTag("Enemy"))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            raycastHit.collider.SendMessage("TakeDamage", 5);
                            canAttack = false;
                        }
                    }
                }
            }
            
        }
        if (!canMove)
        {
            return;
        }
    }
}
