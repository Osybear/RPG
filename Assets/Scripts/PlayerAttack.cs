using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    public LayerMask overlapMask;
    public float overlapRadius;
    public float maxAttackAngle;
    public int damage;

    private void Update() {
        AttackUnit();
    }

    public void AttackUnit() {
        if(Input.GetMouseButtonDown(0)) {
            GameObject nearestUnit = GetNearestUnit();
            if(nearestUnit == null)
                return;

            BasicHealth basicHealth = nearestUnit.GetComponent<BasicHealth>();
                basicHealth.Damage(damage);
        }
    }

    public GameObject GetNearestUnit() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, overlapRadius, overlapMask);
        float smallestAngle = float.MaxValue;
        GameObject tempObj = null;

        foreach(Collider col in hitColliders){
            if(col.gameObject == this.gameObject)   
                continue;
                
            Vector3 targetDir = col.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            if(angle < smallestAngle) {
                tempObj = col.gameObject;
                smallestAngle = angle;
            }
        }
    
        if(smallestAngle < maxAttackAngle)
            return tempObj;
        return null;
    }  
}