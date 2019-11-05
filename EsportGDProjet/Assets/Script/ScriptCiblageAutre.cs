using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCiblageAutre : MonoBehaviour
{
    // Start is called before the first frame update
    // Composant pour les NPC et Monstre
    bool estMonstre;
    ScriptGameManager gm;
    void Start()
    {
        gm = FindObjectOfType<ScriptGameManager>();
        if (GetComponent<ScriptMonstre>())
        {
            estMonstre = true;
        }
        else
        {
            estMonstre = false;
        }
    }
    private void Update()
    {
       
    }

    public GameObject TrouverCible()
    {
       return  gm.TrouverElementPlusProche(transform.position);
    }

    public Vector3 TrouvePositonCible()
    {
        return TrouverCible().transform.position;
    }

    // Update is called once per frame

}
