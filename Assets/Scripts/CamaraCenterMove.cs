using UnityEngine;
using System.Collections;

public class CamaraCenterMove : MonoBehaviour
{
    [SerializeField]
    private int CameraVelocity;

    [SerializeField]
    private Camera camaraP1;
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);


        if (Input.GetAxisRaw("OrbitHorizontal") < 0)
        {

            transform.Rotate(new Vector3(0, -CameraVelocity, 0));
        }

        if (Input.GetAxisRaw("OrbitHorizontal") > 0)
        {
            transform.Rotate(new Vector3(0, CameraVelocity, 0));
        }

        if (Input.GetAxisRaw("OrbitVertical") > 0 && camaraP1.fieldOfView  >27.4f)
        {
            camaraP1.fieldOfView -= 1;
        }
        if (Input.GetAxisRaw("OrbitVertical") < 0 && camaraP1.fieldOfView < 80 )
        {
            camaraP1.fieldOfView += 1;
        }
        
    }
}
