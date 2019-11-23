using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptMouvementNPC : MonoBehaviour
{
    bool isPartenaire;
    float distanceMin;
    public NavMeshAgent agent;
    private ScriptGameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<ScriptGameManager>();
        isPartenaire = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        distanceMin = 7;
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = GetComponent<ClassUnite>().GetMouvemenetVitesse();
    }

    
    private void MoveToTarget()
    //Fonction qui permet de se diriger vers la cible choisie
    {
        Vector3 targetVector = agent.GetComponent<ScriptCiblageAutre>().TrouvePositonCible();
        if (Vector3.Distance(agent.transform.position,targetVector)>distanceMin)
        {
            agent.SetDestination(targetVector);
        }
    }
    private void Update()
    {

        if (isPartenaire == true)
        {
            MoveToTarget();
        }
        else
        {
           
        }
    }

    public bool InHeroTeam()
    {
        return isPartenaire;
    }

    public void SetInHeroTeam(bool inTeam)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        isPartenaire = inTeam;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (GetComponent<ScriptDps>()|| isPartenaire == false)
            {
                gm.LoadDpsTraining(GetComponent<ClassUnite>().getLevel());
            }
            else if(GetComponent<ScriptTank>()|| isPartenaire == false)
            {

            }
            else if(GetComponent<ScriptHealer>() || isPartenaire == false)
            {

            }
        }
    }


}