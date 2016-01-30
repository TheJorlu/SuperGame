using UnityEngine;
using UnityEditor;

public class ImportShenanigans : AssetPostprocessor 
{
	void OnPreprocessModel()
	{
		ModelImporter modelImporter = (ModelImporter)assetImporter;
		modelImporter.importMaterials = false;
	}	
}
