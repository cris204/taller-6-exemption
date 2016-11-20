using UnityEngine;
using System.Collections.Generic;

public class Bengala_pool : MonoBehaviour {

    [SerializeField]
    private GameObject bengala;

    [SerializeField]
    private int numero_bengalas;

    public List<GameObject> bengalas_list;

    public static Bengala_pool bengalas_pool;

    public static Bengala_pool Bengalas_pool
    {
        get
        {
            return bengalas_pool;
        }
    }
    
    void Awake()
    {
        if (bengalas_pool == null)
        {
            bengalas_pool = this;
            Preparar();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CrearBengalas()
    {
        GameObject crear = Instantiate(bengala);
        crear.SetActive(false);
        bengalas_list.Add(crear);
    }

    private void Preparar()
    {
        bengalas_list = new List<GameObject>();
        for (int i = 0; i < numero_bengalas; i++)
        {
            CrearBengalas();
        }


    }



    public GameObject ObtenerBengalas()
    {
        bengala = bengalas_list[bengalas_list.Count - 1];
        bengalas_list.RemoveAt(bengalas_list.Count - 1);
      
        bengala.SetActive(true);
        return bengala;


    }

    public void DesactivarBala(GameObject bengala)
    {
     
        bengala.gameObject.SetActive(false);
        bengalas_list.Add(bengala);
    }






}
