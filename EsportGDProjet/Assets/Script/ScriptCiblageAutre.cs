using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCiblageAutre : MonoBehaviour
{
    // Start is called before the first frame update
    // Composant pour les NPC et Monstre
    bool estMonstre;
    void Start()
    {
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

    public Vector3 TrouvePositonCible()
    {
        ScriptGameManager gm = FindObjectOfType<ScriptGameManager>();
        Debug.Log(gm);
        GameObject g = gm.TrouverElementPlusProche(transform.position);
        Debug.Log(g);
        return g.transform.position;
    }

    // Update is called once per frame

}
