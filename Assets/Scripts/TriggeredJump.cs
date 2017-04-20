using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TriggeredJump : MonoBehaviour {

    public GameObject JumpPrefab;
    public CartController CartController;

    private Rigidbody Rb;

    private bool IsJumping { get; set; }

    // Use this for initialization
    void Start () {
        Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        // Not a jump trigger
        if (IsJumping || col.gameObject.tag != "Jump")
            return;

        CartController.IsJumping = true;
        IsJumping = true;
        Rb.AddRelativeForce(new Vector3(0, CartController.MassModifier * CartController.MaxJump, 0), ForceMode.Impulse);

        //Debug.Log("Hit Jump Trigger");
    }

    void OnCollisionEnter()
    {
        // TODO: Filter Collisions for Rails
        // Check we're on a ramp, then set Jumping false
        CartController.IsJumping = false;
        IsJumping = false;
    }
   
}
