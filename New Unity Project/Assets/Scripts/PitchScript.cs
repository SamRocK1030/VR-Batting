using UnityEngine;
using System.Collections;

public class PitchScript : MonoBehaviour {

	public GameObject baseball;
	private GameObject ball;
	private Vector3 releasePos;
	public float releaseVelocity = 44.7f;
	public Vector3 curve;

	public enum pitchType {Fastball, Sinker, Splitter, Curveball, Slider, Screwball, changeup, forkball, cutter};

	// Use this for initialization
	void Start () {
		releasePos = transform.position + new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
						ball = GameObject.Instantiate (baseball, 
			                               			   releasePos, 
			                               			   Quaternion.identity) as GameObject;
			ball.rigidbody.velocity = new Vector3(releaseVelocity, 0, 0); //x speed in meters per second
			ball.rigidbody.AddTorque (curve);
				}
	}

	void FixedUpdate () {
		if (ball != null)
			ball.rigidbody.AddForce(curve);
	}
}
