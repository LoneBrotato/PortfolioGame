using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VolumeTrigger : MonoBehaviour
{
    string targetTag;
#if UNITY_EDITOR
    [SerializeField, TagMaskField] private string TargetTag;

    public void Awake()
    {
        targetTag = TargetTag;
    }

#endif
    [SerializeField] Interactable interaction;
    Rigidbody2D VolumeRigidBody;
    BoxCollider2D VolumeBoxColider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VolumeRigidBody=GetComponent<Rigidbody2D>();
        VolumeBoxColider=GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag(targetTag))
      {
            if(interaction!=null)
            {
                interaction.Activate();
            }
      }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }



}

#if UNITY_EDITOR

public sealed class TagMaskFieldAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(TagMaskFieldAttribute))]
public class TagMaskFieldAttributeEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
    }
}
#endif


