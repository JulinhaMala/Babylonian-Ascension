using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject destiny;
    public MeshRenderer render;
    public Material wrong, correct;
    
    public GameObject player;
    public GameObject enemy;
    GameObject storage;
    public ParticleSystem particle;

    public static bool canMove;


    bool canAttack = false;
    bool hasInicied = true;
    bool hasChecked = true;

    bool hasMoved = true;
    bool canPlay = true;

    AudioSource audioSource;
    private void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        if (hasInicied)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            canMove = true;
            storage = null;
            audioSource = GetComponent<AudioSource>();
            hasInicied = false;
        }
        if (Turns.actualTurn == Turn.player)
        {
            if (canMove)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    particle.enableEmission = true;
                    render.enabled = true;
                    hasChecked = true;

                    if (raycastHit.collider.CompareTag("Water"))
                    {
                        return;
                    }
                    if (raycastHit.collider.CompareTag("Grid"))
                    {
                        transform.position = raycastHit.transform.position;
                        destiny = raycastHit.collider.gameObject;
                    }

                    if (storage != destiny)
                    {
                        storage = destiny;
                        canPlay = true;
                    }

                    if (canPlay)
                    {
                        audioSource.Play();
                        canPlay = false;
                    }

                    CharacterBehaviour.instance.ClearPlain();
                    if ((int)destiny.transform.position.x > 15 || (int)destiny.transform.position.z > 15 || (int)destiny.transform.position.x < 0 || (int)destiny.transform.position.z < 0)
                    {
                        return;
                    }
                    else
                    { 
                        CharacterBehaviour.instance.PlainToPosition((int)destiny.transform.position.x, (int)destiny.transform.position.z, render, correct, wrong, particle);
                    }
                        
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (player)
                        {
                            CharacterBehaviour.instance.ClearPath();
                            CharacterBehaviour.instance.MoveToPosition((int)destiny.transform.position.x, (int)destiny.transform.position.z);
                            destiny.SendMessage("IsOccupied", SendMessageOptions.DontRequireReceiver);
                            canMove = false;
                        }
                    }
                }
            }
        }

        if (CharacterBehaviour.instance.isMoving)
        {
            render.enabled = false;
            particle.enableEmission = false;
            canPlay = false;
        }
        if (CharacterBehaviour.instance.hasMoved)
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
