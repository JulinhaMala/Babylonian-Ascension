using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {

    public static CharacterBehaviour instance;

    Stack<GameObject> _currentPath = new Stack<GameObject>();
    Stack<GameObject> _possiblePath = new Stack<GameObject>();

    [Header("Movement Settings")]
    public int MaxMovements = 3;
    public float MoveSpeed = 3;

    public bool isMoving;
    public bool hasMoved = false;

    public GameObject occupiedSquare;

    public Animator anim;

    void Start ()
    {
        instance = this;
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("Velocity Z", 1f);
    }

    void Update() {
        // check movement stack to see if we need to move the character
        if (_currentPath.Count > 0) {
            anim.SetBool("Moving", true);
            isMoving = true;
            // peek at the next targets location & move towards

            var target = _currentPath.Peek();
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);

            // remove from the path stack when we reach desired location
            if (target.transform.position.x == gameObject.transform.position.x && target.transform.position.z == gameObject.transform.position.z) {
                target.SendMessage("IsOccupied", SendMessageOptions.DontRequireReceiver);
                _currentPath.Pop();
            }
            
            if (_currentPath.Count == 0)
            {
                isMoving = false;
                hasMoved = true;
                anim.SetBool("Moving", false);
                ClearPlain();
                    if(transform.localRotation.y == 0)
                    {
                        transform.Rotate(0, 90, 0);
                    }
                    else if (transform.localRotation.y <= -0.6 && transform.localRotation.y >= -0.8)
                    {
                        transform.Rotate(0, 180, 0);
                    }
                    else if (transform.localRotation.y == 1)
                    {
                        transform.Rotate(0, 270, 0);
                    }
            }
        }
    }

    public void MoveToPosition(int toX, int toY) {
        // find our grid manager in our scene
        var gridManager = GameObject.FindGameObjectWithTag("GridManager");
        int steps = MaxMovements;
        if (gridManager) {
            // use our grid manager to calculate the best route to a specific position
            var path = gridManager.GetComponent<GridBehaviour>().GetPathToPosition(gameObject.transform, toX, toY, MaxMovements);
            if (toX == transform.position.x || toY == transform.position.y)
            {
                steps--;
            }
            if (steps == 6)
            {
                if (steps == 6)
                {
                    steps = SixMovement(toX, toY, steps);
                }
            }
            for (int i = 0; i < path.Count; i++) {
                // push the values into our stack
                // then our update function within this script will begin to move our character!
                
                _currentPath.Push(path[i]);
                if (_currentPath.Peek().CompareTag("Water"))
                {
                    ClearPath();
                    print("Too Long");
                    break;
                }
                if (_currentPath.Count-2 >= steps)
                {
                    ClearPath();
                    print("Too Long");
                    break;
                }
            }
        } 
        else {
            print("Could not find GridManager object within scene.");
        }
    }

    public void ClearPath()
    {
        _currentPath = new Stack<GameObject>();
    }

    public void PlainToPosition(int toX, int toY, MeshRenderer renderer, Material can, Material cant, ParticleSystem particle)
    {
        // find our grid manager in our scene
        var gridManager = GameObject.FindGameObjectWithTag("GridManager");
        int steps = MaxMovements;
        if (gridManager)
        {
            // use our grid manager to calculate the best route to a specific position
            
            var path = gridManager.GetComponent<GridBehaviour>().GetPathToPosition(gameObject.transform, toX, toY, MaxMovements);
            if (path == null || path.Count <= 0)
            {
                renderer.enabled = false;
                particle.enableEmission = false;
                return;
            }
            if (path != null && path.Count < 0)
            {
                renderer.enabled = true;
                particle.enableEmission = true;
            }
            if (toX == transform.position.x || toY == transform.position.z)
            {
                steps--;
            }
            if (steps == 6)
            {
                steps = SixMovement(toX, toY, steps);
            }

            


            for (int i = 0; i < path.Count; i++)
            {
                // push the values into our stack
                // then our update function within this script will begin to move our character!
                _possiblePath.Push(path[i]);
                renderer.material = can;
                particle.startColor = Color.green;
                if (_possiblePath.Peek().CompareTag("Water"))
                {
                    ClearPath();
                    print("Too Long");
                    break;
                }
                if (_possiblePath.Count - 2 >= steps)
                {
                    renderer.material = cant;
                    particle.startColor = Color.red;
                    break;
                }
            }
        }
        else
        {
            print("Could not find GridManager object within scene.");
        }
    }

    int SixMovement(int toX, int toY, int steps)
    {
        if (toX == transform.position.x || toY == transform.position.z)
        {
            steps--;
        }
        else if (toX == transform.position.x + 4 && (toY == transform.position.z + 3 || toY == transform.position.z - 3))
        {
            steps++;
        }
        else if (toX == transform.position.x - 4 && (toY == transform.position.z + 3 || toY == transform.position.z - 3))
        {
            steps++;
        }
        else if (toY == transform.position.z + 4 && (toX == transform.position.x + 3 || toX == transform.position.x - 3))
        {
            steps++;
        }
        else if (toY == transform.position.z - 4 && (toX == transform.position.x + 3 || toX == transform.position.x - 3))
        {
            steps++;
        }

        return steps;
    }
    public void ClearPlain()
    {
        _possiblePath = new Stack<GameObject>();
    }
}
