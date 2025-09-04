using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

   // public GameObject CratePrefab;
    public GameObject TapToPlayText;
    public TextMeshProUGUI scoreText;

    public float xPos;
    public float spwanRate;

    bool isGameStarted =false;
    int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&&!isGameStarted)
        {
            InvokeRepeating("CrateSpwaner", 1f, spwanRate);
            isGameStarted = true;
            TapToPlayText.SetActive(false);
        }
    }

    void CrateSpwaner()
    {
        float randomXPos = Random.Range(-xPos, xPos);
        Vector2 spwanpos = new Vector2(randomXPos,6);
        //  Instantiate(CratePrefab, spwanpos, Quaternion.identity);

        GameObject crateObject =  ObjectPool.instance.GetCrate();
        if (crateObject != null)
        {
            crateObject.transform.position = spwanpos;
            crateObject.SetActive(true);
        }  
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
