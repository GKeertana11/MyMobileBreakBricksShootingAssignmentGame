using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onclicks: MonoBehaviour
{
    public Button upButton;
    public GameObject player;
    Rigidbody rb;
    public GameObject prefab;
    public Transform bulletlauncher;
    public float speed;
    public bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        upButton.onClick.AddListener(Move);
        rb = prefab.GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.touchCount>0)
        { 
                Touch touch = Input.touches[0];
            
            if(touch.phase==TouchPhase.Began )
            {
                Debug.Log("Movement started");
                

            }
           else if(touch.phase==TouchPhase.Stationary)
            {
             
                rb.velocity = player.transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            else if(touch.phase==TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }

        }*/
    }
    public void Move()
    {
        if (isShooting == true)
        {
            Debug.Log("Shoot");
            Instantiate(prefab, bulletlauncher.transform.position, Quaternion.identity);
            rb.velocity =  Vector3.forward * speed * Time.deltaTime;
        }
        else
            Debug.Log("Press button");


    }
    public void OnPointerDown()
    {
        isShooting = true;
        Move();
    }
    public void OnPointerUp()
    {
        isShooting = false;
    }
    
}
