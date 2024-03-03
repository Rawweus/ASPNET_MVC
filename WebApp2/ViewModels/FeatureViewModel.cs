using Infrastructure.Entities;

namespace WebApp2.ViewModels;

public class FeatureViewModel
{
	public string Title { get; set; } = null!;
	public string Ingress { get; set; } = null!;
	public List<FeatureItemEntity> FeatureItems { get; set; } = [];
}
