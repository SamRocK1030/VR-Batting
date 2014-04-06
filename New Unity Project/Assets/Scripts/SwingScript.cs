using UnityEngine;
using System.Collections;

public class SwingScript : MonoBehaviour {

	public float speed;
	private Vector3 startPos;
	private Quaternion startRot;
	private Quaternion endRot;
	private bool isSwinging = false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		startRot = transform.rotation;
		endRot.eulerAngles = new Vector3 (0,-100,0);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isSwinging) {
			transform.rotation = Quaternion.Lerp (startRot, endRot, Time.time * -speed);
			transform.Translate(-5 * Time.deltaTime, 0, 0);

			if (transform.position.x <= (startPos.x - 1) ) {
				isSwinging = false;
				transform.position = startPos;
				Debug.Log("stopped");
			}
			/*if (transform.rotation == endRot){
				isSwinging = false;
				rigidbody.angularVelocity = new Vector3(0,0,0);
				transform.rotation = startRot;
				Debug.Log("stopped");
			}
			*/
		} else {
			if (Input.GetKeyDown ("s")){
				//rigidbody.AddTorque(0, speed, 0);
				isSwinging = true;
				Debug.Log("isSwinging");
			}
		}

	}

	void Swing () {

	}
}
