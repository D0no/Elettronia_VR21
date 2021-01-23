using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    [SerializeField] private Image _target;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;

    public Renderer CoilGun_Tip;


    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if (_grabbedObject == null)
            CheckInteraction();

        if (_grabbedObject != null && Input.GetMouseButtonDown(0))
            Drop();

        UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }



    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable)
            {
                if (Input.GetMouseButtonDown(0))
                    _pointingInteractable.Interact(gameObject); // chiama l'interact che è poi personalizzato per ogni tipo di oggetto
            }

            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (_grabbedObject == null && _pointingGrabbable)
            {
                if (Input.GetMouseButtonDown(1)) // attiva il grab
                {
                    _pointingGrabbable.Grab(gameObject);
                    Grab(_pointingGrabbable);
                }

            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
            _pointingGrabbable = null;
        }
    }

    private void UpdateUITarget() //cambia il colore del target in base a cosa si sta puntando
    {
        if (_pointingInteractable) { 
        _target.color = Color.green;
        CoilGun_Tip.material.EnableKeyword("_EMISSION");
    }
        else if (_pointingGrabbable){
            _target.color = Color.yellow;
        CoilGun_Tip.material.EnableKeyword("_EMISSION");
        }
        else {
    _target.color = Color.red;
    CoilGun_Tip.material.DisableKeyword("_EMISSION");
     }
    }
    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent; //toglie il collegamento con il controller
        _grabbedObject.Drop();

        _target.enabled = true;
        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT); //rende parente con il controller
        
        _target.enabled = false;
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
}
