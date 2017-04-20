using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour {

    public CartController Cart;
    Rigidbody CartRb;

    private UnityEngine.UI.Text Text { get; set; }

	// Use this for initialization
	void Start () {
        Text = GetComponent<UnityEngine.UI.Text>();

        CartRb = Cart.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Text.text = "Velocity: " + CartRb.velocity.magnitude.ToString("N3");
        Text.text += "\nBraking: " + Cart.CurrentBrake.ToString("N3");

	}
}
