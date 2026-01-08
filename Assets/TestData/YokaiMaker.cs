using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "YokaiMaker", menuName = "YokaiMaker/New Yokai")]
public class YokaiMaker : ScriptableObject
{
    public int Time;
    public int Value;
    public int Price;
    public Sprite Image;
}
