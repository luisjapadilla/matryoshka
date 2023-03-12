using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : MonoBehaviour
{
    // Start is called before the first frame updat

    // Update is called once per frame

    public int y = 180;
    public int x = 0;
    public int z = 0;
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(x, y, z);
    }
}
