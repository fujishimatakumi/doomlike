using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float m_timeRimit;
    float m_timeCount;
    [SerializeField] Text m_timetext;
    [SerializeField] Text m_scoreText;
    int m_score;
    bool m_isTimeCount;
    public float m_time { get; set; }
    // Start is called befotre the first frame update
    void Start()
    {
        m_timeCount = m_timeRimit;
        m_timetext.text = m_timeRimit.ToString();
        m_isTimeCount = true;
        m_score = 0;
        m_scoreText.text = m_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }

    private void TimeCount()
    {
        if (m_isTimeCount)
        {
            if (m_timeCount <= 0)
            {
                GameSet();
            }
            else
            {
                m_timeCount -= Time.deltaTime;
                m_timetext.text = m_timeCount.ToString("0.00");
            }
        }
    }

    public void AddTime(float time) 
    {
        m_timeCount += time;
    }

    public void AddScore(int score)
    {
        m_score += score;
        m_scoreText.text = m_score.ToString();
    }
    private void GameSet()
    {
        m_isTimeCount = false;
        Debug.Log("Gameset");
    }
}
