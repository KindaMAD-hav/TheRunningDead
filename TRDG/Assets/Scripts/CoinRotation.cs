using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] int rotateSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed * 2, Space.World);
        
    }
}
