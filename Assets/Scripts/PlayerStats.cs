using UnityEngine;
using System.Collections;
using UnityEngine.UI;


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


    void Start () {
 
       hambre = 100;
       stamina = 100;
       stamina_image.fillAmount = stamina;
       hambre_image.fillAmount = hambre;
    }
    void Update()
    {
        llaves.text = cantidad_llaves.ToString();
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


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Llave")
        {
            cantidad_llaves++;

            other.gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "comida")
        {
            GanarComida();
            other.gameObject.SetActive(false);
        }

    }



}
