using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム取得時に実行される定義元
/// </summary>
public interface IGetItem
{
    public void GetItem(GameObject gameObject);
}
