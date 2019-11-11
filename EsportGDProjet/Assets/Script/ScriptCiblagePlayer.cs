using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCiblagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit toucherRayon;
    ScriptGameManager gm;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayon = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayon, out toucherRayon)){
                Debug.Log(toucherRayon.collider);
                // si sol toucher -> action on position;
                // si NPC toucher -> Heal si healer sinon rien
                // si Monstre toucher -> action de combat
                // si player toucher -> rien 
            }
            // activer raycast 
            // fond object toucher
            // recentrer son y 
            // activer son action
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
