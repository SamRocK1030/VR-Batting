using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public bool isHit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {
		isHit = true;
	}
}
