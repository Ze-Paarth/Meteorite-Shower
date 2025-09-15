// SpaceShipCtrl

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCtrl : MonoBehaviour
{
    public Quaternion targetRotation;
    public int lookX;
    public int lookY;
    public AnimationClip explosionClip;
    public bool alive;
    public GameObject laser;
    public GameObject player2;
    public string ID;
    public bool Won;
    public KeyCode rightButton;
    public KeyCode leftButton;
    public KeyCode upButton;
    public KeyCode downButton;
    public bool look;
    
    // Start is called before the first frame update
    void Start()
    {
        if ((PlayerPrefs.GetInt("Players", 2) == 2) && (ID == "1"))
        {
            this.transform.position = new Vector2(-5, 2);
            player2.SetActive(true);
            GameObject.Find("Times").SetActive(false);
        }
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            lookX = 0;
            lookY = 0;
            look = false;
            if (Input.GetKey(rightButton) && this.transform.position.x < Camera.main.aspect * Camera.main.orthographicSize)
            {
                this.transform.position = new Vector2(this.transform.position.x + Time.deltaTime * 10, this.transform.position.y);
                lookX = 1;
                look = true;
            }
            if (Input.GetKey(leftButton) && this.transform.position.x > -Camera.main.aspect * Camera.main.orthographicSize)
            {
                this.transform.position = new Vector2(this.transform.position.x - Time.deltaTime * 10, this.transform.position.y);
                lookX -= 1;
                look = true;
            }
            if (Input.GetKey(upButton) && this.transform.position.y < Camera.main.orthographicSize)
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + Time.deltaTime * 10);
                lookY = 1;
                look = true;
            }
            if (Input.GetKey(downButton) && this.transform.position.y > -Camera.main.orthographicSize)
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - Time.deltaTime * 10);
                lookY -= 1;
                look = true;
            }
            if (Won)
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + Time.deltaTime * 30);
                lookY = 1;
                look = true;
            }
            if (look)
            {
                // Look at the Final Rotation
                targetRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(lookX, lookY, 0));
                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, Time.deltaTime * 1000f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Meteor") || (other.tag == ID))
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.Find("SpaceShip1").GetComponent<Collider2D>().enabled = false;
        player2.GetComponent<Collider2D>().enabled = false;
        alive = false;
        this.GetComponent<Animator>().SetBool("Dead", true);
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject, explosionClip.length / 0.4f);
    }

    public void Shoot()
    {
        Instantiate(laser, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90));
    }
}
////////////////////////////////////////////////////////////////////////////////
