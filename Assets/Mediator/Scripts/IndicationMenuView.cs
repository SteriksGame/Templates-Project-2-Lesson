using UnityEngine;
using UnityEngine.UI;

public class IndicationMenuView : WindowBase
{
    [SerializeField] private Text _healText;
    [SerializeField] private Text _levelText;

    public void ChangeViewHeal(int value) => _healText.text = $"Здоровье: {value}";

    public void ChangeViewLevel(int value) => _levelText.text = $"Уровень: {value}";
}