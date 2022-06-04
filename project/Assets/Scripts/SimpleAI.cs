using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public bool isBusy { private set; get; }
    private Vector3 VectorFromSimpleAIToTargetPos;

    public System.Action<SimpleAI> onFinishedMove;

    Tween moveTween;
    Tween rotateTween;

    public void MoveProcess(Vector3 targetPos, float waitTime, float speed, float rotationSpeed)
    {
        moveTween = transform.DOMove(targetPos, speed).SetSpeedBased().SetEase(Ease.Linear).SetAutoKill(false);

        RotationDuringMovement(targetPos, rotationSpeed);

        moveTween.OnPlay(() => isBusy = true);
        moveTween.OnComplete(() => DOVirtual.DelayedCall(waitTime, () => onFinishedMove?.Invoke(this)));

    }

    private void RotationDuringMovement(Vector3 targetPos, float rotationSpeed)
    {
        VectorFromSimpleAIToTargetPos = targetPos - transform.position;

        var quaternionToRotate = Quaternion.FromToRotation(transform.forward, VectorFromSimpleAIToTargetPos) * transform.rotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, quaternionToRotate, rotationSpeed);

    }

}
