using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class abilityCoolDown : MonoBehaviour
{
    //definição de qua comando irá executar a abilidade
    public string   m_abilityButtonAxisName;
    public Image    m_darkMask;
    public Text     m_coolDownTextDisplay;

    [SerializeField] private Ability    m_ability;
    [SerializeField] private GameObject m_abilityHolder;
    private Image       m_myButtonImage;
    private float       m_coolDownDuration;
    private float       m_nextReadyTime;
    private float       m_coolDownTimeLeft;


    void Start()
    {
        Initialize(m_ability, m_abilityHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject abilityHolder)
    {
        m_ability = selectedAbility;
        m_myButtonImage = GetComponent<Image>();
        m_myButtonImage.sprite = m_ability.m_Sprite;
        m_darkMask.sprite = m_ability.m_Sprite;
        m_coolDownDuration = m_ability.m_BaseCoolDown;
        m_ability.Initialize(abilityHolder);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > m_nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonDown(m_abilityButtonAxisName))
            {
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        m_coolDownTextDisplay.enabled = false;
        m_darkMask.enabled = false;
    }

    private void CoolDown()
    {
        m_coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(m_coolDownTimeLeft);
        m_coolDownTextDisplay.text = roundedCd.ToString();
        m_darkMask.fillAmount = (m_coolDownTimeLeft / m_coolDownDuration);
    }

    private void ButtonTriggered()
    {
        m_nextReadyTime = m_coolDownDuration + Time.time;
        m_coolDownTimeLeft = m_coolDownDuration;
        m_darkMask.enabled = true;
        m_coolDownTextDisplay.enabled = true;

        m_ability.TriggerAbility();
    }
}