using UnityEngine;
using System.Collections;

public class player {
    private GameObject arrow;
    public frame[] frames = new frame[10];
    private int currentFrame = 1;
    private int totalScore = 0;
    private bool strikeToken = false;

    public bool isStrike
    {
        get { return this.strikeToken; }
        set { this.strikeToken = value; }
    }

    public int overall
    {
        get { return this.totalScore; }
        set { this.totalScore = value; }
    }

    public player()
    {
        this.frames[this.currentFrame] = new frame();
    }
}
