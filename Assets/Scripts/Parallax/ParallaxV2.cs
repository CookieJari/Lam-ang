using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxV2 : MonoBehaviour
{

    private float length, startpos, startposY;
    public GameObject cam;
    public float parallaxEffect;
    parallaxCtrl pc;

    public bool yParallax;
    public bool yFollow;

    // Start is called before the first frame update
    void Start()
    {
        pc = transform.parent.gameObject.GetComponent<parallaxCtrl>();
        

        length = GetComponent<SpriteRenderer>().bounds.size.x;    
    }
    private void Awake()
    {
        
        startpos = transform.position.x;
        startpos = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yParallax = pc.YParallax;
        yFollow = pc.YFollow;
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (yParallax && !yFollow)
        {
            float tempY = (cam.transform.position.y * (1 - parallaxEffect));
            float distY = (cam.transform.position.y * parallaxEffect);
            transform.position = new Vector3(transform.position.x, startposY + distY, transform.position.z);
        }
        else if (yFollow)
        {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }


        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
