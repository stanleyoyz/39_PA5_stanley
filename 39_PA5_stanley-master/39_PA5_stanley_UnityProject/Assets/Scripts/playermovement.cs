using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public float speed;
    Rigidbody PlayerRigidbody;
  public float score = 0;
    public Text coincollect;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);
        
        if (score >= 8)
        {
            SceneManager.LoadScene("GameWin");
        }
        coincollect.text = "Coins collected: " + score;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            score += 1;
            
        }
        if (other.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("gamelose");
            score = 0;
        }
        if (score == 4)
        {
            SceneManager.LoadScene("Gameplay_Level2");
        }
    }
   
}
