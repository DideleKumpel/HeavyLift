using CommunityToolkit.Maui.Views;

namespace HeavyLift.Views.DialogPopups;

public partial class MessagePopup : Popup
{
	public MessagePopup( string Message)
	{
        InitializeComponent();
        MessageLabel.Text = Message;

    }

	public void BtnOkClicked(object sender, EventArgs e)
	{
		Close();
    }
}