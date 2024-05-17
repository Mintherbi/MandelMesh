using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MandelMesh.Quaternion
{
    public class Quaternion
    {
        public double a {get; set;}
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }

        Quaternion(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d; 
        }

        public Point3d Extract_Point(int h)
        {
            Point3d extract = new Point3d();

            if (h == 1) { extract = new Point3d(this.b, this.c, this.d); }
            else if (h == 2) { extract = new Point3d(this.a, this.c, this.d); }
            else if (h == 3) { extract = new Point3d(this.a, this.b, this.d); }
            else if (h == 4) { extract = new Point3d(this.a, this.b, this.c); }
            else { extract = new Point3d(0, 0, 0); }

            return extract;
        }

        public static Quaternion operator +(Quaternion A, Quaternion B)
        {
            return new Quaternion(
            A.a + B.a,
            A.b + B.b,
            A.c + B.c,
            A.d + B.d);
        }
        public static Quaternion operator *(Quaternion A, Quaternion B)
        {
            return new Quaternion(
                (A.a * B.a) - (A.b * B.b) - (A.c * B.c) - (A.d * B.d),
                (A.a * B.b) + (A.b * B.a) + (A.c * B.d) - (A.d * B.c),
                (A.a * B.c) - (A.b * B.d) + (A.c * B.a) + (A.d * B.b),
                (A.a * B.d) + (A.b * B.c) - (A.c * B.b) + (A.d * B.a)
                );
        }

        public static Quaternion operator ^(Quaternion A, int n)
        {
            Quaternion result = new Quaternion(0, 0, 0, 0);
            result = A;

            for(int x = 1; x < n; x++)
            {
                result = result * A;
            }

            return result; 
        }
    }
}
