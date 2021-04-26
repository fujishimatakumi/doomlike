using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _timeRimit;
    float _timeCount;
    [SerializeField] Text _timetext;
    [SerializeField] Text _scoreText;
    int _score;
    bool _isTimeCount;
    
    // Start is called befotre the first frame update
    void Start()
    {
        _timeCount = _timeRimit;
        _timetext.text = _timeRimit.ToString();
        _isTimeCount = true;
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }

    private void TimeCount()
    {
        if (_isTimeCount)
        {
            if (_timeCount <= 0)
            {
                GameSet();
            }
            else
            {
                _timeCount -= Time.deltaTime;
                _timetext.text = _timeCount.ToString("0.00");
            }
        }
    }

    public void AddTime(float time) 
    {
        _timeCount += time;
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }
    private void GameSet()
    {
        _isTimeCount = false;
        Debug.Log("Gameset");
    }
}
