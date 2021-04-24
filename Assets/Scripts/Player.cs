using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    //Loads the Player Scriptable Object
    public PlayerData data;

    //Ensures the UI element comes up
    public static bool PlayerDead = false;
      
    //For explosion effect
    public GameObject Explosion;

    //For Physics based movement
    private Rigidbody _rb;
    private Vector3 _playerVelocity = Vector3.zero;
    private float _playerAcceleration;
    private float _maxVelocity;

    //Camera wrap
    Camera _cam;

    void Start ()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody>();
        PlayerDead = false;

        if (data != null)
            _loadData(data);
    }

    void Update()
    {
        //Doesn't allow the player to move if dead
        if (!PlayerDead)
        {
            _movement();
            _cameraWrap();
            transform.position += _playerVelocity;

            //Limits player speed
            _playerVelocity = Vector3.ClampMagnitude(_playerVelocity, _maxVelocity);
        }  
    }

    //Takes in the values from the PlayerData Scriptable Object
    void _loadData(PlayerData data)
    {
        _maxVelocity = data.MaxVelocity;
        _playerAcceleration = data.Acceleration;
    }

    void _movement()
    {
        //Forward Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            _playerVelocity += transform.forward * _playerAcceleration * Time.deltaTime;

        //Counterclockwise Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0, -150 * Time.deltaTime, 0));

        //Clockwise Movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0, 150 * Time.deltaTime, 0));
    }

    //Makes it so going off screen doesn't ruin everything
    void _cameraWrap()
    {
        Vector3 screenPos = _cam.WorldToViewportPoint(transform.position);

        if (screenPos.y < 0)
            screenPos.y = 1;
        else if (screenPos.y > 1)
            screenPos.y = 0;

        if (screenPos.x < 0)
            screenPos.x = 1;
        else if (screenPos.x > 1)
            screenPos.x = 0;

        transform.position = _cam.ViewportToWorldPoint(screenPos);
    }

    //Makes Asteroids kill you
    void OnCollisionEnter(Collision collider)
    {
        GameObject hit = collider.gameObject;
        if (hit.tag == "Enemy")
        {
            if (AsteroidController.PlacingAsteroids)
            {
                Destroy(hit);
            }
            else
            {
                _gameOver();
            }            
        }
    }

    //Causes the game to end on death
    void _gameOver()
    {
        Debug.Log("Game Over");
        PlayerDead = true;
        Explosion.SetActive(true);
    }  
}
