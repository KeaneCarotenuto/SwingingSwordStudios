using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New AI Package", menuName = "AIPackage", order = 51)]
public class AIPackage : ScriptableObject
{
    [SerializeField]
    public string packageName;

    public enum PackageType
    {
        IDLE,
        PATROL,
        TRAVEL,
        ATTACK
    }

    public int ff;
    public PackageType packageType;

    public GameObject target;
}
