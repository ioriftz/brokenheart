using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject[] floors;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(1,5);
        switch(r){
            case(0):
                transform.Rotate(0, 0, 0);
            break;
            case(1):
                transform.Rotate(0, 90, 0);
            break;
            case(2):
                transform.Rotate(0, 180, 0);
            break;
            case(3):
                transform.Rotate(0, 270, 0);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        floors = GameObject.FindGameObjectsWithTag("Floor");
    }

    public Vector3 calculatePosition(){
        int randometer = Random.Range(1,5);
        Vector3 pos = new Vector3(transform.position.x,0,transform.position.z);
        switch(randometer){
            case(1):
                pos = new Vector3(transform.position.x+2,0,transform.position.z);
                break;
            case(2):
                pos = new Vector3(transform.position.x-2,0,transform.position.z);
                break;
            case(3):
                pos = new Vector3(transform.position.x,0,transform.position.z-2);
                break;
            case(4):
                pos = new Vector3(transform.position.x,0,transform.position.z+2);
                break;
        }
        return pos;
    }
}
