using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.EventSystems;

public class ModelSwapper : MonoBehaviour
{

    public TrackableBehaviour theTrackable;
    public GameObject model1;
    public GameObject model112;
    public GameObject model121;
    public GameObject model122;
    public GameObject model131;
    public GameObject model132;
    public GameObject model211;
    public GameObject model212;
    public GameObject model221;
    public GameObject model222;
    public GameObject model231;
    public GameObject model232;
    public GameObject model311;
    public GameObject model312;
    public GameObject model321;
    public GameObject model322;
    public GameObject model331;
    public GameObject model332;
    //private List<GameObject> models = new List<GameObject>();
    //private int currModel = 0;
    private Dictionary<string, GameObject> models = new Dictionary<string, GameObject>();
    private int currHat = 1;
    private int currSuit = 1;
    private int currShoe = 1;
    private string currModel = "111";

    // Use this for initialization
    void Start()
    {
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }

        models.Add("111", model1);
        models.Add("112", model112);
        models.Add("121", model121);
        models.Add("122", model122);
        models.Add("131", model131);
        models.Add("132", model132);
        models.Add("211", model211);
        models.Add("212", model212);
        models.Add("221", model221);
        models.Add("222", model222);
        models.Add("231", model231);
        models.Add("232", model232);
        models.Add("311", model311);
        models.Add("312", model312);
        models.Add("321", model321);
        models.Add("322", model322);
        models.Add("331", model331);
        models.Add("332", model332);
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
        string buttonPressed = EventSystem.current.currentSelectedGameObject.name;
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        // Re-parent the cube as child of the trackable gameObject
        if (buttonPressed == "ButtonNextHat")
        {
            if (currHat != 2)
            {
                currHat = currHat + 1;
            }
        } else if (buttonPressed == "ButtonPreviousHat")
        {
            if (currHat != 1)
            {
                currHat = currHat - 1;
            }
        } else if (buttonPressed == "ButtonNextSuit")
        {
            if (currSuit != 3)
            {
                currSuit = currSuit + 1;
            }
        } else if (buttonPressed == "ButtonPreviousSuit")
        {
            if (currSuit != 1)
            {
                currSuit = currSuit - 1;
            }
        } else if (buttonPressed == "ButtonNextShoe")
        {
            if (currShoe != 3)
            {
                currShoe = currShoe + 1;
            }
        } else if (buttonPressed == "ButtonPreviousShoe")
        {
            if (currShoe != 1)
            {
                currShoe = currShoe - 1;
            }
        }

        string temp1 = currSuit.ToString();
        string temp2 = currShoe.ToString();
        string temp3 = currHat.ToString();
        currModel = temp1 + temp2 + temp3;

        models[currModel].transform.parent = theTrackable.transform;
        // Make sure it is active
        models[currModel].SetActive(true);
    }
}