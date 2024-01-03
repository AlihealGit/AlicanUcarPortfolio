using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStationAdjusted
{
    internal class RotationMatrixCalculator
    {
        Matrix4 RotationX = new Matrix4();
        Matrix4 RotationY = new Matrix4();
        Matrix4 RotationZ = new Matrix4();
        Vector3 gyroAngles = new Vector3();
        float preTime = 0;
        public RotationMatrixCalculator()
        {

        }

        public (Matrix4, Matrix4, Matrix4) EularToRotationMatrix(Vector3 EularAngles)
        {
            EularAngles.X = EularAngles.X * Convert.ToSingle(Math.PI) / 180f;
            EularAngles.Y = EularAngles.Y * Convert.ToSingle(Math.PI) / 180f;
            EularAngles.Z = EularAngles.Z * Convert.ToSingle(Math.PI) / 180f;

            float cosx = Convert.ToSingle(Math.Cos(EularAngles.X));
            float sinx = Convert.ToSingle(Math.Sin(EularAngles.X));
            float cosy = Convert.ToSingle(Math.Cos(EularAngles.Y));
            float siny = Convert.ToSingle(Math.Sin(EularAngles.Y));
            float cosz = Convert.ToSingle(Math.Cos(EularAngles.Z));
            float sinz = Convert.ToSingle(Math.Sin(EularAngles.Z));

            RotationX = MatrixHelper(1, 0, 0, 0, /**/ 0, cosx, sinx, 0, /**/ 0, -sinx, cosx, 0, /**/ 0, 0, 0, 1);
            RotationY = MatrixHelper(cosy, 0, -siny, 0, /**/ 0, 1, 0, 0, /**/ siny, 0, cosy, 0, /**/ 0, 0, 0, 1);
            RotationZ = MatrixHelper(cosz, sinz, 0, 0, /**/ -sinz, cosz, 0, 0, /**/ 0, 0, 1, 0, /**/ 0, 0, 0, 1);

            return (RotationX, RotationY, RotationZ);
        }

        public Vector3 AngleCalculationFromGyro(Vector3 gyroAngles)
        {
            float millis = Convert.ToSingle(DateTimeOffset.Now.ToUnixTimeMilliseconds());
            if (preTime == 0) preTime = millis;
            float interval = (millis - preTime) * 0.001f;
            preTime = millis;
            Vector3 rotationAngles = new Vector3();
            rotationAngles.X += gyroAngles.X * interval;
            rotationAngles.Y += gyroAngles.Y * interval;
            rotationAngles.Z += gyroAngles.Z * interval;
            return rotationAngles;
        }

        public Matrix4 QuarternationToRotationMatrix(Vector4 q)
        {
            Matrix4 First, Second, Last = new Matrix4();

            First = MatrixHelper(q.W, q.Z, -q.Y, q.X, /**/ -q.Z, q.W, q.X, q.Y, /**/ q.Y, -q.X, q.W, q.Z, /**/ -q.X, -q.Y, -q.Z, q.W);
            Second = MatrixHelper(q.W, q.Z, -q.Y, -q.X, /**/ -q.Z, q.W, q.X, -q.Y, /**/ q.Y, -q.X, q.W, -q.Z, /**/ q.X, q.Y, q.Z, q.W);
            Last = First * Second;
               
            return Last;
        }

        private Matrix4 MatrixHelper(float M11, float M12, float M13, float M14, float M21, float M22,
            float M23, float M24, float M31, float M32, float M33, float M34, float M41, float M42, float M43, float M44)
        {
            Matrix4 matrix = new Matrix4();
            matrix.M11 = M11;
            matrix.M12 = M12;
            matrix.M13 = M13;
            matrix.M14 = M14;
            matrix.M21 = M21;
            matrix.M22 = M22;
            matrix.M23 = M23;
            matrix.M24 = M24;
            matrix.M31 = M31;
            matrix.M32 = M32;
            matrix.M33 = M33;
            matrix.M34 = M34;
            matrix.M41 = M41;
            matrix.M42 = M42;
            matrix.M43 = M43;
            matrix.M44 = M44;

            return matrix;
        }
    }
}
