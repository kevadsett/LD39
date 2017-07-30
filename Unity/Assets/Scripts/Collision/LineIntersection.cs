using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LineIntersection {

	public static bool Get (Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, out Vector3 intersect)
	{
		float Ax, Bx, Cx, Az, Bz, Cz, aNum, bNum, abDenom, num;
		float x1lo, x1hi, z1lo, z1hi;

		intersect = Vector3.zero;

		Ax = p2.x - p1.x;
		Bx = p3.x - p4.x;

		// X bound box test/
		if(Ax < 0) {
			x1lo = p2.x;
			x1hi = p1.x;
		} else {
			x1hi = p2.x;
			x1lo = p1.x;
		}

		if (Bx > 0) {
			if (x1hi < p4.x || p3.x < x1lo) {
				return false;
			}
		} else {
			if (x1hi < p3.x || p4.x < x1lo) {
				return false;
			}
		}

		Az = p2.z - p1.z;
		Bz = p3.z - p4.z;

		// Z bound box test//
		if (Az < 0) {                  
			z1lo = p2.z;
			z1hi = p1.z;
		} else {
			z1hi = p2.z;
			z1lo = p1.z;
		}

		if (Bz>0) {
			if (z1hi < p4.z || p3.z < z1lo) {
				return false;
			}
		} else {
			if (z1hi < p3.z || p4.z < z1lo) {
				return false;
			}
		}

		Cx = p1.x - p3.x;
		Cz = p1.z - p3.z;

		aNum = Bz * Cx - Bx * Cz;  // alpha numerator//
		abDenom = Az * Bx - Ax * Bz;  // both denominator//

		// alpha tests//

		if (abDenom > 0) {
			if (aNum < 0 || aNum > abDenom) {
				return false;
			}
		} else {
			if (aNum > 0 || aNum < abDenom) {
				return false;
			}
		}

		bNum = Ax*Cz - Az*Cx;  // beta numerator//

		// beta tests //

		if (abDenom > 0) {                          
			if(bNum < 0 || bNum > abDenom) {
				return false;
			}
		} else {
			if(bNum > 0 || bNum < abDenom) {
				return false;
			}
		}

		// check if they are parallel

		if (abDenom == 0) {
			return false;
		}

		// compute intersection coordinates //

		num = aNum * Ax;
		intersect.x = p1.x + num / abDenom;

		num = aNum * Az;
		intersect.z = p1.z + num / abDenom;

		return true;
	}
}