using UnityEngine;
using System.Collections;

public class testAngles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 vc = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 45.0f);
	    gameObject.transform.Rotate(vc);
        Debug.Log(gameObject.transform.rotation.z.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
