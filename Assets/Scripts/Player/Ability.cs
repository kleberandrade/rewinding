using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject
{

    public string       m_nameAbility = "New Ability";
    public Sprite       m_Sprite;
    public float        m_BaseCoolDown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}
