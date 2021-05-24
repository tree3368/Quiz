using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;
    [SerializeField] private Box _box;
    [SerializeField] private int _numberСells;

    private List<char> _objects = new List<char>();
    private List<char> _answers = new List<char>();
    private char _currentObject;
    private char _answer;
    private int _numberLines;

    public event UnityAction<char> ObjectSelected;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        _numberLines++;
        DefineSearchSuggestions();

        DefineSearchObject();
    }

    private void DefineSearchObject()
    {
        _answer = _objects[Random.Range(0, _objects.Count)];
        if (_answers.Contains(_answer))
        {
            DefineSearchObject();
        }
        else
        {
            _answers.Add(_answer);
            ObjectSelected?.Invoke(_answer);
        }
    }

    private void DefineSearchSuggestions()
    {
        int numberAttempts = _numberСells;
        for (int i = 0; i < numberAttempts; i++)
        {
            _currentObject = _objectPool.DefineSearchSuggestions();
            if (_objects.Contains(_currentObject))
            {
                numberAttempts++;
            }
            else
            {
                _objects.Add(_currentObject);
                CellCreation(_currentObject);
            }
        }
    }

    private void CellCreation(char currentObject)
    {
        Box _currentBox = Instantiate(_box, _spawnPoint.position, Quaternion.identity);
        _currentBox.InstallObject(currentObject);
        _currentBox.CheckValue += OnCheckValue;
        _currentBox.LevelPassed += OnLevelPassed;
        MoveSpawnPoint();
    }

    private void MoveSpawnPoint()
    {
        _spawnPoint.position += new Vector3(_offsetX, 0);
    }

    private void OnCheckValue(Box box, char element)
    {
        if(_answer == element)
        {
            box.GetResult(true);
        }
        else
            box.GetResult(false);
    }

    private void OnLevelPassed()
    {
        if (_numberLines < 3)
        {
            _spawnPoint.position -= new Vector3(_offsetX * _numberСells, _offsetY);
            StartLevel();
        }
        else
        {
           // _buttonRestart.gameObject.SetActive(true);
           // _panel.SetActive(true);
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
