using System;
using UnityEngine;
using UnityEngine.UI;

public class EditPlayerController : MonoBehaviour
{

    [SerializeField] private LeaderboardController _leaderboardController;
    [SerializeField] private Button _editButton;
    public InputField _nickname;
    public InputField _score;
    public string _nicknameToDelete;
    public int _scoreToDelete;

    private void OnEnable()
    {
        _nicknameToDelete = _nickname.text;
        _scoreToDelete = Convert.ToInt32(_score.text);
    }

    void Update()
    {
        if (!_nickname.text.Equals(string.Empty) && !_score.text.Equals(string.Empty))
        {
            SetEditButtonActive(true);
        }
        else
        {
            SetEditButtonActive(false);
        }
    }

    private void SetEditButtonActive(bool isActive)
    {
        _editButton.gameObject.SetActive(isActive);
    }

    public void EditPlayerRecordInLeaderboard()
    {
        var editedRecord =_leaderboardController._leaderboard.Find(PlayerRecord => (PlayerRecord.Nickname == _nicknameToDelete && PlayerRecord.Score == _scoreToDelete));
        _leaderboardController._leaderboard.Remove(editedRecord);
        _leaderboardController._leaderboard.Add(new PlayerRecord(_nickname.text, Convert.ToInt32(_score.text)));
        _nickname.text = string.Empty;
        _score.text = string.Empty;
    }
    public void CloseWithoutChanges()
    {
        var selectedRecord = _leaderboardController._leaderboard.Find(PlayerRecord => (PlayerRecord.Nickname == _nicknameToDelete && PlayerRecord.Score == _scoreToDelete));
        _leaderboardController._leaderboard.Remove(selectedRecord);
        _leaderboardController._leaderboard.Add(new PlayerRecord(_nicknameToDelete, _scoreToDelete));
        _nickname.text = string.Empty;
        _score.text = string.Empty;
    }
}
