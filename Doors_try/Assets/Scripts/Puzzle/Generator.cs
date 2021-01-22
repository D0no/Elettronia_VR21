using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Interactable
{
    public bool Power = false;
    public Color on_color;
    public Color off_color;
    public Renderer _renderer;


    public override void Interact(GameObject caller)
    {
        Power = !Power;

        if (Power == false)
        {
            _renderer.material.color = off_color;
        }

        else
        {
            _renderer.material.color = on_color;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer.material.color = off_color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
