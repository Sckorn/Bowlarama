using UnityEngine;
using System.Collections;
using System.IO;

public class game : MonoBehaviour {
    public player player;
    private string playerName = "Player1";
    private bool ThiIsTheEnd = false;
    private bool PausedGame = false;

    void Awake()
    { 
        
    }

	// Use this for initialization
	void Start () {
        this.player = new player();
        GameObject text = GameObject.Find("frame_count_show");
        MeshRenderer mr = text.GetComponent<MeshRenderer>();
        TextMesh tm = text.GetComponent<TextMesh>();
        tm.text = "Game Start\nFrame number " + this.player.frames[1].playerFrame.ToString();
        waiting w = GameObject.Find("waiter").GetComponent<waiting>();
        w.WaitForText();
        mr.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.player.frames[1].playerThrow > 0)
        {
            if (this.player.frames[1].playerThrow == 1)
            {
                this.player.frames[1].CountAfterFirst();
            }
            else if (this.player.frames[1].playerThrow == 2)
            {
                this.player.frames[1].CountAfterSecond();
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            this.PausedGame = true;
            this.PauseGame();
        }
	}

    public void EndGame()
    {
        this.player.frames[1].pointsPerFrame[9] = this.player.frames[1].GetPoints();
        this.player.frames[1].cleanUp();
        GameObject text = GameObject.Find("frame_count_show");
        MeshRenderer mr = text.GetComponent<MeshRenderer>();
        TextMesh tm = text.GetComponent<TextMesh>();
        tm.text = "End Game\nFrames played: " + this.player.frames[1].playerFrame.ToString() + "\nOverall score: " + this.player.overall.ToString();
        mr.enabled = true;
        this.ThiIsTheEnd = true;
    }

    void OnGUI()
    {
        if (this.ThiIsTheEnd)
        {
            int center = (int) Mathf.Round(UnityEngine.Screen.width / 2);
            int middle = (int) Mathf.Round(UnityEngine.Screen.height / 2);
            this.playerName = GUI.TextField(new Rect(center - 50, middle - 15, 100, 30), this.playerName);
            if (GUI.Button(new Rect(center - 50, middle + 15, 100, 30), "Quit"))
            {
                this.SaveAndEnd(0);
            }

            if (GUI.Button(new Rect(center - 50, middle + 45, 100, 30), "New Game"))
            {
                this.SaveAndEnd(1);
            }
        }

        if (this.PausedGame)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 90, 300, 180), "Pause Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 70, 280, 50), "Resume"))
            {
                this.PausedGame = false;
                this.ResumeGame();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 20, 280, 50), "New Game"))
            {
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 + 30, 280, 50), "Exit"))
            {
                Application.LoadLevel(0);
            }
        }
    }

    private string GetResultString()
    {
        string result = "";
        for (int i = 0; i < 10; i++)
        {
            result += this.player.frames[1].pointsPerFrame[i].ToString() + ",";
        }
        result += this.player.overall.ToString() + ",";
        this.playerName = this.playerName.Remove(10);
        result += this.playerName + ";\n\r";
        return result;
    }

    private void SaveScore()
    {
        if (!Directory.Exists("highscore"))
        {
            Directory.CreateDirectory("highscore");
        }

        string result = "";
        result = this.GetResultString();
        if (!File.Exists("highscore/highscore.csv"))
        {
            StreamWriter sr = new StreamWriter("highscore/highscore.csv");
            sr.WriteLine(result);
            sr.Flush();
            sr.Close();
        }
        else
        {
            FileStream fs =  File.Open("highscore/highscore.csv", FileMode.Append);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(result);
            sr.Flush();
            sr.Close();
            fs.Dispose();
        }
    }

    private void SaveAndEnd(int mode)
    {
        this.SaveScore();
        Application.LoadLevel(mode);
    }

    private void PauseGame()
    {
        if(this.PausedGame)
            Time.timeScale = 0.0f;
    }

    private void ResumeGame()
    {

        if (!this.PausedGame)
        {
            Time.timeScale = 1.0f;
        }
    }
}
