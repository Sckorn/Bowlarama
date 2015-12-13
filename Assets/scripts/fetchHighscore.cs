using UnityEngine;
using System.Collections;
using System.IO;

public class fetchHighscore : MonoBehaviour {
    public float padding = 20;
    public float letterSpacing = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Backspace))
        {
            Application.LoadLevel(0);
        }
	}

    void Awake()
    {
        float startTime = Time.realtimeSinceStartup;
        GUIText counter = GameObject.Find("counter").GetComponent<GUIText>();
        GUIText pName = GameObject.Find("playerName").GetComponent<GUIText>();
        GUIText[] f = new GUIText[10];
        int k = 0;
        for (int j = 0; j < 10; j++)
        {
            k = j + 1;
            f[j] = GameObject.Find("f" + k.ToString()).GetComponent<GUIText>();
        }
        GUIText ovr = GameObject.Find("overall").GetComponent<GUIText>();
        int i = 1;
        if (File.Exists("highscore/highscore.csv"))
        {
            using (StreamReader sr = new StreamReader("highscore/highscore.csv"))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    string[] pieces = line.Split(',');
                    pieces[pieces.Length - 1] = pieces[pieces.Length - 1].Remove(pieces[pieces.Length - 1].Length - 1);
                    counter.text += '\n' + i.ToString();
                    pName.text += '\n' + pieces[pieces.Length - 1];
                    ovr.text += '\n' + pieces[pieces.Length - 2];
                    for (int m = 0; m < 10; m++)
                    {
                        f[m].text += '\n' + pieces[m];
                    }
                    i++;
                }
            }
        }
        this.ResizeText(i-1);
        float endTime = Time.realtimeSinceStartup;
        Debug.Log((endTime - startTime).ToString());
    }

    private void ResizeText(int records, bool widthFlag = false)
    {
        float sHeight = Screen.height;
        float sWidth = Screen.width;
        if (!widthFlag)
        {
            int quarterOfHeight = (int)(sHeight / 5);
            //screen title
            GUIText title = GameObject.Find("title").GetComponent<GUIText>();
            Rect titleRect = title.GetScreenRect();
            double titleFhRatio = (double)(title.fontSize / titleRect.height);

            float result = (float)(quarterOfHeight * titleFhRatio);
            int aimFSize = (int)(Mathf.Round(result));
            title.fontSize = aimFSize;
            titleRect = title.GetScreenRect();
            if (titleRect.width > sWidth)
            {
                double tmpRatio = (double)(title.fontSize / titleRect.width);
                aimFSize = (int)Mathf.Round((float)((sWidth - this.padding * 2) * tmpRatio));
                title.fontSize = aimFSize;
                titleRect = title.GetScreenRect();
            }
            title.pixelOffset = new Vector2((sWidth / 2) - (titleRect.width / 2), sHeight - this.padding);

            float heightLeft = sHeight - titleRect.height;

            int heightPerString = (int)(heightLeft / records);

            GUIText counter = GameObject.Find("counter").GetComponent<GUIText>();
            Rect counterRect = counter.GetScreenRect();
            double counterFhRatio = (double)(counter.fontSize / counterRect.height);

            result = (float)(heightPerString * counterFhRatio);
            aimFSize = (int)(Mathf.Round(result));
            counter.fontSize = aimFSize;
            float offsetX = this.padding;
            float offsetY = sHeight - this.padding * 2 - titleRect.height;
            counter.pixelOffset = new Vector2(offsetX, offsetY);
            counterRect = counter.GetScreenRect();

            GUIText playerName = GameObject.Find("playerName").GetComponent<GUIText>();
            Rect playerNameRect = playerName.GetScreenRect();

            offsetX += counterRect.width + this.letterSpacing;

            playerName.fontSize = aimFSize;

            playerName.pixelOffset = new Vector2(offsetX, offsetY);
            playerNameRect = playerName.GetScreenRect();
            int k = 0;
            GUIText f;
            Rect[] fRect = new Rect[10];
            for (int i = 0; i < 10; i++)
            {
                k = i + 1;
                f = GameObject.Find("f" + k.ToString()).GetComponent<GUIText>();
                f.fontSize = aimFSize;
                fRect[i] = f.GetScreenRect();
                if (i == 0)
                    offsetX += playerNameRect.width + this.letterSpacing;
                else
                    offsetX += fRect[i - 1].width + this.letterSpacing;
                f.pixelOffset = new Vector2(offsetX, offsetY);
            }

            GUIText overall = GameObject.Find("overall").GetComponent<GUIText>();
            Rect overallRect = overall.GetScreenRect();
            offsetX += fRect[fRect.Length - 1].width + this.letterSpacing;
            overall.fontSize = aimFSize;
            overall.pixelOffset = new Vector2(offsetX, offsetY);
            overallRect = overall.GetScreenRect();

            offsetX += overallRect.width;
            if (offsetX > sWidth)
                this.ResizeText(records, true);
            return;
        }
        else
        {
            GUIText title = GameObject.Find("title").GetComponent<GUIText>();
            Rect titleRect = title.GetScreenRect();
            float offsetX = sWidth - this.padding;
            float offsetY = sHeight - this.padding * 2 - titleRect.height;
            GUIText overall = GameObject.Find("overall").GetComponent<GUIText>();
            Rect overallRect = overall.GetScreenRect();
            return;
        }
    }
}
