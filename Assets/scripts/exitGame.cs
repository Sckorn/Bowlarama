using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {

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

    void OnMouseUp()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
