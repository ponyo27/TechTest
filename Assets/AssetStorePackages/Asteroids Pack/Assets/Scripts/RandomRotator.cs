using UnityEngine;
using System.Collections;


public class RandomRotator : MonoBehaviour
{
    //This is not my code, this came with the asset. If I were to make an object rotate like this, I would probably use LeanTween.
    [SerializeField]
    private float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}