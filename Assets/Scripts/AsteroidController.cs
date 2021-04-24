using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject Asteroid;
    public static bool PlacingAsteroids = true;

    void Start()
    {
        PlacingAsteroids = true;
        _generateAsteroids();
    }

    private void _generateAsteroids()
    {
        int _asteroidsAmount = (int)Mathf.Floor(UnityEngine.Random.Range(6.0f, 10.0f));

        for(int i = 0; i < _asteroidsAmount; i++)
        {
            //Spawns asteroids
            GameObject _asteroid = Instantiate(Asteroid, transform.position, Quaternion.identity);

            //randomizes asteroid size
            float _randScale = Random.Range(20f, 40f);
            _asteroid.transform.localScale = Vector3.one * _randScale;

            //Positions asteroids
            _asteroid.transform.position = (Random.insideUnitSphere * 600) + transform.position;
            _asteroid.transform.position = new Vector3(_asteroid.transform.position.x, _asteroid.transform.position.y, 0);    
        }
        //Ensures the player doesn't die on asteroid spawn
        Invoke("_enableCollision", 0.2f);
    }

    private void _enableCollision()
    {
        PlacingAsteroids = false;
    }
}