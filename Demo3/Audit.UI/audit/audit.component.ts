import { Component, Injector, ViewChild } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from "shared/paged-listing-component-base";
import { AuditServiceProxy, AuditDto, PagedResultDtoOfAuditDto } from "shared/service-proxies/service-proxies";
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  templateUrl: './audit.component.html',
  animations: [appModuleAnimation()]
})
export class AuditComponent extends PagedListingComponentBase<AuditDto> {

	auditRecords: AuditDto[] = [];

	constructor(
		private injector:Injector,
		private auditRecorsService: AuditServiceProxy
	) {
		super(injector);
	}
  
	list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
		this.auditRecorsService.getAll(request.skipCount, request.maxResultCount)
			.finally( ()=> {
				finishedCallback();
			})
            .subscribe((result: PagedResultDtoOfAuditDto)=>{
				this.auditRecords = result.items;
				this.showPaging(result, pageNumber);
		});
	}
	
	delete(role: AuditDto): void { }
}
