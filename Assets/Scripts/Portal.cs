using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform destination;
    public MovementsFPS move;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(destination.position, 4f);
        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Oyuncu")
        {
            move.Teleport(destination.position, destination.rotation);
        }
    }

}
