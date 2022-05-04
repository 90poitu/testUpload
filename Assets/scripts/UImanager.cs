using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImanager : MonoBehaviour
{
    public Text scoreText;
    public Text mutliText;

    public GameObject resultScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;
    public char[] rankValue;
    
    public string setText(Text text, string msg, float score)
    {
        return text.text = msg + " " + score;
    }
    public void setPanel(GameObject go, bool boolean) => go.SetActive(boolean);
    public void LoadLevel(int levelIndex) => SceneManager.LoadScene(levelIndex);
}