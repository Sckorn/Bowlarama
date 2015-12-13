using UnityEngine;
using System.Collections;

public class launchBall : MonoBehaviour {
    public Rigidbody ballPref;
    public Transform instPos;
    public float BallSpeed;
    private game GameLink;
	// Use this for initialization
    void Awake()
    {
        instPos = transform;
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GameLink = GameObject.Find("Main Camera").GetComponent<game>();

        if (this.GameLink.player.frames[1].playerThrow < this.GameLink.player.frames[1].totalThrows)
        {
            this.shootThatBitch();
        }        
	}

    private void shootThatBitch()
    {
        if (Input.GetButtonDown("Fire1") && this.GameLink.player.frames[1].CanThrow)
        {
            GameObject ballPos = GameObject.Find("pref_inst_position");
            Rigidbody bulletInst = Instantiate(ballPref, new Vector3(ballPos.transform.position.x, ballPos.transform.position.y, ballPos.transform.position.z), Quaternion.identity) as Rigidbody;
            bulletInst.velocity = ballPos.transform.forward * BallSpeed;
            this.GameLink.player.frames[1].IncThrows();
        }
    }
}
