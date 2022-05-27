using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light lightComp;
    float r, g, b;

    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
        lightComp = this.gameObject.GetComponent<Light>();
        r = 0f;
        g = 0f;
        b = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed < 2f)
        {
            r += 1.5f;
            g += 1.5f;
            b += 1.5f;
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

        }
        else if(timeElapsed<4f)
        {
            
            r -= 2f;
            g -= 2f;
            b -= 2f;
            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;


        }
        else
        {
            timeElapsed = 0.0f;
        }
        lightComp.color = new Color(r / 255f, g / 255f, b / 255f);


    }

}
