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
    public static int[] s_characters_dialog_index = new int[12];

}
