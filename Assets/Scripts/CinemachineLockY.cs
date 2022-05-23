using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]

public class CinemachineLockY : CinemachineExtension
{
    [Tooltip("Lock the cameras Y position to this value")]
    public float yPosition;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = yPosition;
            state.RawPosition = pos;
        }
    }

}

