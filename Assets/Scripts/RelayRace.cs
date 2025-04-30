using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    [SerializeField] Transform[] unitsInRace = new Transform[4];

    private int currentRunner = 0;

    void Start()
    {
        for (int i = 0; i < unitsInRace.Length; i++)
        {
            unitsInRace[i].gameObject.AddComponent<UnitInRaceMoving>();
        }

        unitsInRace[0].gameObject.GetComponent<UnitInRaceMoving>().StartRace(unitsInRace[1].transform.position);
    }

    void Update()
    {
        if (!unitsInRace[currentRunner].gameObject.GetComponent<UnitInRaceMoving>().ismoving)
        {
            currentRunner = (currentRunner + 1) % unitsInRace.Length;
            unitsInRace[currentRunner].GetComponent<UnitInRaceMoving>().StartRace(unitsInRace[(currentRunner + 1) % unitsInRace.Length].transform.position, Random.Range(1f,4f));
        }
        
    }
}
