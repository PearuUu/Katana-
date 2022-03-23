using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField]int damage = 100;
    [SerializeField] float range = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitDetection();
    }

    private void FixedUpdate()
    {
        
    }

    void HitDetection()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.DrawRay(Camera.main.transform.position, transform.TransformDirection(Vector3.forward) * range, Color.yellow);
            //Debug.Log(hit.transform.tag);
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Enemy")
            {
                //Debug.Log("Damage");
                hit.transform.GetComponent<EnemyController>().Damage(damage);

            }
        }
        else
        {
            Debug.DrawRay(Camera.main.transform.position, transform.TransformDirection(Vector3.forward) * range, Color.yellow);
            //Debug.Log("Didn't hit");
        }
        
    }
   
}
