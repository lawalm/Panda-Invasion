using System.Collections;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    public float rotationPerMinute = 640f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rotationPerMinute * Time.deltaTime, Space.World);
	}
}
