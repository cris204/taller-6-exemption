using UnityEngine;
using System.Collections;

public class RandomIntensity : MonoBehaviour {

    //Properties

    [SerializeField]
    private float intensityMin = 2f;
    [SerializeField]
    private float intensityMax = 3f;

    private Light lanternLight;

    //Unity functions

    void Awake()
    {
        lanternLight = GetComponent<Light>();
    }

    void Update()
    {
        int random = Random.Range(0, 2);
        float intensityGap = Random.Range(0.05f,0.15f);

        if(random == 0)
        {
            lanternLight.intensity += intensityGap;
        }
        else
        {
            lanternLight.intensity -= intensityGap;
        }

        lanternLight.intensity = Mathf.Clamp(lanternLight.intensity, intensityMin, intensityMax);

        Debug.Log(lanternLight.intensity);
    }
}