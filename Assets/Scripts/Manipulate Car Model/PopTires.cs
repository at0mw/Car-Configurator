using UnityEngine;

public class PopTires : MonoBehaviour
{

    [SerializeField]private Animator animator;
    private bool _currentState;
    private void Start()
    {
        var stackButton = GetComponent<UnityEngine.UI.Button>();
        stackButton.onClick.AddListener(TogglePopTire);
    }

    private void TogglePopTire()
    {
        Debug.Log("Pop Tire Script Running");
        _currentState = !_currentState;
        animator.SetBool("TirePop", _currentState);
    }
}
