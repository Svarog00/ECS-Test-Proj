using Assets.Code.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    private InputService _playerControl;

    // Start is called before the first frame update
    void Start()
    {
        _playerControl = new InputService();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Input: {_playerControl.GetInput()}");
    }
}
