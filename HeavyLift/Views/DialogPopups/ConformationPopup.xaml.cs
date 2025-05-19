using CommunityToolkit.Maui.Views;

namespace HeavyLift.Views.DialogPopups;

public partial class ConformationPopup : Popup
{
	public ConformationPopup()
	{
		InitializeComponent();
	}

	public void BtnYesClicked(object sender, EventArgs e)
	{
		Close(true);
	}

	private void BtnNoClicked(object sender, EventArgs e)
	{
		Close(false);
	}
}