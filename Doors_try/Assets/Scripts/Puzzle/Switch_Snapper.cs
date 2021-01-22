using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Snapper : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public AudioSource _snap_sound;
    public static bool IsSnapped_static = false;
    public bool IsSnapped = false;
    GameObject snapparent;

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "wireblock")
        {
            IsSnapped_static = true; // viene cambiata ad ogni istanza di physics grabbable
            IsSnapped = true; //non diventa false
            snapparent = col.gameObject; //the collision determines where the component is snapped          
            _rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        }

        if (IsSnapped_static == true && PhysicsGrabbable.IsGrabbed == false)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            if (snapparent.tag == "wireblock") //snap the component to the wire with the transform pointing outwards
            {
                _snap_sound.Play(); //plays snap sound
                transform.position = snapparent.transform.position;
                transform.rotation = snapparent.transform.rotation;
            }

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
