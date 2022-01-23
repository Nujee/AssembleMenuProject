using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveController : MonoBehaviour
{
    [SerializeField] private LeaderboardController _leaderboardController;
    public GameObject _selectedRecordLine;
    public string _nickname;
    public int _score;

    public void RemoveSelectedRecordLine()
    {
        if (_selectedRecordLine)
            Destroy(_selectedRecordLine);
    }

    public void RemoveRecordFromLeaderboard()
    {
        var recordToRemove = _leaderboardController._leaderboard.Find(PlayerRecord => (PlayerRecord.Nickname == _nickname && PlayerRecord.Score == _score));
        _leaderboardController._leaderboard.Remove(recordToRemove);
    }
}
