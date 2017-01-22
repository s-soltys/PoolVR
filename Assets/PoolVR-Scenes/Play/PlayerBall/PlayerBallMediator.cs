using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerBallHitAction))]
public class PlayerBallMediator : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }

    [Inject]
    public StageStatistics Stats { get; private set; }
    
	void Update ()
    {
	    if (ForceSelector.IsActive && Input.GetMouseButtonUp(0))
        {
            GetComponent<PlayerBallHitAction>().Hit(ForceSelector.Strength);
            Stats.Hits += 1;
        }	
	}

}
