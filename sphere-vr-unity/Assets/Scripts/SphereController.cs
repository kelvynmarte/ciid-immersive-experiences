using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	public GameObject player;
	Vector3 lastPosition = new Vector3(0,0,0);
	private bool ballPickedUp = false;
	private Vector3 constantVelocity = new Vector3 (0, 0, 0);
	private bool constantVelocityEnabled = false;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();


	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if (Input.GetKeyDown ("x")) {
			print ("x was pressed");
			print (transform.forward);
			rb.AddForce (new Vector3(Random.Range(-1,1),0, Random.Range(-1,1)) * thrust);

		}
		if (Input.GetKeyDown ("c")) {
			print (player.transform.position);

			print ("c was pressed");
			//rb.AddForce(dir * force);
			rb.AddForce ((player.transform.position - transform.position).normalized * thrust * Time.smoothDeltaTime *100);
		}



		if (Input.GetKeyDown ("p")) {
			//print (player.transform.position);
			print ("p was pressed");
			ballPickedUp = true;
		}

		if (ballPickedUp) {
			transform.position = player.transform.position + new Vector3(0.0f,0.6f,0.6f);
		}

		if (Input.GetKeyUp ("p")) {
			ballPickedUp = false;
			transform.position = player.transform.position + new Vector3(0.0f,0.6f,0.6f);
			rb.AddForce (player.transform.forward.normalized * 10, ForceMode.Impulse);
		}

		if (Input.GetKeyDown ("f")) {
			//print (player.transform.position);
			print ("f was pressed");
			//rb.AddForce(dir * force);
			rb.AddForce ((transform.position - lastPosition).normalized * thrust * Time.smoothDeltaTime *100);

		}
		if (Input.GetKeyDown ("g")) {
			//print (player.transform.position);
			print ("f was pressed");
			//rb.AddForce(dir * force);
			rb.AddForce ((transform.position - lastPosition).normalized * thrust * Time.smoothDeltaTime *1000);

		}
        if (Input.GetKeyDown("h"))
        {
            //print (player.transform.position);
            print("f was pressed");
            //rb.AddForce(dir * force);
            rb.AddForce((transform.position - lastPosition).normalized * thrust * Time.smoothDeltaTime * 5000);

        }
        if (Input.GetKeyDown ("j")) {
			//print (player.transform.position);
			print ("f was pressed");
			//rb.AddForce(dir * force);
			rb.AddForce ((lastPosition - transform.position).normalized * thrust * Time.smoothDeltaTime *100);

		}

		if (Input.GetKeyDown ("o")) {
			//print (player.transform.position);
			print ("p was pressed");
			constantVelocityEnabled = true;
			constantVelocity = rb.velocity;
		}

		if (constantVelocityEnabled) {
			rb.velocity = constantVelocity;
		}

		if (Input.GetKeyUp ("o")) {
			constantVelocityEnabled = false;
		}

		lastPosition = transform.position;



	}
}
