using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TriggeredJump : MonoBehaviour {

    public GameObject JumpPrefab;
    public CartController CartController;

    private Rigidbody Rb;

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
        if (CartController.IsJumping || col.gameObject.tag != "Jump")
            return;

        CartController.IsJumping = true;
        Rb.AddRelativeForce(new Vector3(0, CartController.MassModifier * CartController.MaxJump, 0), ForceMode.Impulse);

        //Debug.Log("Hit Jump Trigger");
    }

   
}
