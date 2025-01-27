using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animController;

    public const string IDLE_ANIM = "RifleIdle";
    public const string WALKING_ANIM = "Walking";

    public void StartAnim(string animName)
    {
        animController.Play(animName);
        //animController.SetBool("Walk", true);
    }
}
