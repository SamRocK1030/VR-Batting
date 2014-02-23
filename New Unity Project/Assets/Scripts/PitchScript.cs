using UnityEngine;
using System.Collections;

public class PitchScript : MonoBehaviour {

	public GameObject baseball;
	private GameObject ball;
	private Vector3 releasePos;
	public Vector3 releaseVelocity; //in meters per second
	public Vector3 curve;

	public enum pitchType {Fastball, Sinker, Splitter, Curveball, Slider, Screwball, Changeup, Forkball, Cutter, Slurve, Palmball, CircleChangeup};
	public pitchType pitch;

	private int mph;

	// Use this for initialization
	void Start () {
		releasePos = transform.position + new Vector3(1, 0, 0);
		pitch = pitchType.Fastball;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if( pitch != pitchType.CircleChangeup)
				pitch += 1;
			else
				pitch = pitchType.Fastball;
		} 
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if( pitch != pitchType.Fastball)
				pitch -= 1;
			else
				pitch = pitchType.CircleChangeup;
		}
		else if (Input.GetButtonDown("Jump")) {

			switch (pitch) { //right now all pitches go at their max speed 
			case pitchType.Fastball:
				releaseVelocity.Set(44.7f, 0, 0); // 85-100 mph
				curve = new Vector3(0, 0, 0);
				break;
			case pitchType.Sinker:
				releaseVelocity.Set(40.23f, 5, 0); // 80-90 mph
				curve = new Vector3(0, -3, -0.5f);
				break;
			case pitchType.Splitter:
				releaseVelocity.Set(40.23f, 10, 0); // 80-90 mph
				curve = new Vector3(0, 0, 0);
				break;
			case pitchType.Curveball:
				releaseVelocity.Set(35.76f, 11, 0); // 70-80 mph
				curve = new Vector3(0, -5, 0);
				break;
			case pitchType.Slider:
				releaseVelocity.Set(40.23f, 5, 0); // 80-90 mph
				curve = new Vector3(0, 0, 0);
				break;
			case pitchType.Screwball:
				releaseVelocity.Set(33.53f, 12, 0); // 65-75 mph
				curve = new Vector3(0, -5, -0.5f);
				break;
			case pitchType.Changeup:
				releaseVelocity.Set(38.0f, 10, 0); // 70-85 mph
				curve = new Vector3(0, 0, 0);
				break;
			case pitchType.Forkball:
				releaseVelocity.Set(38.0f, 7, 0); //75-85 mph
				curve = new Vector3(0, 0, 0);
				break;
			case pitchType.Cutter:
				releaseVelocity.Set(42.47f, 1, 0); // 85-95 mph
				curve = new Vector3(0, 0, 0.5f);
				break;
			case pitchType.Slurve:
				releaseVelocity.Set(35.76f, 11, 0); // 70-80 mph
				curve = new Vector3(0, -5, 0.5f);
				break;
			case pitchType.Palmball:
				releaseVelocity.Set(33.53f, 12, 0); // 65-75 mph
				curve = new Vector3(0, 0, 0);
				break;
			case pitchType.CircleChangeup:
				releaseVelocity.Set(35.76f, 12, 0); // 70-80 mph
				curve = new Vector3(0, 0, 0);
				break;
			default:
				pitch = pitchType.Fastball;
				releaseVelocity.Set(44.7f, 0, 0);
				curve = new Vector3(0, 0, 0);
				break;
			}

			ball = GameObject.Instantiate (baseball, 
			                               releasePos, 
			                               Quaternion.identity) as GameObject;
			ball.rigidbody.velocity = releaseVelocity; //speed vector in meters per second
			ball.rigidbody.AddTorque (curve);
				}

		//change camera
		if (Input.GetButtonDown ("Fire1")) {

			}
	}

	void FixedUpdate () {
		if (ball != null)
			ball.rigidbody.AddForce(curve);
	}

	void OnGUI () {
		//convert to mph
		mph = (int) ((releaseVelocity.x / 1609.34f) * 3600);

		GUI.BeginGroup (new Rect (10, 10, 1000, 100));
		GUI.Label(new Rect (0, 0, 200, 100), "Last Pitch: " + pitch.ToString()+ " at " + mph + " MPH");
		GUI.EndGroup ();
		}
}
