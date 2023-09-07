using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaphon : MonoBehaviour
{
    public float speed;
    public float ropescalingSpeed;
    public float RopeScaleY;

    private Transform rope;
    private float currentRopeScaleY = 0f;
    private bool isscaling = false;
    // Start is called before the first frame update
    void Start()
    {
        rope = transform.GetChild(0);
        Destroy(gameObject,1.46f);


    }

    // Update is called once per frame
    void Update()
    {
        if (isscaling)
        {
            if (currentRopeScaleY < RopeScaleY)
            {
                currentRopeScaleY += ropescalingSpeed * Time.deltaTime;
                currentRopeScaleY = Mathf.Clamp(currentRopeScaleY, 0f, RopeScaleY);
                rope.localScale = new Vector3(1f, currentRopeScaleY, 1f);
            }

            else
            {
                isscaling = false;
            }
        }

        else
        {
            if(currentRopeScaleY > 0 )
            {
                currentRopeScaleY -= ropescalingSpeed * Time.deltaTime;
                currentRopeScaleY = Mathf.Clamp(currentRopeScaleY, 0f, RopeScaleY);
                rope.localScale = new Vector3(1, currentRopeScaleY, 1);
            }
            else
            {
                isscaling = true;

            }
        }
      //  transform.position += Vector3.up * speed * Time.deltaTime;
    }



 
}
