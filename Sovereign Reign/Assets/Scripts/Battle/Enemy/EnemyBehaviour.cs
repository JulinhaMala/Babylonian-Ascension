using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Stack<GameObject> _currentPath = new Stack<GameObject>();

    [Header("Movement Settings")]
    public int MaxMovements = 3;
    public float MoveSpeed = 10;

    bool hasChecked = true;
    bool canAttack = false;

    public static EnemyBehaviour instance;

    GameObject player;

    void Awake()
    {
        instance = this;
    }
    public void StartEnemyTurn()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MoveToPosition((int)player.transform.position.x, (int)player.transform.position.z);
        MaxMovements = 3;
    }

    void Update() {
        if (Turns.actualTurn == Turn.enemy)
            if (_currentPath.Count > 0)
            {
                // peek at the next targets location & move towards
                var target = _currentPath.Peek();
                if (target.transform.position == new Vector3((int)player.transform.position.x, player.transform.position.y, (int)player.transform.position.z))
                {
                }
                else
                {
                    transform.LookAt(target.transform);
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);
                }
                // remove from the path stack when we reach desired location
            if (MaxMovements >= 0)
                {
                if (target.transform.position.x == gameObject.transform.position.x && target.transform.position.z == gameObject.transform.position.z)
                    {
                        _currentPath.Pop();
                        MaxMovements--;
                    }
                if (target.transform.position.x == player.transform.position.x && target.transform.position.z == player.transform.position.z)
                    {
                        MaxMovements = 0;
                    }
                    if (MaxMovements <= 0)
                    {
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        ClearPath();
                        if (hasChecked)
                        {
                            var gridManager = GameObject.FindGameObjectWithTag("GridManager");
                            var path = gridManager.GetComponent<GridBehaviour>().GetPathToPosition(player.transform, (int)transform.position.x, (int)transform.position.z, 3);
                            if (path == null)
                            {
                                print("abobora");
                            }
                            if (path.Count <= 4)
                            {
                                canAttack = true;
                            }
                        }
                        if (canAttack)
                        {
                            player.SendMessage("TakeDamage",5);
                        }
                        if (transform.localRotation.y == 0)
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
                        Turns.endedTurn = true;
                        Turns.instance.PassTurn();

                        MouseMove.canMove = true;
                    }
                }
            }
        
        // check movement stack to see if we need to move the character
    }

    public void MoveToPosition(int toX, int toY) {
        // find our grid manager in our scene
        var gridManager = GameObject.FindGameObjectWithTag("GridManager");
        if (gridManager) {
            // use our grid manager to calculate the best route to a specific position
            var path = gridManager.GetComponent<GridBehaviour>().GetPathToPosition(gameObject.transform, toX, toY, MaxMovements);
            for (int i = 0; i < path.Count; i++) {
                // push the values into our stack
                // then our update function within this script will begin to move our character!
                _currentPath.Push(path[i]);
            }
        } else {
            print("Could not find GridManager object within scene.");
        }
    }

    public void ClearPath()
    {
        _currentPath = new Stack<GameObject>();
    }
}
