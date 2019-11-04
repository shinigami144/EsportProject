using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMonstre : MonoBehaviour
{
    // Start is called before the first frame update
    ClassUnite unite;
    void Start()
    {
        unite = new ClassUnite();
        //unite.SetCible(GetComponent<ScriptCiblageAutre>().TrouvePositonCible());
    }

    // Update is called once per frame
    void Update()
    {
        //unite.SetCible(GetComponent<ScriptCiblageAutre>().TrouvePositonCible());
    }
}
