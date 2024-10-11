using UnityEngine.Events;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    public UnityEvent<string> onLifeEnds;  
    private bool isDying = false;
    private string killerName = "";

    public bool IsDying { get => isDying; private set { } }
    public string KillerName { get => killerName; private set { } }

    private void OnEnable()
    {
        onLifeEnds.AddListener(UpdateDyingState);
        ResetLifeComponent();
    }

    private void UpdateDyingState(string killer)
    {
        isDying = true; 
        killerName = killer;
    }

    public void ResetLifeComponent()
    {
        IsDying = false; 
    }

    private void OnDisable()
    {
        onLifeEnds.RemoveListener(UpdateDyingState); 
    }

    // Re-subscribe when enabled from the pool
    
}