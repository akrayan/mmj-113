using System;
using UnityEngine;


[Serializable]
public class Timer
{
    [SerializeField][Min(0)]
    private float _seconds = 0;
    [SerializeField] bool _trueOnStart = true;
    private float _timer;
    private bool _init = false;

    public void Start()
    {
        _timer = Time.time;
        _init = true;
    }

    public void Restart()
    {
        _timer = Time.time;
    }

    public bool IsDone()
    {
        if (!_init)
        {
            Start();
            return _trueOnStart;
        }
        return Time.time - _timer >= _seconds;
    }

    public bool IsDoneAndRestart()
    {
        if (!_init)
        {
            Start();
            return _trueOnStart;
        }
        if (Time.time - _timer >= _seconds)
        {
            Restart();
            return true;
        }
        return false;
    }

}
