using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderTextSpeed : MonoBehaviour {

    public Slider cartSlider_Speed;
    public Text cartText_Speed;
    public Rigidbody YouAreGoingTooFast_CartSpeed;

    public int speed;
	// Use this for initialization
	void Start ()
    {
        YouAreGoingTooFast_CartSpeed = gameObject.GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update ()
    {

        var vel = YouAreGoingTooFast_CartSpeed.velocity;
        speed = Mathf.RoundToInt(vel.magnitude);
        
        if(speed > cartSlider_Speed.maxValue)
        { cartSlider_Speed.maxValue = speed; }
        cartSlider_Speed.value = speed;
        cartText_Speed.text = (speed + " MPH");
        	
	}
}
