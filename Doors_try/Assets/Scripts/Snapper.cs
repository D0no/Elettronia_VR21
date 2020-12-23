using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public static bool IsSnapped = false;
    GameObject snapparent; // the gameobject this transform will be snapped to
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSnapped == true && PhysicsGrabbable.IsGrabbed == false)
        {
            //retain this objects position in relation to the parent
            transform.position = snapparent.transform.position;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "wireblock")
        {
            
            IsSnapped = true;
            snapparent = col.gameObject;
            _rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        }
    }
  
}

