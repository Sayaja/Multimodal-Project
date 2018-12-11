using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchClothes : MonoBehaviour {

public GameObject testObj;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// Check for click on screen
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){

			// Checks if user clicked on AR modell
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit rayhit = new RaycastHit();
			if (Physics.Raycast(ray, out rayhit)) {
				// GameObject hitThing = rayhit.collider.gameObject;

				//Fetch the Renderer from the GameObject
				Renderer rend = testObj.GetComponent<Renderer>();

				//Create a new Material
				Material material = new Material(Shader.Find("Standard"));
				material.color = Color.green;

				//Switch to new material
				rend.material = material;
			}

		}

	}
}
