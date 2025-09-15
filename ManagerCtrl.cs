// ManagerCtrl

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerCtrl : MonoBehaviour
{
    public GameObject currentTimeText;
    public GameObject bestTimeText;
    public float timeLapsed;
    public float timeLapsedRounded;
    public float bestTime;
    public GameObject gameOver;
    public GameObject player1Wins;
    public GameObject player2Wins;
    public GameObject tie;
    public bool endCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        if ((SceneManager.GetActiveScene().name == "GameScene") && (PlayerPrefs.GetInt("Players", 1) == 1))
        {
            bestTimeText.GetComponent<Text>().text = "Best Time\n" + PlayerPrefs.GetFloat("bestTime", 0) + " sec";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("SpaceShip1") != null) && (SceneManager.GetActiveScene().name == "GameScene") && (PlayerPrefs.GetInt("Players", 1) == 1))
        {
            if (GameObject.Find("SpaceShip1").GetComponent<SpaceShipCtrl>().alive)
            {
                timeLapsed += Time.deltaTime;
                timeLapsedRounded = Mathf.Round(timeLapsed * 100) / 100;
                currentTimeText.GetComponent<Text>().text = "Time\n" + timeLapsedRounded.ToString() + " sec";
            }
            else if (PlayerPrefs.GetFloat("bestTime", 0) < timeLapsedRounded)
            {
                PlayerPrefs.SetFloat("bestTime", timeLapsedRounded);
                bestTimeText.GetComponent<Text>().text = "Best Time\n" + timeLapsedRounded.ToString() + " sec";
            }
        }
        if (endCheck)
        {
            if (PlayerPrefs.GetInt("Players", 1) == 1   )
            {
                if (GameObject.Find("SpaceShip1").GetComponent<SpaceShipCtrl>().alive == false)
                {
                    gameOver.SetActive(true);
                    endCheck = false;
                }
            }
            else if (GameObject.Find("SpaceShip1").GetComponent<SpaceShipCtrl>().alive == false)
            {
                if (GameObject.Find("SpaceShip2").GetComponent<SpaceShipCtrl>().alive == false)
                {
                    tie.SetActive(true);
                }
                else
                {
                    GameObject.Find("SpaceShip2").GetComponent<SpaceShipCtrl>().Won = true;
                    player2Wins.SetActive(true);
                }
                endCheck = false;
            }
            else if (GameObject.Find("SpaceShip2").GetComponent<SpaceShipCtrl>().alive == false)
            {
                GameObject.Find("SpaceShip1").GetComponent<SpaceShipCtrl>().Won = true;
                player1Wins.SetActive(true);
                endCheck = false;
            }
        }
    }

    public void RestartPressed()
    {
        StartCoroutine(Restart());
    }
    public IEnumerator Restart()
    {
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnePlayer()
    {
        PlayerPrefs.SetInt("Players", 1);
        SceneManager.LoadScene("GameScene");
    }
    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("Players", 2);
        SceneManager.LoadScene("GameScene");
    }
}
////////////////////////////////////////////////////////////////////////////////
