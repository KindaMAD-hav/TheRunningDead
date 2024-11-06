using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllInfo : MonoBehaviour
{
    public static int scoreCount = 0;
    [SerializeField] GameObject scoreDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.GetComponent<TMPro.TMP_Text>().text = "SCORE : " + scoreCount;
    }
}
