using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "EldoradoExam/Item", order = 0)]
public class ScriptableItem : ScriptableObject
{
    [SerializeField] private Sprite _icon;

    public Sprite Icon { get => _icon; }
}
