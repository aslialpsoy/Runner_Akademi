using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject FinPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
                       
        }else if(other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            FinPanel.SetActive(true);
            if (score >= maxScore)
            {
                //Debug.Log("You Win!..");
                PlayerAnim.SetBool("Win",true);
            }else
            {
                //Debug.Log("You Lose!..");
                PlayerAnim.SetBool("Lose",true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("touched obstacle");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
