using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public AudioSource _snap_sound;
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
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            if (snapparent.tag == "wireblock") //snap the component to the wire with the transform pointing outwards
            {
                transform.position = snapparent.transform.position;
                transform.rotation = snapparent.transform.rotation;
            }

            if (snapparent.tag == "wireblockrot") //snap the component to the wire with the transform poiting inwards
            {
                transform.position = snapparent.transform.position;
                transform.rotation = Quaternion.Euler(snapparent.transform.rotation.x + 90, snapparent.transform.rotation.y, snapparent.transform.rotation.z + 180);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        _snap_sound.Play(); //play snap sound

        if (col.tag == "wireblock" || col.tag == "wireblockrot")
        {
            
            IsSnapped = true;
            snapparent = col.gameObject; //the collision determines where the component is snapped
            
            _rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        }
    }
  
}

