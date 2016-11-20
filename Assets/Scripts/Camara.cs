using UnityEngine;
using System.Collections;



public class Camara : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [System.Serializable]
    public class PositionSettings
    {
        public Vector3 targetPosOffset = new Vector3(0, 3.4f, 0);
        public float lookSmooth = 100f;
        public float distanceFromTarget = -8;
     

    }

    [System.Serializable]
    public class OrbitSettings
    {
        public float xRotation = -20;
        public float yRotation = -180;
        public float maxXRotation = 25;
        public float minXRotation = -85;
        public float vOrbitSmooth = 150;
        public float hOrbitSmooth = 150;

    }

    [System.Serializable]
    public class InputSettings
    {
        public string orbit_horizontal_snap = "OrbitHorizontalSnap";
        public string orbit_horizontal = "OrbitHorizontal";
        public string orbit_vertical = "OrbitVertical";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();
    
    private Vector3 targetPos = Vector3.zero;
    private Vector3 destination = Vector3.zero;
    PlayerController charController;

   
    private float vOrbitInput, hOrbitInput, hOrbitSnapInput;


    void Start()
    {
        SetCameraTarget(target);

        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;
        destination += targetPos;
        transform.position = destination;
    }

    public void SetCameraTarget(Transform t)
    {
        target = t;


        charController = target.GetComponent<PlayerController>();


    }

    void GetInput()
    {
        vOrbitInput = Input.GetAxisRaw(input.orbit_vertical);
        hOrbitInput = Input.GetAxisRaw(input.orbit_horizontal);
        hOrbitSnapInput = Input.GetAxisRaw(input.orbit_horizontal_snap);
    }

    void Update()
    {
        GetInput();
        OrbitTarget();
    }

    void LateUpdate()
    {
        MoveToTarget();

        LookAtTarget();
    }

    void MoveToTarget()
    {
        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;
        destination += targetPos;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);
    } 
    void OrbitTarget()
    {
        if (hOrbitSnapInput > 0)
        {
           
            orbit.yRotation = -180;
            Debug.Log(hOrbitInput);
        }

        orbit.xRotation += -vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
        orbit.yRotation += -hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;
       

        if (orbit.xRotation > orbit.maxXRotation)
        {
            Debug.Log("gg");
            orbit.xRotation = orbit.maxXRotation;
            
        }
        if (orbit.xRotation < orbit.minXRotation)
        {
            Debug.Log("gg1");
            orbit.xRotation = orbit.minXRotation;
        }
        hOrbitSnapInput = 0;


    }

}
