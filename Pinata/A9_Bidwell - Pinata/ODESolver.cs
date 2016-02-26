/* Ordinary DiffEq (ODE) solver using the Runge-Kutta method. 
   Yes, I do know the physics and most of the math behind this, 
   yes, I could probably write something similar in time,
    no, I haven't taken DiffEq, so
	no, I didn't write this class de novo.

   Adapted from: http://www.codeproject.com/Articles/124966/A-Pendulum-and-its-Corresponding-Oscillations-Show. 
   Defines a delegate function that takes a double[] x and a time variable double t as parameters.*/

namespace A9_Bidwell___Pinata {
	public class ODESolver {
		public delegate double Function (
		double[] x, double t );

		public static double[] RungeKutta4 (
		Function[] f, double[] x0, double t0, double dt ) {
			int n = x0.Length;
			double      t   = t0;
			double[]	k1	= new double[n],
						k2	= new double[n],
						k3	= new double[n],
						k4	= new double[n],
						x1	= new double[n],
                        x	= x0;

			for (int i = 0; i < n; i++)
				k1[i] = dt * f[i](x, t);
			for (int i = 0; i < n; i++)
				x1[i] = x[i] + k1[i] / 2;
			for (int i = 0; i < n; i++)
				k2[i] = dt * f[i](x1, t + dt / 2);
			for (int i = 0; i < n; i++)
				x1[i] = x[i] + k2[i] / 2;
			for (int i = 0; i < n; i++)
				k3[i] = dt * f[i](x1, t + dt / 2);
			for (int i = 0; i < n; i++)
				x1[i] = x[i] + k3[i];

			for (int i = 0; i < n; i++)
				k4[i] = dt * f[i](x1, t + dt);
			for (int i = 0; i < n; i++)
				x[i] +=	(k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) / 6;
			return x;
		}
	}
}
