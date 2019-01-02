using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchClothes : MonoBehaviour {

    public GameObject testObj;
    GameObject cam;
    Rigidbody camPhys;
    public AudioSource pantsSource;
    public AudioSource shirtSource;
    
    


	// Use this for initialization
	void Start () {
        //pantsSource = GetComponent<AudioSource>();
        cam = GameObject.Find("ARCamera");
        camPhys = cam.GetComponent<Rigidbody>();

    }

    Vector2 startPos; // Position of first touch
    Vector2 currPos; // Current position of finger
    float diffX; // Difference between startPos & currPos in x
    float diffY; // in y
    float totDiff; // Total difference
    bool inRangeTop = false;
    bool inRangeBot = false;
    
    
    Vector3 accel;
    Vector3 prevAccel;
    Vector3 dir;
        
    

    // Update is called once per frame
    void Update () {

        Vector3 topOrigin = testObj.transform.position + new Vector3(0, 1.2f, 0);
        Vector3 botOrigin = testObj.transform.position + new Vector3(0, 0.5f, 0);

        double distanceTop = Vector3.Distance(topOrigin, Camera.main.transform.position);
        double distanceBot = Vector3.Distance(botOrigin, Camera.main.transform.position);
        
        //Check device close
        if (distanceTop <= 0.5f && inRangeTop == false)
        {
            
            shirtSource.loop = true;
            shirtSource.volume = 0.0f;
            shirtSource.Play();
            inRangeTop = true;
            Handheld.Vibrate();
            //inRangeBot = false;
        }
        if (distanceTop > 0.5f && inRangeTop == true)
        {
            
            shirtSource.loop = false;
            
            shirtSource.Stop();
            shirtSource.volume = 1.0f;
            Handheld.Vibrate();
            inRangeTop = false;
        }
        //if (distanceBot < 0.4f && inRangeBot == false)
        //{

        //    Handheld.Vibrate();
        //    inRangeBot = true;
        //    inRangeTop = false;
        //}s
        //if (distanceBot > 0.4f)
        //{
        //    inRangeBot = false;
        //}

        if (inRangeTop==true)
        {
            //Vector3 acceleration = Vector3.zero;
            //foreach (AccelerationEvent accEvent in Input.accelerationEvents)
            //{
            //    acceleration += accEvent.acceleration * accEvent.deltaTime;
            //}

            Vector3 accel = Input.acceleration - prevAccel;
           
            
       
            camPhys.AddForce(accel);
            shirtSource.volume = 0.0f + camPhys.velocity.sqrMagnitude;
            prevAccel = Input.acceleration;
            //if (inRangeBot)
            //{
            //    pantsSource.volume = 0.5f * accel.sqrMagnitude;
            //    pantsSource.Play();
            //}
            

            //if (accel.sqrMagnitude >= 0.5f)
            //{
            //    //shirtSource.volume = 0.5f * accel.sqrMagnitude;
            //    shirtSource.Play();
            //}
            
            
       
     
            
            

        }



        // Check for click on screen
        if (!inRangeBot && !inRangeTop)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currPos = Input.GetTouch(0).position;
                diffX = Mathf.Abs(startPos.x - currPos.x);
                diffY = Mathf.Abs(startPos.y - currPos.y);
                totDiff = Mathf.Pow((Mathf.Pow(diffX, 2) + Mathf.Pow(diffY, 2)), 0.5f);

                // Checks if user clicked on AR modell
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit rayhit = new RaycastHit();
                if (Physics.Raycast(ray, out rayhit))
                {
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
                        if (distanceBot < 3.0f)
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
}
