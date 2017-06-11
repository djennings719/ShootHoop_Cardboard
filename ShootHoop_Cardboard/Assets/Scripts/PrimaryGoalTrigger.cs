using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryGoalTrigger : MonoBehaviour {

    public int scoreValue;

    private void OnTriggerEnter(Collider other)
    {
        SecondaryGoalTrigger bottom = GetComponentInChildren<SecondaryGoalTrigger>();
        bottom.ExpectCollider(other, scoreValue);
    }
}
