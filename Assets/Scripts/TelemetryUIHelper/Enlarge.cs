using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    Vector3 scaleChange;

    public void Expand() {
        scaleChange = new Vector3(4.5f, 4.5f, 4.5f);
        gameObject.transform.localScale += scaleChange;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
