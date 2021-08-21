using System;
using UnityEngine;

public interface PlacenoteListener1
{
	void OnPose(Matrix4x4 outputPose, Matrix4x4 arkitPose);
	void OnStatusChange(LibPlacenote1.MappingStatus prevStatus, LibPlacenote1.MappingStatus currStatus);
}

