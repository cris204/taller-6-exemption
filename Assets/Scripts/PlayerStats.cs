using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    private Text llaves;

    public int cantidad_llaves;

    [SerializeField]
    private Image stamina_image;

    public float stamina=100;

    [SerializeField]
    private Image hambre_image;

    public float hambre = 100;
    
    [SerializeField]
    private float t_hambre;

    public bool b_activacion_comida = false;

    public bool b_activacion_stamina = false;

    //[SerializeField]
    //private Instructions instructions;
    
    //[SerializeField]
    //private MotionBlur motionBlur;

    //void Awake()
    //{
        //instructions = GetComponent<Instructions>();
    //}
    
    void Start ()
    {
       hambre = 100;
       stamina = 100;
       stamina_image.fillAmount = stamina;
       hambre_image.fillAmount = hambre;
    }
    void Update()
    {
        llaves.text = cantidad_llaves.ToString();

        //if (!instructions.staminaAndFoodInstructions && stamina<50)
        //{
        //    instructions.StaminaAndFood();
        //}

        //if (!instructions.staminaAndFoodInstructions && hambre<50)
        //{
        //    instructions.StaminaAndFood();
        //}

        if (stamina <= 25)
        {
            //motionBlur.enabled = true;
            //motionBlur.blurAmount = Mathf.Clamp(motionBlur.blurAmount *= Time.deltaTime, 0.25f, 0.5f);
        }
        else
        {
            //motionBlur.blurAmount = 0.25f;
            //motionBlur.enabled = false;
        }
        
        if (hambre == 0)
        {
            //motionBlur.enabled = true;
            //motionBlur.blurAmount = Mathf.Clamp(motionBlur.blurAmount *= Time.deltaTime, 0.5f, 0.75f);
        }
    }

    public void PerderComida()
    {
        if (hambre > 0 && !b_activacion_comida)
        {
            hambre = hambre - 2.5f * Time.deltaTime;
            hambre_image.fillAmount = hambre / 100;
        }
    }

    public void GanarComida()
    {
        if (hambre <= 0)
        {
            hambre = 75;
        }
        else
        {
            hambre = 100;
        }
    }

    public void PerderStamina( )
    {
        if (stamina > 0 && !b_activacion_stamina)
        {
            stamina = stamina - 5 * Time.deltaTime;

            stamina_image.fillAmount = stamina / 100;
        }
    }

    public void RecuperarStamina(float velocidadRecuperacion)
    {
        if (stamina <= 100 && hambre>0)
        {      
            stamina = stamina + 5 * velocidadRecuperacion * Time.deltaTime;
            stamina_image.fillAmount = stamina / 100;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Llave")
        {
            //if(!instructions.keysInstructions)
            //{
            //    instructions.Keys();
            //}
            
            cantidad_llaves++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "comida")
        {
            //if(!instructions.foodInstructions)
            //{
            //    instructions.Food();
            //}

            GanarComida();
            other.gameObject.SetActive(false);
        }
    }
}