import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SampleDetailPrintComponent } from './sampledetail-print.component';
import { SampleDetailPrintRoutingModule } from './sampledetail-print.routing.module';

import { SampleDetailService } from '../sampledetail.service';
import { ApiService } from '../../../common/services/api.service';
import { SampleDetailServiceFields } from '../sampledetail.service.fields';

import { SampleDetailContainerDetailsComponent } from '../sampledetail-container-details/sampledetail-container-details.component';
import { SampleDetailFieldDetailsComponent } from '../sampledetail-field-details/sampledetail-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        SampleDetailPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        SampleDetailPrintComponent,
        SampleDetailContainerDetailsComponent,
        SampleDetailFieldDetailsComponent
    ],
    providers: [SampleDetailService, ApiService, SampleDetailServiceFields],
    exports: [SampleDetailContainerDetailsComponent,SampleDetailFieldDetailsComponent]
})
export class SampleDetailPrintModule {

}
