using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.EventSystems;

public class ModelSwapper : MonoBehaviour
{

    public TrackableBehaviour theTrackable;
    public GameObject model1;
    public GameObject model2;
    private List<GameObject> models = new List<GameObject>();
    private int currModel = 0;

    // Use this for initialization
    void Start()
    {
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }

        models.Add(model1);
        models.Add(model2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(50, 50, 120, 40), "Swap Model"))
    //    {
    //        mSwapModel = true;
    //    }
    //}

    public void SwapModel()
    {
        string button = EventSystem.current.currentSelectedGameObject.name;
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        // Re-parent the cube as child of the trackable gameObject
        if (button == "ButtonNext")
        {
            if (currModel != models.Count - 1)
            {
                currModel = currModel + 1;
            }
        } else if (button == "ButtonPrevious")
        {
            if (currModel != 0)
            {
                currModel = currModel - 1;
            }
        }

        models[currModel].transform.parent = theTrackable.transform;

        // Make sure it is active
        models[currModel].SetActive(true);
    }
}