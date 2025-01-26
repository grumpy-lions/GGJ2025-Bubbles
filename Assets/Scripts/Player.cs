using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

        [Range(0.2f, 1)]
        [SerializeField] float Speed;

        void Awake()
        {
                Cursor.visible = false;

#if WII
        Debug.Log("You have a Wii!");
#else
                Debug.Log("You don't have a Wii!");
#endif
        }

        // Update is called once per frame
        void FixedUpdate()
        {

#if WII

#else
                Vector3 demo = Input.mousePosition;
                demo.z = 6;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(demo);
                mousePosition.y = mousePosition.y <= .75f ? .75f : mousePosition.y;
                mousePosition.x = mousePosition.x >= 7.5f ? 7.5f : mousePosition.x;
                mousePosition.x = mousePosition.x <= 2 ? 2 : mousePosition.x;
                transform.position = mousePosition;
#endif

        }
}
