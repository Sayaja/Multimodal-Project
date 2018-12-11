using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnHit : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Detta gör att modellen bara placeras ut 1 gång
	public void OnInteractiveHitTest(HitTestResult result)
	{
    var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
    if (listenerBehaviour != null)
    {
        listenerBehaviour.enabled = false;
    }
	}
}
