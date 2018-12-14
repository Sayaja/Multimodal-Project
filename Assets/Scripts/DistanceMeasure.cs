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
        if (distance > 3.0)
        {
            myText.text = "Get closer to feel the clothes";
        } else
        {
            myText.text = "Touch the clothes to feel them";
        }

    }
}
