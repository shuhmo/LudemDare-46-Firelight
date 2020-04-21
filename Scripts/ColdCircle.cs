using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdCircle : MonoBehaviour
{
    private PlayerHealth health;
    [SerializeField] private GameObject mask;
    private Warmth warmth;
    private bool coldcircle;
    [SerializeField] GameObject Coldsystem;
    // Start is called before the first frame update
    private void Awake()
    {
        health = GetComponent<PlayerHealth>();
        warmth = GetComponent<Warmth>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (warmth.isFreezing())
        {

            mask.transform.localScale = new Vector3(health.GetHealth() / 40, health.GetHealth() / 40,1);
            SetCircle(true);
        }
        if (!warmth.isFreezing())
        {
            mask.transform.localScale = new Vector3(health.GetHealth() / 40, health.GetHealth() / 40, 1);
            if (health.GetHealth()>100)
            {
                SetCircle(false);
            }
        }
    }
    private bool getCircleState()
    {
        return coldcircle;
    }

    private void SetCircle(bool circle)
    {
        Coldsystem.SetActive(circle);
    }
}
