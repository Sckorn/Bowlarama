using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {

    void OnMouseOver()
    {
        guiText.fontStyle = FontStyle.Italic;
        guiText.material.color = Color.black;
    }

    void OnMouseExit()
    {
        guiText.fontStyle = FontStyle.Normal;
        guiText.material.color = Color.white;
    }

    void OnMouseUp()
    {
        Application.LoadLevel(1);
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
