using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Stack<GameObject> _currentPath = new Stack<GameObject>();

    [Header("Movement Settings")]
    public int MaxMovements = 3;
    public float MoveSpeed = 10;

    public static EnemyBehaviour instance;

    void Awake()
    {
        instance = this;
    }
    public void StartEnemyTurn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MoveToPosition((int)player.transform.position.x, (int)player.transform.position.y);
    }

    void Update() {
        if (Turns.actualTurn == Turn.enemy)
            if (_currentPath.Count > 0)
            {
                // peek at the next targets location & move towards
                var target = _currentPath.Peek();
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);

                // remove from the path stack when we reach desired location
                if (MaxMovements > 0)
                {
                    if (target.transform.position.x == gameObject.transform.position.x && target.transform.position.z == gameObject.transform.position.z)
                    {
                        _currentPath.Pop();
                        MaxMovements--;
                    }
                }
                

                if (MaxMovements < 0)
                {
                    Turns.endedTurn = true;
                    Turns.PassTurn();
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
