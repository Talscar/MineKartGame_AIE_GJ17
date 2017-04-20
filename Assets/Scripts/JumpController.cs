using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

    public float TimeToLive = 2; // Seconds

    private float TTL { get; set; }

	// Use this for initialization
	void Start () {
        TTL = TimeToLive;
    }
	
	// Update is called once per frame
	void Update () {
        TTL -= Time.deltaTime;

        if (TTL < 0)
        {
            Destroy(gameObject);
        }
	}
}
