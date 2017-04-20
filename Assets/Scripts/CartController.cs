using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CartController : MonoBehaviour {

    public GameObject JumpPrefab;


    public bool InvertSideLean = false;
    public bool InvertFwdLean = false;


    public float MaxLean = 2;
    public ForceMode LeanMode = ForceMode.Acceleration;
    public float MaxBrake = 0.5f;

    public float MaxJump = 5;

    public float MaxMass = 4;

    Rigidbody Rb { get; set; }
    
    public float MassModifier { get { return  Mathf.SmoothStep(0.5f, 2.0f, Rb.mass / MaxMass); } }

    float InitialDrag { get; set; }

    public bool IsJumping { get; set; }

    public float CurrentBrake { get; protected set; }

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody>();
        InitialDrag = Rb.drag;

	}

    void Update()
    {
        // Jump

        var jump = Input.GetAxisRaw("Jump");


        if (jump >= 0.5  && !IsJumping)
        {
            //IsJumping = true;

            //Rb.AddRelativeForce(new Vector3(0, MassModifier * MaxJump, 0), ForceMode.Impulse);

            var trigger = Instantiate(JumpPrefab, transform.TransformPoint(new Vector3(0, 0, -3)), new Quaternion());
            Destroy(trigger, 1000);

            //Debug.Log("Hybrid says, \"Jump!\" @ " + transform.TransformPoint(new Vector3(0, 0, -4)) + " from " + transform.position);

        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        // Check Velocity > 0 or DIE
        if (Rb.velocity.sqrMagnitude < float.Epsilon)
            ; // TODO: Player Dies


        // Lean
        var leanH = -MaxLean * MassModifier * Input.GetAxis("Horizontal");
        var leanV = -MaxLean * MassModifier * Input.GetAxis("Vertical");

        if (InvertSideLean) leanH *= -1;
        if (InvertFwdLean) leanV *= -1;

        var forcePosn = transform.TransformPoint(new Vector3(0, 1, 0));
        var forceDirn = transform.TransformDirection(new Vector3(leanH, 0, 0));


        Rb.AddRelativeTorque(new Vector3(leanV, 0, 0), ForceMode.Force);
        Rb.AddForceAtPosition(forceDirn, forcePosn, ForceMode.Force);
        
        if (leanH != 0 || leanV != 0)
            Debug.Log("Lean H: " + leanH.ToString("N3") + " , V: " + leanV.ToString("N3"));



        // Brake

        CurrentBrake = MaxBrake * Input.GetAxis("Brake");

        Rb.drag = Mathf.Max(InitialDrag, CurrentBrake);

        if (CurrentBrake != 0)
            Debug.Log("Brake: " + CurrentBrake.ToString("N3"));



        

	}

    void OnCollisionEnter(Collision col)
    {


    }


    void OnCollisionStay(Collision col)
    {
    }

    void OnCollisionExit(Collision col)
    {
    }
    
}
