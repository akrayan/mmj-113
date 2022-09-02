using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public 
    public Timer ShootRate;
    Timer _shoot_rate_r;
    Timer _shoot_rate_l;
    
    // Start is called before the first frame update
    void Start()
    {
        _shoot_rate_l = ShootRate;
        _shoot_rate_r = ShootRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shoot_rate_l.IsDone() && (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Space)))
        {

            _shoot_rate_l.Restart();
        }
        if (_shoot_rate_r.IsDone() && (Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.Space)))
        {

            _shoot_rate_l.Restart();
        }
    }
}
