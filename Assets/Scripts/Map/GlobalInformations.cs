using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumDirection
{
    SOUTH,
    NORTH,
    EAST,
    WEST,
    DEFAULT
};
public class GlobalInformations : MonoBehaviour
{
    public static EnumDirection s_Direction = EnumDirection.DEFAULT;
}
