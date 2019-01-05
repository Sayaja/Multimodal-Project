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
        Vector3 topOrigin = ARObject.transform.position + new Vector3(0, 1.2f, 0);
        double distance = Vector3.Distance(topOrigin, Camera.main.transform.position);
        if (distance < 0.1f)
        {
            myText.text = "Press to place the model";
        } else if (distance > 0.1f && distance < 0.8f)
        {
            myText.text = "Move the phone";
        } else if (distance > 3.0f)
        {
            myText.text = "Get closer to hear the clothes";
        } else if (distance < 3.0f && distance > 0.8f)
        {
            myText.text = "Swipe on the clothes";
        }

    }
}
