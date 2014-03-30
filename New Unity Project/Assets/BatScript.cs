using UnityEngine;
using System.Collections;

public class BatScript : MonoBehaviour {

	private bool fCollided = false;
	private Vector3 fLastVel;
	private Collision fCollision;

	public float bbcor = 0.25f; // Ball-Bat Coefficient of Restitution
	private Vector3 bbs; //Batted Ball Speed

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
			// calculate speed due to collision
			Vector3 pitchSpeed = fCollision.rigidbody.velocity;
			Vector3 batSpeed = rigidbody.velocity;
			bbs = bbcor *(pitchSpeed) + (1+bbcor)*(batSpeed);

			// call OnAfterCollision passing the Collision 
			// info and the reaction force:
			OnAfterCollision(fCollision, bbs);

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

	void  OnAfterCollision(Collision coll, Vector3 speed){
		//assign speed to ball
		coll.rigidbody.velocity = speed;
	}
}
