using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject _player;
    public Transform _warp_to;
    private Vector3 _destination;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("t"))
        {
            _destination = _warp_to.transform.position;
            _destination.y += 2;
            _player.transform.position = _destination;
        }
    }

}
