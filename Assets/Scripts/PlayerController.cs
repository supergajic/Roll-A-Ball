using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private bool win;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetScoreText();
        win = false;
	}
	
	// Update is called once per frame
	void Update () {

        //Kan endast styra med kontroller. Jag har använt mig av en PS4 kontroller.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (win)
        {
            // Detta är KVADRAT symbolen på PS4 kontroller som gör att man kan starta om spelet.
            if (Input.GetButton("Fire1"))
            {
                EditorSceneManager.LoadScene("MainGame");
            }
        }
        
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Pick Up"))
        {
            col.gameObject.SetActive(false);
            count++;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= 16)
        {
            winText.GetComponent<Text>().enabled = true;
            win = true;
        }
        else
        {
            winText.GetComponent<Text>().enabled = false;
        }
    }
}
