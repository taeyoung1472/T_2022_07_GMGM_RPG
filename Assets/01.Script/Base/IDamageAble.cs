using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    /// <summary> ������ �ֱ� </summary>
    public void Damage(float amount, Vector3 orginPos = default(Vector3), float force = 1);
}
