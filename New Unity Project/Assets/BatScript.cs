using UnityEngine;
using System.Collections;

public class BatScript : MonoBehaviour {

	private bool fCollided = false;
	private Vector3 fLastVel;
	private Collision fCollision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (0, -20, 0);
	}

	void FixedUpdate(){
		if (fCollided){ // if collision happened...
			fCollided = false; // reset flag
			// calculate acceleration due to collision
			var acc = (rigidbody.velocity - fLastVel)/Time.fixedDeltaTime;
			// convert to force:
			var force = rigidbody.mass * acc;
			// call OnAfterCollision passing the Collision 
			// info and the reaction force:
			OnAfterCollision(fCollision, force);

		}
		fLastVel = rigidbody.velocity; // update last velocity
	}

	void OnCollisionEnter (Collision collision) {
		fCollision = collision; // save collision data
		fCollided = true; // signal that a collision happened
		//collision.gameObject.rigidbody.velocity = -collision.relativeVelocity;
		
		//foreach (ContactPoint contact in collision.contacts) {
		//	Debug.Log("contact");
			//collision.gameObject// contact.normal
		//}
	}

	void  OnAfterCollision(Collision coll, Vector3 force){
		print("Force="+force.magnitude);
	}
}
