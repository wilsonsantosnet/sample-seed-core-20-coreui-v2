import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SampleStandartPrintComponent } from './samplestandart-print.component';
import { SampleStandartPrintRoutingModule } from './samplestandart-print.routing.module';

import { SampleStandartService } from '../samplestandart.service';
import { ApiService } from '../../../common/services/api.service';
import { SampleStandartServiceFields } from '../samplestandart.service.fields';

import { SampleStandartContainerDetailsComponent } from '../samplestandart-container-details/samplestandart-container-details.component';
import { SampleStandartFieldDetailsComponent } from '../samplestandart-field-details/samplestandart-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        SampleStandartPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        SampleStandartPrintComponent,
        SampleStandartContainerDetailsComponent,
        SampleStandartFieldDetailsComponent
    ],
    providers: [SampleStandartService, ApiService, SampleStandartServiceFields],
    exports: [SampleStandartContainerDetailsComponent,SampleStandartFieldDetailsComponent]
})
export class SampleStandartPrintModule {

}
