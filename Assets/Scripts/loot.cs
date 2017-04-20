using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loot : MonoBehaviour {

    public int lootWorth;
    public float addThisMass;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I collide with things");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Score>().AddScore(lootWorth,addThisMass);
            Destroy(gameObject);
        }
    }
}
