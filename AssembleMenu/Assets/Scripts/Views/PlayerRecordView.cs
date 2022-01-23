using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerRecordView : MonoBehaviour, IPointerClickHandler
{
    public Text _position;
    public Text _nickname;
    public Text _score;

    private GameObject _editPlayerWindowActivator;
    private GameObject _editPlayerWindow;
    private EditPlayerController _editPlayerScript;

    private GameObject _removeButton;
    private RemoveController _removeScript;

    private void Awake()
    {
        _editPlayerWindowActivator = GameObject.FindGameObjectWithTag("EditPlayerWindow");
        _editPlayerWindow = _editPlayerWindowActivator.transform.GetChild(0).gameObject;
        _editPlayerScript = _editPlayerWindow.GetComponent<EditPlayerController>();

        _removeButton = GameObject.FindGameObjectWithTag("RemoveButton");
        _removeScript = _removeButton.GetComponent<RemoveController>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _removeScript._selectedRecordLine = gameObject;
            _removeScript._nickname = _nickname.text;
            _removeScript._score = Convert.ToInt32(_score.text);

        }

        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            _editPlayerScript._nickname.text = _nickname.text;
            _editPlayerScript._score.text = _score.text;
            _editPlayerWindow.SetActive(true);
            Destroy(gameObject);
        }
    }
}
