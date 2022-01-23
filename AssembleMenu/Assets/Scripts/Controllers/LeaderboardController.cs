using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerRecord
{
    private string _nickname;
    private int _score;

    public string Nickname { get => _nickname; set => _nickname = value; }
    public int Score { get => _score; set => _score = value; }

    public PlayerRecord(string nickname, int score)
    {
        _nickname = nickname;
        _score = score;
    }
}

public class LeaderboardController : MonoBehaviour
{
    [SerializeField] private GameObject _playerRecordLine;
    [SerializeField] private GameObject _scroller;
    
    [Header("Interactable windows")]
    [SerializeField] private GameObject _leaderboardWindow;
    [SerializeField] private GameObject _addPlayerWindow;
    [SerializeField] private GameObject _editPlayerWindow;

    [Header("Buttons")]
    [SerializeField] private Button _btnAdd;
    [SerializeField] private Button _btnRemove;

    public List<PlayerRecord> _leaderboard = new List<PlayerRecord>();

    public void UpdateLeaderboard()
    {
        foreach (Transform child in _scroller.transform)
        {
            Destroy(child.gameObject);
        }

        List<PlayerRecord> sortedLeaderboard = _leaderboard.OrderBy(x => x.Score).ToList();
        sortedLeaderboard.Reverse();

        for (int i = 0; i < sortedLeaderboard.Count; i++)
        {
            ShowRecordInLeaderboard(i, sortedLeaderboard[i]);
        }
    }

    private void ShowRecordInLeaderboard(int index, PlayerRecord playerRecord)
    {
        var recordLine = Instantiate(_playerRecordLine);
        recordLine.transform.SetParent(_scroller.transform, false);

        recordLine.GetComponent<PlayerRecordView>()._position.text = Convert.ToString(index + 1);
        recordLine.GetComponent<PlayerRecordView>()._nickname.text = playerRecord.Nickname;
        recordLine.GetComponent<PlayerRecordView>()._score.text = Convert.ToString(playerRecord.Score);
    }
}
