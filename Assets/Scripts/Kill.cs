using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SphereCollider>() != null)
        {
            Destroy(other.gameObject);
            Spawner.Spawned--;

            Debug.Log(Spawner.Spawned);
            if (Spawner.Spawned <= 0) {
                Debug.Log("DEAD");
                Buttons.DEAD = true;
            }
        }
        
    }
}
