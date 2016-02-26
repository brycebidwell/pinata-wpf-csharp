using System.Windows.Forms;

namespace A9_Bidwell___Pinata {
	public partial class ModifierForm : Form {
		private MainWindow main;
		public double[] toMain { get; private set; }

		public ModifierForm ( MainWindow main ) {
			InitializeComponent();
			this.main = main;
		}

		private double ChangeVal(ComboBox cb) {
			double ret;

			if(!double.TryParse(cb.Text.ToString(), out ret))
				switch(cb.Text.ToString()) {
					case "Iridium"	: ret = main.D_IR; break;
					case "Gold"		: ret = main.D_AU; break;
					case "Silver"	: ret = main.D_AG; break;
					case "Zinc"		: ret = main.D_ZN; break;
					case "Titanium" : ret = main.D_TI; break;
					case "Aluminum"	: ret = main.D_AL; break;
					default:		  ret = main.D_AG; break;
				}
			return ret;
		}

		private void ModifierForm_FormClosing ( object sender, FormClosingEventArgs e ) {
			toMain = new double[] {
				ChangeVal(cbPinataMaterial),
				ChangeVal(cbBatMaterial),
				ChangeVal(cbBatLength) };
		}
	}
}
