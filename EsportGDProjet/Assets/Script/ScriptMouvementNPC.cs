using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptMouvementNPC : MonoBehaviour
{
    bool isPartenaire = true;
    float distanceMin = 5;
    public NavMeshAgent agent;
    

    void NpcFollow()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("Le component NavMeshAgent n'est pas attache a " + gameObject.name);
        }
        else
        {
            MoveToTarget();
        }
    }
    private void MoveToTarget()
    //Fonction qui permet de se diriger vers la cible choisie
    {
        Vector3 targetVector = agent.GetComponent<ScriptCiblageAutre>().TrouvePositonCible();
        //Debug.Log("Monstre numero " + GetComponent<ScriptMonstre>().GetUnite().GetNom() + " : " + targetVector); ;
        agent.SetDestination(targetVector);
    }

    private void Update()
    {
        NpcFollow();
    }
}