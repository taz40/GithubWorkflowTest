using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    CharacterController cc;
    Vector3 movement;
    float verticalVel;
    public float speed = 10;

	// Use this for initialization
	void Start () {
        cc = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        verticalVel += Physics.gravity.y * Time.deltaTime;
        /*if (cc.isGrounded && verticalVel < Physics.gravity.y) {
            verticalVel = Physics.gravity.y;
        }*/  // do not uncomment, this is to test the hotfix.
		movement.y += verticalVel * Time.deltaTime;
        movement.z += Input.GetAxis("Vertical")*Time.deltaTime*speed;
        movement.x += Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        
	}

    void FixedUpdate() {
        
        cc.Move(transform.rotation*movement);
        movement = Vector3.zero;
    }
}
