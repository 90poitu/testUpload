using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public beatScroller theBS;

    public static GameManager instance;
    public UImanager uiManager;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMutiplier;
    public int multiplierTracker;
    public int[] multiplierThreholds;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentScore = 0;
        uiManager.setText(uiManager.scoreText, "Score:", currentScore);
        currentMutiplier = 1;
        totalNotes = FindObjectsOfType<NoteObject>().Length;

    }
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying && !uiManager.resultScreen.activeInHierarchy)
            {
                calculateScore();
            }
        }
    }

    public void calculateScore()
    {
        uiManager.setPanel(uiManager.resultScreen, true);

        uiManager.setText(uiManager.normalsText, "", normalHits);

        uiManager.setText(uiManager.goodsText, "", goodHits);

        uiManager.setText(uiManager.percentHitText, "", perfectHits);

        uiManager.setText(uiManager.missesText, "", missedHits);

        float totalHit = normalHits + goodHits + perfectHits;

        float percentHit = (totalHit / totalNotes) * 100f;

        uiManager.percentHitText.text = percentHit.ToString("f1") + "%";

        string rankValue = uiManager.rankValue[0].ToString();

        if (percentHit > 40)
        {
            rankValue = uiManager.rankValue[1].ToString();

            if (percentHit > 55)
            {
                rankValue = uiManager.rankValue[2].ToString();

                if (percentHit > 70)
                {
                    rankValue = uiManager.rankValue[3].ToString();

                    if (percentHit > 85)
                    {
                        rankValue = uiManager.rankValue[4].ToString();

                        if (percentHit > 95)
                        {
                            rankValue = uiManager.rankValue[5].ToString();
                        }
                    }
                }
            }
        }
        uiManager.rankText.text = rankValue.ToString();

        uiManager.finalScoreText.text = currentScore.ToString();
    }
    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMutiplier - 1 < multiplierThreholds.Length)
        {
            multiplierTracker++;

            if (multiplierThreholds[currentMutiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMutiplier++;
            }
        }

       // currentScore += scorePerNote * currentMutiplier;
        uiManager.setText(uiManager.scoreText, "Score: ", currentScore);
        uiManager.setText(uiManager.mutliText, "Multiplier x: ", currentMutiplier);
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMutiplier;
        NoteHit();

        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMutiplier;
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMutiplier;
        NoteHit();
        perfectHits++;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        missedHits++;
        if (currentScore > 0)
        {
            currentScore -= scorePerNote;
            uiManager.setText(uiManager.scoreText, "Score:", currentScore);
            currentMutiplier = 1;
            multiplierTracker = 0;

            uiManager.setText(uiManager.mutliText, "Multiplier: x ", currentMutiplier);
        }
    }
}
