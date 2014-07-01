using UnityEngine;
using UnityEditor;
 
public class FBXImportSettings : AssetPostprocessor
{
    void OnPreprocessModel()
    {
        ModelImporter importer = (ModelImporter)assetImporter;
 
        // Don't import materials
        importer.importMaterials = false;
    }
}