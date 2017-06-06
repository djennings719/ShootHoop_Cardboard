using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {

    public GameObject ballPrefab;

    public float speedFactor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            float mouseX = Input.GetAxis("Mouse X") * speedFactor;
            float mouseY = Input.GetAxis("Mouse Y") * speedFactor;
            Camera camera = GetComponentInChildren<Camera>();
            //camera.transform.rotation *= Quaternion.Euler(-mouseY, 0, 0);

            GameObject instance = Instantiate(ballPrefab);
            instance.transform.position = transform.position;
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            rb.velocity = camera.transform.rotation * Vector3.forward * speedFactor;
            //instance.transform.rotation = camera.transform.rotation * Vector3.forward;
        }
    }
}
