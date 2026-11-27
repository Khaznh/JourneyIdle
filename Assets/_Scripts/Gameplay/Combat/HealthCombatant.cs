using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthCombatant : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image fillImage;

    private Combatant combatant;

    private void Awake()
    {
        combatant = GetComponentInParent<Combatant>();
    }

    private void Start()
    {
        EventManager.Instance.OnHealthChange += Instance_OnHealthChange;
    }

    private void Instance_OnHealthChange(Combatant combatant, int curr, int max)
    {
        if (this.combatant != combatant)
        {
            return;
        }

        healthText.text = curr.ToString();
        fillImage.fillAmount = (float) curr / max;
    }
}
