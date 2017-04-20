using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CartController : MonoBehaviour {

    public bool InvertSideLean = false;
    public bool InvertFwdLean = false;


    public float MaxLeanForce = 2;
    public float MaxBrakeForce = 0.5f;

    private Rigidbody Rb { get; set; }
    

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody>();

	}

    

    // Update is called once per frame
    void Update () {

        // Check Velocity > 0 or DIE
        if (Rb.velocity.sqrMagnitude < float.Epsilon)
            ; // TODO: Player Dies


        // Lean
        var leanH = MaxLeanForce * Input.GetAxis("Horizontal");
        var leanV = MaxLeanForce * Input.GetAxis("Vertical");

        if (InvertSideLean) leanH *= -1;
        if (InvertFwdLean) leanV *= -1;

        var forcePosn = transform.TransformPoint(new Vector3(0, 1, 0)); // Half-unit above Centre-of-Mass
        var forceDirn = transform.TransformDirection(new Vector3(leanH, 0, leanV)); // Left or Right based on input axis


        Rb.AddForceAtPosition(forceDirn, forcePosn, ForceMode.Force);

        // Brake

        var brake = MaxBrakeForce * Input.GetAxis("Brake");

        Rb.drag = brake;

        if (brake != 0)
            Debug.Log("Brake: " + brake);
	}
    
}
