using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DotNetRu.Audit.Dto;
using DotNetRu.Authorization;

namespace DotNetRu.Audit
{
    [AbpAuthorize(PermissionNames.Pages_Audit)]
    public class AuditAppService : AsyncCrudAppService<AuditLog, AuditDto, long, PagedResultRequestDto>, IAuditAppService
    {
        public AuditAppService(IRepository<AuditLog, long> repository) : base(repository) { }
    }
}
