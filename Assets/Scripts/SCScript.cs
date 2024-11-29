using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SCScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text enemiesShooted;
    private int numEnemsHit;
    void Start()
    {
        numEnemsHit = 0;
        enemiesShooted.text = numEnemsHit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore()
    {
        numEnemsHit++;
        enemiesShooted.text = numEnemsHit.ToString();
    }
}
