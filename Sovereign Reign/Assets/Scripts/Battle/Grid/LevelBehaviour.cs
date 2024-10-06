using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour {

    public int[,] _tempMap = new int[15, 15] 
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 4 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 3 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
        { 1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 2, 2 },
        { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 2, 3 }
    };

    public GameObject GridManagerPrefab;
    public GameObject CharacterPrefab;
    public GameObject EnemyPrefab;
    public GameObject Explication;

    void Awake() {
            
        GenerateLevel();

        // place character/player into the world
        if (CharacterPrefab) {
            GeneratePlayer();
            GenerateEnemy();
        } else {
            print("Missing Character, please assign.");
        }
        Instantiate(Explication);
    }

    void GeneratePlayer() {
        // todo; we want to use our level id or something to place player/character into world
        Instantiate(CharacterPrefab, new Vector3 (0,0,0) , Quaternion.identity);
    }

    void GenerateEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(14, 2, 14), Quaternion.identity);
    }

    void GenerateLevel() {
        // create our grid manager object into the world
        GameObject gridManager = Instantiate(GridManagerPrefab, transform.position, Quaternion.identity);
        gridManager.name = "Grid Manager";

        // todo; want to grab some kind of game-manager object and load map based on level id

        gridManager.GetComponent<GridBehaviour>().GenerateGrid(_tempMap, new Vector3(0, 0, 0));
    }
}
