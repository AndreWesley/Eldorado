using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "EldoradoExam/Item", order = 0)]
public class ScriptableItem : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
}
