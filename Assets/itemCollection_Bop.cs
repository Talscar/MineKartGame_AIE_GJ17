using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollection_Bop : MonoBehaviour {

    [Tooltip("Element 0 is the bop and Element 1 is the Spin.")]
    public float[] rateOfMovement = {0.7f, 1.2f};
    [Tooltip("Element 0 for the bop hight on start and element 1 for the spin advanced.")]
    public float[] advancedPosition = {0f, 0f};
    Transform thisObject;

    public float[] thisTransformsRange = {0, 5};
    bool transformDirection = false;

	// Use this for initialization
	void Start () {
        thisObject = gameObject.transform;
        thisObject.position += new Vector3(0, advancedPosition[0], 0);
        thisObject.Rotate(thisObject.rotation.x, thisObject.transform.rotation.y + advancedPosition[1], thisObject.rotation.z);

        thisTransformsRange[0] = thisObject.position.y;
        thisTransformsRange[1] = thisObject.position.y + thisTransformsRange[1];

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	//gameObject.transform.position
    	//gameObject.transform.rotation eularangles
        //gameObject.transform.position = 
        if(transformDirection)
        {
            if (thisObject.position.y <= thisTransformsRange[0])
            {
                transformDirection = false;
                thisObject.position = new Vector3(thisObject.position.x, thisTransformsRange[0], thisObject.position.z);
                return;
            }
            else
            {
                transform.position = new Vector3(thisObject.position.x, thisObject.position.y + -rateOfMovement[0], thisObject.position.z);
            }

        }
        else if(!transformDirection)
        {
            if (thisObject.position.y >= thisTransformsRange[1])
            {
                transformDirection = true;
                thisObject.position = new Vector3(thisObject.position.x, thisTransformsRange[1], thisObject.position.z);
                return;
            }
            else
            {
                transform.position = new Vector3(thisObject.position.x, thisObject.position.y + rateOfMovement[0], thisObject.position.z);
            }

        }
        thisObject.Rotate(thisObject.rotation.x, thisObject.transform.rotation.y + rateOfMovement[1], thisObject.rotation.z);

        //if(thisObject.position.y > thisTransformsRange[1])
        //   {
        //       //transform down -transform
        //   }



    }
}
