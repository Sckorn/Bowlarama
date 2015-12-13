using UnityEngine;
using System.Collections;

public class frame{
    private int throws = 2;
    //private pin[] pins;
    public PinGroup pGroup;
    private int frameNum;
    private bool activeFrame = false;
    private int currentThrow = 0;
    private int FramePoints = 0;
    public int[] pointsPerFrame = new int[10];
    private int framesToBe = 10;
    private bool AllowedToThrow = true;

    public bool isActive
    {
        get { return activeFrame; }
        set { activeFrame = value; }
    }

    public int playerFrame
    {
        get { return frameNum; }
        set { frameNum = value; } 
    }

    public int totalThrows
    {
        get { return throws; }
        set { throws = value;}
    }

    public int playerThrow
    {
        get { return currentThrow; }
        set { currentThrow = value; }
    }

    public bool CanThrow
    {
        get { return this.AllowedToThrow; }
        set { this.AllowedToThrow = value; }
    }

    public frame()
    {
        this.pGroup = new PinGroup();
        this.frameNum = 1;
    }

    public void IncThrows()
    {
        this.currentThrow++;
    }

    public void AddPoint()
    {
        this.FramePoints++;
    }

    public void CountAfterFirst()
    {
        if (this.FramePoints == 10)
        {
            game g = GameObject.Find("Main Camera").GetComponent<game>();
            this.FramePoints *= 2;
            this.currentThrow = 0;
            g.player.overall = this.FramePoints + g.player.overall;
            waiting w = GameObject.Find("waiter").GetComponent<waiting>();
            int nextFrame = this.frameNum + 1;
            if (nextFrame <= this.framesToBe)
                w.WaitAndNext();
            else
                g.EndGame();
        }
    }

    public void NextFrame()
    {
        this.AllowedToThrow = false;
        int index = this.frameNum - 1;
        this.pointsPerFrame[index] = this.FramePoints;
        this.cleanUp();
        this.pGroup = new PinGroup();
        this.currentThrow = 0;
        this.FramePoints = 0;
        this.frameNum = this.frameNum + 1;
        game g = GameObject.Find("Main Camera").GetComponent<game>();
        GameObject text = GameObject.Find("frame_count_show");
        MeshRenderer mr = text.GetComponent<MeshRenderer>();
        TextMesh tm = text.GetComponent<TextMesh>();
        tm.text = "Frame number " + g.player.frames[1].playerFrame.ToString();
        waiting w = GameObject.Find("waiter").GetComponent<waiting>();
        w.WaitForText();
        mr.enabled = true;
    }

    public void CountAfterSecond()
    {
        game g = GameObject.Find("Main Camera").GetComponent<game>();
        g.player.overall += this.FramePoints;
        waiting w = GameObject.Find("waiter").GetComponent<waiting>();
        int nextFrame = this.frameNum + 1;
        if (nextFrame <= this.framesToBe)
            w.WaitAndNext();
        else
            g.EndGame();
    }

    public void CountPoints()
    {
        int total = this.pGroup.pins.Length;
        for (int i = 0; i < total; i++)
        {
            if (this.pGroup.pins[i].down)
            {
                this.FramePoints++;
            }
        }

        if (this.FramePoints == 10)
        {
            this.FramePoints *= 2;
            Debug.Log("Strike");
        }

        Debug.Log("Points:" + this.FramePoints.ToString());
    }

    public void cleanUp()
    {
        if (this.currentThrow == this.throws)
        {
            int total = this.pGroup.pins.Length;
            for (int i = 0; i < total; i++)
            {
                if (!this.pGroup.pins[i].down)
                {
                    this.pGroup.pins[i].itIsDown();
                }
            }
        }        
    }

    public int GetPoints()
    {
        return this.FramePoints;
    }
}
