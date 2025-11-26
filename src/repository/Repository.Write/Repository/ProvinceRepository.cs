using Domain.Repository;
using Domain.Write.Entities;
using Repository.Write.EFContext;


namespace Repository.Write;

public class ProvinceRepository(EFDBContext eFContext) : BaseRepository<int, Province>(eFContext), IProvinceRepository
{
}
