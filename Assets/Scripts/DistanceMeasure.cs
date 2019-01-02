using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceMeasure : MonoBehaviour {

    public GameObject ARObject;
    public TextMeshProUGUI myText;

    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        double distance = Vector3.Distance(ARObject.transform.position, Camera.main.transform.position);
        if (distance < 0.1f)
        {
            myText.text = "Click to place the model";
        }
        else if (distance > 3.0f)
        {
            myText.text = "Get closer to feel the clothes";
        }
        // else if (distance < 3.0f && distance > 0.5f)
        //{
        //    myText.text = "Swipe over the clothes and listen";
        //} 
        else if (distance < 3.0f && distance > 0.1f)
        {
            //myText.text = ARObject.GetComponent<Rigidbody>().velocity.sqrMagnitude.ToString();
            myText.text = ARObject.GetComponent<Rigidbody>().velocity.sqrMagnitude.ToString();
        }

    }
}
