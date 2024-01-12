using Labtest1.Model;
using Labtest1.Viewmodel;
using LabTest1;

namespace Labtest1;

public partial class q3 : ContentPage
{
	public q3(PostsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}