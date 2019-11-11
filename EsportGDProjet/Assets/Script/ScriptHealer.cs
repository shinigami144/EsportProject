﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHealer : MonoBehaviour
{
    // Start is called before the first frame update
    ClassUnite unite;
    ScriptGameManager gm;
    void Start()
    {
        unite = new ClassUnite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrendreDegat(int attaqueEnnemi)
    {
        int degat = attaqueEnnemi - unite.GetDefence();
        if (!unite.PrendreDegat(degat))
        {
            if (GetComponent<ScriptMouvementNPC>())
            {
                // supprimer de la liste 
                Destroy(this);
            }
            else if (GetComponent<MovementPlayer>())
            {
                // GAME  OVER
            }
        }

    }


}