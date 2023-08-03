using AutoMapper;
using ProfileProject.Models.Domain;
using ProfileProject.Models.DTO;

namespace ProfileProject.Mapping;

public partial class Mapping:Profile
{
	public Mapping()
	{
		GetListRegistrationModel();

	}
}
