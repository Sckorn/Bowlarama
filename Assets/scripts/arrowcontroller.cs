using UnityEngine;
using System.Collections;

public class arrowcontroller : MonoBehaviour {
    public float radialSpeed = 5.0f;
    public GameObject lookAt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        movingArrow();
	}

    private void movingArrow()
    {
        float turn = Input.GetAxis("Horizontal") * radialSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * turn);
        GameObject bllMrphr = GameObject.Find("pref_inst_position");
        bllMrphr.transform.Rotate(Vector3.up * turn);
    }
}

