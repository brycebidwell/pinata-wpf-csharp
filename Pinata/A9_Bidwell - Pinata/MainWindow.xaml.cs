// Notes:
//	1) Size/mass of bat/pinata change with window size, altering physics
//  2) Amplitude of pinata swing decays over time
//	3) Extra failure condition: If pinata stops moving :: BUGGY
//	4) Changing dt smooths the animation but slows down the game somewhat; 
//		The physics become realistic, but perhaps a bit boring.

using System.Windows;

namespace A9_Bidwell___Pinata {
	public partial class MainWindow : Window {

		public MainWindow () { InitializeComponent(); }

		private void Pinata_Game_Loaded ( object sender, RoutedEventArgs e ) {
			pinMaterial = D_AU;
			batMaterial = D_ZN;
			BatLRatio = 1 + 1/3F * 5/6F;
            Reset(); }

		private void btnTweak_Click ( object sender, RoutedEventArgs e ) {
			ModifierForm mf = new ModifierForm(this);
			mf.ShowDialog();
			double[] tweakVals = mf.toMain;
			pinMaterial = tweakVals[0];
			batMaterial = tweakVals[1];
			BatLRatio = 1 + 1 / 3F * tweakVals[2] / 6;
			Reset();
			btnTweak.IsEnabled = false;
		}

	}
}