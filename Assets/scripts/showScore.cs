using UnityEngine;
using System.Collections;

public class showScore : MonoBehaviour {
    void OnMouseOver()
    {
        GetComponent<GUIText>().fontStyle = FontStyle.Italic;
        GetComponent<GUIText>().material.color = Color.black;
    }

    void OnMouseExit()
    {
        GetComponent<GUIText>().fontStyle = FontStyle.Normal;
        GetComponent<GUIText>().material.color = Color.white;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        Application.LoadLevel(2);
    }
}
