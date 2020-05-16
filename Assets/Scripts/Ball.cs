using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float JumpForce;
    public GameObject[]  powerUps;
    public GameObject[]  powerUpsInit;
    private NavMeshAgent agent;

    public GameObject scoreText;
    private Text score;
    private int cont;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        scoreText = GameObject.FindWithTag("Text");

        score = scoreText.GetComponent<Text>();

        powerUpsInit = GameObject.FindGameObjectsWithTag("Coin");

        cont = 5 - powerUpsInit.Length;

        score.text = "Score: " + cont.ToString();

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        /*if (Input.GetButtonDown("Jump") && Time.timeScale > 0.0f)
        {
            Jump();
        }*/

        if(Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }

        if (score && powerUps.Length != 0)
            cont = 6 - powerUps.Length;
            score.text = "Score: " + cont.ToString();
    }

    void FixedUpdate()
    {
        /*if (rb)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
        }*/
    }

    private void Jump()
    {
        /*if (rb)
        { 
            if (Mathf.Abs(rb.velocity.y) < 0.0005f)
            {
                rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
            }   
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        powerUps = GameObject.FindGameObjectsWithTag("Coin");

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Lava") && powerUps.Length != 0)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Lava") && powerUps.Length == 0)
        {
            Destroy(other.gameObject);
        }
    }


    
}
