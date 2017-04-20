using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CartController : MonoBehaviour {

    public bool InvertSideLean = false;
    public bool InvertFwdLean = false;


    public float MaxLean = 2;
    public ForceMode LeanMode = ForceMode.Acceleration;
    public float MaxBrake = 0.5f;

    public float MaxJump = 5;
    public float JumpDelay = 2;

    private Rigidbody Rb { get; set; }
    
    private float InitialDrag { get; set; }

    private bool IsJumping;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody>();
        InitialDrag = Rb.drag;

	}

    

    // Update is called once per frame
    void Update () {

        // Check Velocity > 0 or DIE
        if (Rb.velocity.sqrMagnitude < float.Epsilon)
            ; // TODO: Player Dies


        // Lean
        var leanH = MaxLean * Input.GetAxis("Horizontal");
        var leanV = MaxLean * Input.GetAxis("Vertical");

        if (InvertSideLean) leanH *= -1;
        if (InvertFwdLean) leanV *= -1;

        var forcePosn = transform.TransformPoint(new Vector3(0, 1, 0)); // Half-unit above Centre-of-Mass
        var forceDirn = transform.TransformDirection(new Vector3(leanH, 0, leanV)); // Left or Right based on input axis


        Rb.AddForceAtPosition(forceDirn, forcePosn, ForceMode.Force);

        if (leanH != 0 || leanV != 0)
            Debug.Log("Lean H: " + leanH.ToString("N3") + " , V: " + leanV.ToString("N3"));



        // Brake

        var brake = MaxBrake * Input.GetAxis("Brake");

        Rb.drag = Mathf.Max(InitialDrag, brake);

        if (brake != 0)
            Debug.Log("Brake: " + brake.ToString("N3"));


        // Jump

        var jump = Input.GetAxis("Jump");

        if (jump >= 0.5 && !IsJumping)
        {
            IsJumping = true;

            Rb.AddRelativeForce(new Vector3(0, Rb.mass * MaxJump, 0), ForceMode.Impulse);

            Debug.Log("Hybrid says, \"Jump!\"");

        }
        

	}

    void OnCollisionEnter(Collision col)
    {
        // TODO: Filter Collisions for Rails
        // Check we're on a ramp, then set Jumping false
        IsJumping = false;

    }
    
}
