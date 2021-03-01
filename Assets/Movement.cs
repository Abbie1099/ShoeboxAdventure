using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float playerspeed;
    private float horizontal;
    private float vertical;
    public Text txt;
    public AudioClip coinsound;
    public AudioSource ad;
    int count = 0;
    public enemy en;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0.0f, -horizontal, 0.0f) * playerspeed * Time.deltaTime);
        transform.Translate(new Vector3(0.0f, 0.0f, vertical) * playerspeed * Time.deltaTime);

    }

    public void loadscene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int temp = scene.buildIndex;
        SceneManager.LoadScene(temp + 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
        if (other.tag == "Coins")
        {
            Destroy(other.gameObject);
            //ad.PlayOneShot(coinsound);
            ad.Play();
            count++;
            txt.text = "Score:" + count;
        }
        if(count >=3)
        {
            en.enabled = true;
        }
        if (count >= 6)
        {
            loadscene();
        }

    }
}
