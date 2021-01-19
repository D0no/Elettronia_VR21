using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLighter : MonoBehaviour
{
    public Renderer _renderer;
    public Color on_color;
    public Color off_color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PuzzleChecker.solved == true)
        {
            //cambio materiale
            _renderer.material.color = on_color;
        }
        else
        {
            _renderer.material.color = off_color;
        }
    }
}
