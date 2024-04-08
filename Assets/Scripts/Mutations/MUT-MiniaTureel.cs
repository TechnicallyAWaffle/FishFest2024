using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniaTureelMutation : MutationBase, IMutations
{
    [SerializeField]
    float camoTime = 1f;

    [SerializeField]
    float camoAlpha = 0.33f;

    public override Sprite BodySprite => bodySprite;
    public override Sprite MouthSprite => mouthSprite;

    float timeNoMovement = 0f;

    public override void MutationActive() {}

    public override void MutationPassive()
    {
        if (Player.Instance.movementSystem.IsMoving)
        {
            Player.Instance.BodySpriteRenderer.color = Color.white;
            Player.Instance.Invisible = false;
            timeNoMovement = 0;
            return;
        }

        timeNoMovement += Time.deltaTime;
        float currentAlpha = Mathf.Lerp(1, camoAlpha, timeNoMovement / camoTime);
        Player.Instance.BodySpriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
        if (timeNoMovement >= camoTime)
        {
            Player.Instance.Invisible = true;
            Debug.Log("Invisible!!! (TODO: currently not used by enemies)");
        }
    }
}
