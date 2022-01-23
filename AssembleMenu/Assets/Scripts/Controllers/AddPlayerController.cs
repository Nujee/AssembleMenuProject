using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerController : MonoBehaviour
{
    [SerializeField] private LeaderboardController _leaderboardController;
    [SerializeField] private Button _addButton;
    public InputField _nickname;
    public InputField _score;

    private void Awake()
    {
        SetAddButtonActive(false);
    }

    void Update()
    {
        if (!_nickname.text.Equals(string.Empty) && !_score.text.Equals(string.Empty))
        {
            SetAddButtonActive(true);
        }
        else
        {
            SetAddButtonActive(false);
        }
    }

    private void SetAddButtonActive(bool isActive)
    {
        _addButton.gameObject.SetActive(isActive);
    }

    public void AddPlayerRecordInLeaderboard()
    {
        _leaderboardController._leaderboard.Add(new PlayerRecord(_nickname.text, Convert.ToInt32(_score.text)));
        _nickname.text = string.Empty;
        _score.text = string.Empty;
    }
}
