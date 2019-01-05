using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ModifyModel : MonoBehaviour {

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
    private List<GameObject> models = new List<GameObject>();
    public Slider scaleSlider;
    public Slider rotSlider;

    // Use this for initialization
    void Start () {

        models.Add(model1);
        models.Add(model112);
        models.Add(model121);
        models.Add(model122);
        models.Add(model131);
        models.Add(model132);
        models.Add(model211);
        models.Add(model212);
        models.Add(model221);
        models.Add(model222);
        models.Add(model231);
        models.Add(model232);
        models.Add(model311);
        models.Add(model312);
        models.Add(model321);
        models.Add(model322);
        models.Add(model331);
        models.Add(model332);

        //scaleSlider = GameObject.Find("Slider").GetComponent<Slider>;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Modify()
    {
        float scale = scaleSlider.value;
        float rot = rotSlider.value;

        for (int i = 0; i < models.Count; i++)
        {
            models[i].transform.localScale = new Vector3(scale, scale, scale);
            models[i].transform.localRotation = Quaternion.Euler(0, rot, 0);
        }

    }
}
