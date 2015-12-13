using UnityEngine;
using System.Collections;

public class SpecialCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Collision " + c.gameObject.name);
        if (c.gameObject.name == "track")
        {
            Destroy(gameObject);
        }
    }
}
