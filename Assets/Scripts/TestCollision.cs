using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 10f, Color.red, 1.0f);

            int mask = (1 << 7);
            
            LayerMask mask1 = LayerMask.GetMask("Monster");
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask1))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }

            // Vector3 mousePos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            //     Camera.main.nearClipPlane));
            // Vector3 dir = mousePos - Camera.main.transform.position;
            // dir = dir.normalized;

            // Debug.DrawRay(Camera.main.transform.position, dir * 10f, Color.red, 1.0f);
            //
            // RaycastHit hit;
            // if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            // {
            //     Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            // }
        }
        
    }
}
