using CommunityToolkit.Maui.Views;

namespace HeavyLift.Views.DialogPopups;

public partial class ConformationMessagePopup : Popup
{
	public ConformationMessagePopup(string Message)
    {
        InitializeComponent();
        MessageLabel.Text = Message;
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