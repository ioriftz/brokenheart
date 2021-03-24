using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector3 forward, right;
    private Animator myAnim;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        if(Input.anyKey){
            Move();
        } else {
            moving = false;
        }

        Animate();
    }

    void Move(){
        
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if(heading.x != 0 || heading.z != 0){ 
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
            moving = true;
        }
    }

    void Animate(){
        if(moving){
            myAnim.SetBool("moving", true);
        } else {
            myAnim.SetBool("moving", false);
        }
    }
}
