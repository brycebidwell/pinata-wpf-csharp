using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace A9_Bidwell___Pinata {
	public partial class MainWindow : Window {
		// Densities of various metals employed as an unimplemented physics modifier
		public 
		double  D_IR	= 22.56,	//Density in g/cm for iridium,
				D_AU	= 19.30,	// gold,
				D_AG	= 10.49,	// silver,
				D_ZN	= 7.13,		// zinc
                D_TI	= 4.5,		// titanium,
				D_AL	= 2.70;     // aluminum

		protected // I*: Invariant; P*: Physics
		double  PinMass     = 10,	// P* Pinata mass 
				pinMaterial	= 1,	// P* Pinata material
                PinLength   = 1,	// I* P* Pinata cable length 
				DampCoeff   = 3,	// I* P* Slows swing over time
				Theta0      = 65,	// I* P* Angle θ_0 in deg, t = 0
				Alpha0      = 0,	// I* P* Angular v α_0 in deg, t = 0
				dt          = .022, // I* P* Change in time per calc
                BatMass     = 0.25,	// P* Mass of bat (momentum calc)
				batMaterial	= 1,	// P* Bat material
				BatLength	= 1,	// P* Bat length 
				BatLRatio	= 4/3F,	// Length ratio (as difficulty modifier)
				timep, timeb,		// Time for pinata/bat
				hP, wP,				// Height/Width: pinata
				hB, wB;             // Height/Width: bat
		private int     score, highscore;
		private bool    backswing, swinging, paused, hit; // State vars
		private double[] pp, bb;    // Store {θ, α} for pinata, bat

		// *** INITIALIZATION METHODS ***// 
		//**Reset system
		private void Reset () {
			CompositionTarget.Rendering -= PinataAnim;
			CompositionTarget.Rendering -= BatAnim;
			StartPin();
			StartBat();
			lblScoreNum.Content = score;
			lblHighScoreNum.Content = highscore;
		}
		//**Initial values for pinata and other components
		private void StartPin () {
			backswing = swinging = paused = hit = false;
			pp = new double[] {
				Math.PI * Theta0 / 180,		// pp[0]: θ_0
				Math.PI * Alpha0 / 180};    // pp[1]: α_0

			hP = cvs.ActualHeight / 2;      // Canvas height / 2 
			wP = cvs.ActualWidth / 2;       // Canvas width / 2
			hB = 2 * hP - 10;               // Canvas height - 10
			wB = hP * BatLRatio;			// Canvas height * 2/3
			timep = score = 0;              // Init time, score

			// Calculate pinata size and mass (as as hollow object; measure surface area)
			pinBody.RadiusX = pinBody.RadiusY = hP / 9;
			double PinSA	= 4 * Math.PI * Math.Pow(pinBody.RadiusX, 2);
			PinMass			= PinSA * pinMaterial / 15000;

			// Initial positions for pinata rope, body
			pinRope.X1		= wP; pinRope.X2 = wP;	// Init X1, X2
			pinRope.Y1		= -5; pinRope.Y2 = hP;	// Init Y1, Y2
			pinBody.Center	= new Point(wP, hP);	// Init pinata
			CompositionTarget.Rendering += PinataAnim;

			// Calculate bat position, and mass as:
			// density * length / a constant : (approximate)
			BatMass	= batMaterial * Math.PI * (wP - wB) / 500;
			bat.X1	= wP; bat.X2 = wP + wB;      // Init X1, X2
			bat.Y1	= hB; bat.Y2 = hB;           // Init Y1, Y2
		}

		//**Initial bat values
		private void StartBat () {
			CompositionTarget.Rendering -= BatAnim;
			swinging = backswing = false;           // Reset state bools
			timeb = 0;                              // Reset time
		}

		// *** ANIMATION AND STATE EVALUATION METHODS ***// 
		//**Animates pinata.
		private void PinataAnim ( object sender, EventArgs e ) {
			// Solve ODE to determine new {θ, α}
			ODESolver.Function[] f = new ODESolver.Function[2] { f1, f2 };
			pp = ODESolver.RungeKutta4(f, pp, timep, dt);

			// Render pinata at updated point
			Point pt = new Point(
				wP + hP * Math.Sin(pp[0]),
				0  + hP * Math.Cos(pp[0]));
			pinBody.Center	= pt;		// New pinata center
			pinRope.X2		= pt.X;		// Recenter end of rope
			pinRope.Y2		= pt.Y;		//  on pinata center
			timep += dt;				// Increment time

			//FAIL CONDITION 2: Buggy. If Pinata stops near the bottom of its swing
			if (Math.Cos(pp[0]) > .99 && Math.Abs(pp[1]) < .0002)
				Fail();
		}

		//**Animates bat.
		private void BatAnim ( object sender, EventArgs e ) {
			// Check if swing complete (backswing = true). If so, replace f4 with 
			//  modified ODE dα function f5 to return home
			ODESolver.Function[] f;
			if (!backswing)
				f = new ODESolver.Function[2] { f3, f4 };
			else {
				f = new ODESolver.Function[2] { f3, f5 };
				if (Math.Cos(bb[0]) > .999 && Math.Abs(bb[1]) < 0.005) { // Returned home
					StartBat();
					if (!hit)       // Test for a miss when the bat stops
						Fail();
				}
			}
			bb = ODESolver.RungeKutta4(f, bb, timeb, dt);

			//If the bat reaches the left side: 2nd ODE fn on next iteration
			if (!backswing && Math.Cos(bb[0]) < -0.99)
				backswing = true;

			//Collision detection. Transfer bat momentum
			var collide = pinBody.FillContainsWithDetail(bat.RenderedGeometry);
			if (!hit && collide != IntersectionDetail.NotCalculated
				&& collide != IntersectionDetail.Empty) {
				pp[1]	-= BatMass * bb[1] / PinMass; // Momentum transfer
				hit		= true;
				lblScoreNum.Content = ++score;
			}

			// Render bat at updated point
			bat.X2 = wP + wB * Math.Cos(bb[0]);
			bat.Y2 = hB - wB * Math.Sin(bb[0]);
			timeb += dt;
		}

		//**Failure handling
		private void Fail () {
			string winstr = "Your score: " + score;
			if (score > highscore) {
				highscore = score;
				winstr = "A new high score!\r\n" + winstr;
			} else
				winstr += "\r\nCurrent high score: " + highscore;

			MessageBoxResult mbr = MessageBox.Show(winstr += "\r\n\r\nTry again?", "¡ Failed !", MessageBoxButton.YesNo);
			if (mbr == MessageBoxResult.Yes)
				Reset();
			else
				Close();
		}

		// *** ODE FUNCTIONS ***// 
		//**Angular velocity α for pinata
		private double f1 ( double[] pp, double t ) { return pp[1]; }

		//**Determine change in α using: 
		//   -g * sin(θ) / length - dampCoeff * α / mass
		private double f2 ( double[] pp, double t ) {
			double  m = PinMass,   l = PinLength,   b = DampCoeff;
			return -9.8 * Math.Sin(pp[0]) / l - b * pp[1] / m;
		}

		//**α for bat
		private double f3 ( double[] bb, double t ) { return bb[1]; }

		//**dα for bat on foreswing
		private double f4 ( double[] bb, double t ) {
			double  m = BatMass,   l = BatLength,   b = 0;
			return 30 * Math.Sin(bb[0]) / l - b * bb[1] / m;
		}
		//**dα for bat on return swing - whip around quickly, rapidly decays		
		private double f5 ( double[] bb, double t ) {
			double  m = BatMass,   l = BatLength,   b = 3.3;
			return -40 * Math.Sin(bb[0]) / l - b * bb[1];
		}

		// *** SUPPORT METHODS ***// 
		//**Keypress handler
		private void Pinata_Game_KeyDown ( object sender, KeyEventArgs e ) {
			if (!swinging && !paused && (e.Key == Key.Space || e.Key == Key.Enter)) {
				StartBat();
				swinging = true;
				hit = false;
				bb = new double[] { 0, 1 };
				CompositionTarget.Rendering += BatAnim;
			} else if (e.Key == Key.P) {
				TogglePause();
			}
		}

		//**Pauses or unpauses game
		private void TogglePause () {
			if (paused) {
				paused = false;
				CompositionTarget.Rendering += PinataAnim;
				if (swinging)
					CompositionTarget.Rendering += BatAnim;
			} else {
				CompositionTarget.Rendering -= PinataAnim;
				CompositionTarget.Rendering -= BatAnim;
				paused = true;
			}
		}

		//**Restart game and change cord length/object size to match new window
		private void Pinata_Game_SizeChanged ( object sender, SizeChangedEventArgs e ) { Reset(); }
	}
}