using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionController : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public GameObject SwordPartical;
    public GameObject ShieldPartical;
    private Cinemachine.CinemachineImpulseSource attackInpulse;


    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponentInChildren<Animator>();
        attackInpulse = this.GetComponent<Cinemachine.CinemachineImpulseSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack"))
        {
            if(other.gameObject.tag == "Sword")
            {
                Debug.Log("Player[Sword] attacks the door.");
                //swordParticalSys.GetComponent<ParticleSystem>().Play();
                SwordPartical.SetActive(true);
                attackInpulse.GenerateImpulse();
            }
            if (other.gameObject.tag == "Shield")
            {
                Debug.Log("Player[Shield] attacks the door.");
                ShieldPartical.SetActive(true);
                attackInpulse.GenerateImpulse();
            }
        }
        else
        {
            SwordPartical.SetActive(false);
            ShieldPartical.SetActive(false);
        }
    }
}
