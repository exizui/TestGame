using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeManager: MonoBehaviour
{
    private const string Tag = "Drag";
    [SerializeField] private KeyCode _dropWithForceKey = KeyCode.Mouse1;
    [SerializeField] private int _dropForce = 1000;
    [SerializeField] private int _speedOfDrag = 5;
    [SerializeField] private KeyCode _dragKey = KeyCode.Mouse0;
    [SerializeField] private int MaxRayDistance = 3;
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Transform _pickUpSocket;

    [SerializeField] private LayerMask _defaultLayerMask;
    private GameObject _draggableObject;
    private Rigidbody _rbOfDraggableObject;
    private bool isHoldingObject = false;
    public GameObject clue;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, MaxRayDistance, _defaultLayerMask))
        {
            if (hit.transform.CompareTag(Tag))
            {          
                clue.SetActive(true);
                if (Input.GetKey(_dragKey))
                {
                    clue.SetActive(false);
                    PrepareForDrag(hit);
                }
            }
            else
            {
                clue.SetActive(false);
            }
        }
        else
        {
            clue.SetActive(false);
        }
                                                           
        if (_draggableObject != null)
        {
            CheckDropButton();
            CheckDropWithForceButton();
        }
    }

    private void CheckDropWithForceButton()
    {
        if (Input.GetKeyUp(_dropWithForceKey))
        {
            DropWithForce();
        }
    }

    private void CheckDropButton()
    {
        if (Input.GetKeyUp(_dragKey))
        {
            Drop();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(_dragKey) && _draggableObject != null)
            Drag();
    }

    private void Drag()
    {
        Vector3 dragDirection = _pickUpSocket.position - _draggableObject.transform.position;
        _rbOfDraggableObject.velocity = dragDirection * _speedOfDrag;
    }

    private void Drop()
    {
        _draggableObject.GetComponent<Taking>().PrepareForDrop();
        _draggableObject = null;
        _rbOfDraggableObject = null;
        isHoldingObject= false;
    }

    private void DropWithForce()
    {
        _draggableObject.GetComponent<Taking>().DropWithForce(_playerCamera.forward, _dropForce);

        _draggableObject = null;
        _rbOfDraggableObject = null;
        isHoldingObject= false;
    }

    private void PrepareForDrag(RaycastHit hit)
    {
        if(!isHoldingObject)
        {
            _draggableObject = hit.transform.gameObject;
            _rbOfDraggableObject = _draggableObject.GetComponent<Rigidbody>();
            _draggableObject.GetComponent<Taking>().PrepareForDrag();
            isHoldingObject= true;
        }
       
    }
}
