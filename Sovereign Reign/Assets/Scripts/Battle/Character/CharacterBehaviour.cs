using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {

    Stack<GameObject> _currentPath = new Stack<GameObject>();
    Stack<GameObject> _possiblePath = new Stack<GameObject>();

    [Header("Movement Settings")]
    public int MaxMovements = 3;
    public float MoveSpeed = 3;

    public bool hasMoved;

    public GameObject occupiedSquare;

    public Animator anim;

    void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("Velocity Z", 1f);
    }

    void Update() {
        // check movement stack to see if we need to move the character
        if (_currentPath.Count > 0) {
            anim.SetBool("Moving", true);
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
                hasMoved = true;
                anim.SetBool("Moving", false);
                print(transform.localRotation.y);
                    if(transform.localRotation.y == 0)
                    {
                        print("Wrong 0");
                        transform.Rotate(0, 90, 0);
                    }
                    else if (transform.localRotation.y <= -0.6 && transform.localRotation.y >= -0.8)
                    {
                        print("Wrong -90");
                        transform.Rotate(0, 180, 0);
                    }
                    else if (transform.localRotation.y == 1)
                    {
                        print("Wrong -180");
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
                if (toX == transform.position.x || toY == transform.position.z)
                {
                    steps--;
                    print("Reto");
                }
                if (toX == transform.position.x + 4 && (toY == transform.position.z + 3 || toY == transform.position.z - 3))
                {
                    steps++;
                }
                if (toX == transform.position.x - 4 && (toY == transform.position.z + 3 || toY == transform.position.z - 3))
                {
                    steps++;
                }
                if (toY == transform.position.z + 4 && (toX == transform.position.x + 3 || toX == transform.position.x - 3))
                {
                    steps++;
                }
                if (toY == transform.position.z - 4 && (toX == transform.position.x + 3 || toX == transform.position.x - 3))
                {
                    steps++;
                }
            }
            for (int i = 0; i < path.Count; i++) {
                // push the values into our stack
                // then our update function within this script will begin to move our character!
                _currentPath.Push(path[i]);
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
            if (toX == transform.position.x || toY == transform.position.z)
            {
                steps--;
                print("Reto");
            }
            if (steps == 6)
            {
                if (toX == transform.position.x || toY == transform.position.z)
                {
                    steps--;
                    print("Reto");
                }
                if (toX == transform.position.x + 4 && (toY == transform.position.z + 3 || toY == transform.position.z - 3))
                {
                    steps++;
                }
                if (toX == transform.position.x - 4 && (toY == transform.position.z + 3 || toY == transform.position.z - 3))
                {
                    steps++;
                }
                if (toY == transform.position.z + 4 && (toX == transform.position.x + 3 || toX == transform.position.x - 3))
                {
                    steps++;
                }
                if (toY == transform.position.z - 4 && (toX == transform.position.x + 3 || toX == transform.position.x - 3))
                {
                    steps++;
                }
            }

            if (path == null || path.Count < 0)
            {
                return;
            }


            for (int i = 0; i < path.Count; i++)
            {
                // push the values into our stack
                // then our update function within this script will begin to move our character!
                _possiblePath.Push(path[i]);
                renderer.material = can;
                particle.startColor = Color.green;
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
    public void ClearPlain()
    {
        _possiblePath = new Stack<GameObject>();
    }
}
