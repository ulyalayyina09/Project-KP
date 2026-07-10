using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnSelect();
    void OnUnselect();
    void Open();
}