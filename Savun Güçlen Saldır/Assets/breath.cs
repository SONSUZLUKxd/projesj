using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breath : MonoBehaviour
{


    private bool isBreath = true;

    public float MinHight = 0.8f;
    public float MaxHight = 0.9f;

    [Range(1f, 3f)]
    public float Freakness = 1f;

    private float movement;

    // Use this for initialzation
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBreath)
        {
            movement = Mathf.Lerp(movement, MaxHight, Time.deltaTime * 1f * Freakness);
            transform.localPosition = new Vector3(transform.localPosition.x, movement, transform.localPosition.z);
            if (movement >= MaxHight - 0.01f)
                isBreath = !isBreath;
        }
        else
        {
            movement = Mathf.Lerp(movement, MinHight, Time.deltaTime * 1f * Freakness);
            transform.localPosition = new Vector3(transform.localPosition.x, movement, transform.localPosition.z);
            if (movement <= MinHight + 0.01f)
                isBreath = !isBreath;
        }

        //restore freakakness
        if (Freakness != 0f) Freakness = Mathf.Lerp(Freakness, 1f, Time.deltaTime * 0.2f);
    }
}
