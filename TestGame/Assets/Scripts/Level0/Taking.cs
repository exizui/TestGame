using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Taking : MonoBehaviour
{
    private const string TagOfDraggableItem = "Drag";
    private const int DefaultLayerValue = 0;
    private const int DraggableLayerValue = 9;

    private Rigidbody _rigidbody;




    void Start()
    {
        this.gameObject.tag = TagOfDraggableItem;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void PrepareForDrag()
    {
        this.gameObject.layer = DraggableLayerValue;
        _rigidbody.useGravity = false;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void PrepareForDrop()
    {
        this.gameObject.layer = DefaultLayerValue;
        _rigidbody.useGravity = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

    public void DropWithForce(Vector3 dropDirection, float dropForce)
    {
        this.gameObject.layer = DefaultLayerValue;
        _rigidbody.useGravity = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;

        _rigidbody.AddForce(dropDirection * dropForce, ForceMode.Impulse);
    }
}