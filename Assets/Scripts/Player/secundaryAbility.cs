using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(menuName = "Abilities/SecundaryAbility")]
public class secundaryAbility : Ability
{
    private specialAbility m_sAbility;

    public override void Initialize(GameObject obj)
    {
        m_sAbility = obj.GetComponent<specialAbility>();
    }

    public override void TriggerAbility()
    {
        m_sAbility.Shield();
    }

}