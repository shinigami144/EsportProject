using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera : MonoBehaviour
{
    private RaycastHit rayon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RaycastHit ObjetClicker()
    {
        Physics.Raycast(this.transform.position, Input.mousePosition,1000f);
        return rayon;
    }
}
