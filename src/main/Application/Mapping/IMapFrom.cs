using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Domain.Interfaces;

public interface IMapFrom<T>
{
	void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
