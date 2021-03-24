using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("World Settings")]

    [HideInInspector]
    public List<Vector3> BlockPositions; //List of Vector3s to prevent floors at the same position
    private GameObject[] floorsInScene; //Array of floors
    public int maxFloorsInScene; //Max floors to instantiate
    public GameObject floorPreab;
    public GameObject FloorsParent; //Floors parent
    private GameObject player; //To get player distance between the floor and the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject firstFloor = Instantiate(floorPreab, new Vector3(0,0,0), Quaternion.identity, FloorsParent.transform) as GameObject;
        BlockPositions.Add(firstFloor.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        floorsInScene = GameObject.FindGameObjectsWithTag("Floor");
        GenerateMap();
    }
    
    void GenerateMap(){
        for(int i = floorsInScene.Length; i < maxFloorsInScene; i++){
            Vector3 pos = floorsInScene[Random.Range(0, floorsInScene.Length-1)].GetComponent<Floor>().calculatePosition();
            if(!BlockPositions.Contains(pos)){
                GameObject floor = Instantiate(floorPreab, pos, Quaternion.identity, FloorsParent.transform) as GameObject;
                BlockPositions.Add(floor.transform.position);
            }
        }
    }
}

