using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaycastSelectionManager
{
	public class ChangeObjectMaterial : BaseSelector
	{
		#region PUBLIC_VARS
		
		public Material selectedMaterial;
		public Material unSelectedMaterial;
		public Renderer renderer;
	    #endregion

	    #region PRIVATE_VARS
	    
	    #endregion

	    #region UNITY_CALLBACKS

	    private void Awake()
	    {
		    renderer.material = unSelectedMaterial;
	    }

	    #endregion

	    #region PUBLIC_METHODS
	    public override void OnSelectorSelected(Ray ray, RaycastHit hit)
	    {
		    base.OnSelectorSelected(ray, hit);
		    renderer.material = selectedMaterial;
	    }

	    public override void OnSelectorRemoved()
	    {
		    base.OnSelectorRemoved();
		    renderer.material = unSelectedMaterial;
	    }
	    #endregion

	    #region PRIVATE_METHODS
	    
	    #endregion
	}
}