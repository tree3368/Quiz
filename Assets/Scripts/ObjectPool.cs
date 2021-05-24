using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private char[] _objects;

    public char DefineSearchSuggestions()
    {
        char currentObject = _objects[Random.Range(0, _objects.Length)];
        return currentObject;
    }
}
