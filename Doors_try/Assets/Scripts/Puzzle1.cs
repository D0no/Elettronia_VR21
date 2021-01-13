using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject _correct_lamp;
    private bool _isSnapped;
    bool correct_snap;
    bool correct_power;
    bool debugged = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        correct_snap = GameObject.FindWithTag("res_small").GetComponent<Snapper>().IsSnapped;
        correct_power = GameObject.FindWithTag("generator").GetComponent<Generator>().Power;

        if (correct_snap == true && correct_power == true && debugged == false)
        {
            Debug.Log("CORRETTO");
            debugged = true;
            
        }



    }
}
