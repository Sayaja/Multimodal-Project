using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchClothes : MonoBehaviour {

    public GameObject testObj;
    public AudioSource pantsSource;
    public AudioSource shirtSource;

	// Use this for initialization
	void Start () {
        //pantsSource = GetComponent<AudioSource>();

	}

    public Vector2 startPos; // Position of first touch
    public Vector2 currPos; // Current position of finger
    public float diffX; // Difference between startPos & currPos in x
    public float diffY; // in y
    public float totDiff; // Total difference

	// Update is called once per frame
	void Update () {

        double distance = Vector3.Distance(testObj.transform.position, Camera.main.transform.position);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
        }

        // Check for click on screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            currPos = Input.GetTouch(0).position;
            diffX = Mathf.Abs(startPos.x - currPos.x);
            diffY = Mathf.Abs(startPos.y - currPos.y);
            totDiff = Mathf.Pow((Mathf.Pow(diffX, 2) + Mathf.Pow(diffY, 2)), 0.5f);

			// Checks if user clicked on AR modell
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit rayhit = new RaycastHit();
			if (Physics.Raycast(ray, out rayhit)) {
                Collider collider = rayhit.collider;

                //Fetch the Renderer from the GameObject
                //Renderer rend = testObj.GetComponent<Renderer>();

                //Create a new Material
                //Material material = new Material(Shader.Find("Standard"));
                //material.color = Color.green;

                //Switch to new material
                //rend.material = material;

                if (totDiff > 300f) // Check for swipe
                {
                    if (distance < 3.0f)
                    {
                        if (collider.GetType() == typeof(BoxCollider))
                        {
                            pantsSource.Play();
                        }
                        else
                        {
                            shirtSource.Play();
                        }
                    }
                    startPos = currPos;
                }
			}

		}

	}
}
