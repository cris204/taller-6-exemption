using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AudioCalled AC;

    [SerializeField]
    private Camera camara_player;

    [SerializeField]
    private float velrot;

    [SerializeField]
    private GameObject botonAccion;

    [SerializeField]
    private GameObject botonBengalas;

    public PlayerStats playerstats;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Text antorchas;

    [SerializeField]
    private Animator player;

    Quaternion targetRotation;
    Rigidbody rb;

    float forwardInput, turnInput, jumpInput, upInput, sidesInput;
    bool grounded;

    [SerializeField]
    private GameObject gamecontroller;

    [SerializeField]
    private int cantidad_bengalas;

    [SerializeField]
    private float tiempo;

    [SerializeField]
    private Instructions instructions;

    [System.Serializable]
    public class MoveSetting
    {
        public float forwardVel = 12;
       
        public float rotateVel = 100;

        public float jumpVel = 25;
             
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]
    public class InputSettings
    {   
        public float inputDelay = 0.1f;
        public string forward_axis = "Vertical";
        public string turn_axis = "Horizontal";
        public string sides_axis = "sides";
        public string up_axis = "up";
        public string run = "Run";
        public string jump_axis = "Jump";
        public string poner_Bengala = "Bengalas";
        public string botonAccion = "BotonAccion";
        public string recogerBengalas = "RecogerBengalas";
    }
       
    public MoveSetting moveSettings = new MoveSetting();
    
    public PhysSettings physSettings = new PhysSettings();
    
    public InputSettings inputSettings = new InputSettings();

    //void Awake()
    //{
        //playerstats = GetComponent<PlayerStats>();
        //instructions = GetComponent<Instructions>();    
    //}

    void Start()
    {
        botonAccion.SetActive(false);
        targetRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        forwardInput = turnInput = jumpInput= 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.forward_axis);
        turnInput = Input.GetAxis(inputSettings.turn_axis);
        jumpInput = Input.GetAxisRaw(inputSettings.jump_axis);//no interpolada
        upInput = Input.GetAxis(inputSettings.up_axis);
        sidesInput = Input.GetAxis(inputSettings.sides_axis);
    }
    void Update()
    {
        antorchas.text = cantidad_bengalas.ToString();
        GetInput();
        Turn();
        playerstats.PerderComida();

        if (Input.GetButtonDown(inputSettings.poner_Bengala) && cantidad_bengalas > 0)
        {    
            PonerBengalas();

            if(!instructions.torchesInstructions)
            {
                instructions.Torches();
            }
        }

        if (playerstats.b_activacion_comida && tiempo < 10f  )
        {
            tiempo += Time.deltaTime;
        }
        else 
        {
             playerstats.b_activacion_comida = false;
        }

        if (playerstats.b_activacion_stamina && tiempo < 10f)
        {
            tiempo += Time.deltaTime;
        }
        else
        {
            playerstats.b_activacion_stamina = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButton(inputSettings.run) && playerstats.stamina>0)
        {
            Run();
        }

        else
        {
            Walk();
        }

        Jump();

        rb.velocity = transform.TransformDirection(velocity);
    }

    public Quaternion TargetRotation
    {
        get
        {
            return targetRotation;
        }
    }

    void Walk()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay)
        {
            player.SetInteger("move", 1);
            velocity.z = moveSettings.forwardVel*forwardInput;
            AC.GetComponent<AudioCalled>().Music("Step");
            playerstats.RecuperarStamina(1);
        }
        else
        {
            playerstats.RecuperarStamina(1.5f);
            player.SetInteger("move", 0);

            velocity.z = 0;
        }

        if (Mathf.Abs(sidesInput) > inputSettings.inputDelay)
        {
            velocity.x = moveSettings.forwardVel * sidesInput;
        }
        else
        {
            velocity.x = 0;
        }
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay)
        {
            player.SetInteger("move", 2);
            velocity.z = moveSettings.forwardVel * forwardInput * 2;
            AC.GetComponent<AudioCalled>().Music("Step");
            playerstats.PerderStamina();
        }
        
        if (Mathf.Abs(sidesInput) > inputSettings.inputDelay)
        {
            velocity.x = moveSettings.forwardVel * sidesInput*2;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
             targetRotation *= Quaternion.AngleAxis(moveSettings.rotateVel * turnInput * Time.deltaTime, Vector3.up);
             transform.rotation = targetRotation;
        }

        if (Mathf.Abs(upInput) > inputSettings.inputDelay)
        {
            velrot += Time.deltaTime;
            camara_player.transform.localEulerAngles = new Vector3(Mathf.Clamp(velrot, -80, 40), transform.rotation.y);

            if (0 > upInput && velrot >-80f)
            {
                velrot += 2.5f*upInput;     
            }
            else if(0 < upInput && velrot <40f)
            {
                velrot -= 2.5f*-upInput;
            }
        }
    }

    void Jump()
    {
        if(jumpInput > 0 && grounded)
        {
            velocity.y = moveSettings.jumpVel;

            player.SetInteger("move", 3);   
        }
        else if(jumpInput==0 && grounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= physSettings.downAccel;
        }
    }

    void PonerBengalas()
    {
        GameObject bengala =gamecontroller.GetComponent<Bengala_pool>().ObtenerBengalas();
        bengala.transform.position = transform.position;
        cantidad_bengalas--;
    }

    void Powerup(int a)
    {
        tiempo = 0;
        switch (a)
        {    
            case 1 :
                playerstats.hambre = 100;
                playerstats.b_activacion_comida = true;
                break;

            case 2:
                playerstats.stamina = 100;
                playerstats.b_activacion_stamina = true;
                break;

            case 3:
                playerstats.stamina = 100;
                playerstats.hambre = 100;
                break;

            case 4:
                playerstats.cantidad_llaves++;
                break;
        }
        AC.GetComponent<AudioCalled>().Music("Miracle");
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="antorcha")
        {
            botonBengalas.SetActive(true);

            if (Input.GetButtonDown(inputSettings.recogerBengalas))
            {
                botonBengalas.SetActive(false);
                Bengala_pool.bengalas_pool.DesactivarBala(other.gameObject);
                cantidad_bengalas++;
            }
        }
        else
        {
            botonAccion.SetActive(true);
        }

        if (other.gameObject.tag == "Statue" && Input.GetButtonDown(inputSettings.botonAccion))
        {
            if(!instructions.statuesInstructions)
            {
                instructions.Statues();
            }

            other.transform.FindChild("Explosion").gameObject.SetActive(true);
          
            int random = Random.Range(0, 5);
            Powerup(random);

            other.transform.GetChild(0).gameObject.SetActive(false);
            
            BoxCollider[] boxes= other.GetComponents<BoxCollider>();
            
            foreach(BoxCollider box in boxes)
            {
                box.enabled=false;
            }

            botonAccion.SetActive(false);
        }

        if (other.gameObject.tag == "Puerta" && playerstats.cantidad_llaves > 0 && Input.GetButtonDown(inputSettings.botonAccion))
        {
            if(!instructions.keysInstructions)
            {
                instructions.Keys();
            }
            
            playerstats.cantidad_llaves--;
            botonAccion.SetActive(false);
            other.gameObject.SetActive(false);
            AC.GetComponent<AudioCalled>().Music("Door");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        botonAccion.SetActive(false);
        botonBengalas.SetActive(false);
    }
}