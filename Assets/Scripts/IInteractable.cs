using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    string GetInteractMessage();

    public void ShowMessage();

    public void HideMessage();

}
