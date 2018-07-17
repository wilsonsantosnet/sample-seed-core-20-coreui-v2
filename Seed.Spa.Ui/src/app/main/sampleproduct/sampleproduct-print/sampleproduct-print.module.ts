import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SampleProductPrintComponent } from './sampleproduct-print.component';
import { SampleProductPrintRoutingModule } from './sampleproduct-print.routing.module';

import { SampleProductService } from '../sampleproduct.service';
import { ApiService } from '../../../common/services/api.service';
import { SampleProductServiceFields } from '../sampleproduct.service.fields';

import { SampleProductContainerDetailsComponent } from '../sampleproduct-container-details/sampleproduct-container-details.component';
import { SampleProductFieldDetailsComponent } from '../sampleproduct-field-details/sampleproduct-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        SampleProductPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        SampleProductPrintComponent,
        SampleProductContainerDetailsComponent,
        SampleProductFieldDetailsComponent
    ],
    providers: [SampleProductService, ApiService, SampleProductServiceFields],
    exports: [SampleProductContainerDetailsComponent,SampleProductFieldDetailsComponent]
})
export class SampleProductPrintModule {

}
