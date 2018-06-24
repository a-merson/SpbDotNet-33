using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DotNetRu.Audit.Dto;

namespace DotNetRu.Audit
{
    public interface IAuditAppService : IAsyncCrudAppService<AuditDto, long, PagedResultRequestDto> { }
}