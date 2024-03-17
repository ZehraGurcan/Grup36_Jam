using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Camera cam;
    public LayerMask crabMask;
    public LayerMask thcMask;
    public LayerMask orkMask;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, crabMask))
        {
            hit.collider.gameObject.GetComponent<EnemyCrab>().damageReceivedAKM();
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, orkMask))
        {
            hit.collider.gameObject.GetComponent<EnemyOrk>().damageReceivedAKM();
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, thcMask))
        {
            hit.collider.gameObject.GetComponent<EnemyTHC>().damageReceivedAKM();
        }
    }
}
