using UnityEngine;

public class PlayerDeadBody : MonoBehaviour
{
    [SerializeField] private Material _bodyFill;

    public void SetColor(Color color)
    {
        _bodyFill.color = color;
    }
}
