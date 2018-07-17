import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { SampleStandartComponent } from './samplestandart.component';

import { SampleStandartContainerFilterComponent } from './samplestandart-container-filter/samplestandart-container-filter.component';
import { SampleStandartFieldFilterComponent } from './samplestandart-field-filter/samplestandart-field-filter.component';

import { SampleStandartEditComponent } from './samplestandart-edit/samplestandart-edit.component';
import { SampleStandartCreateComponent } from './samplestandart-create/samplestandart-create.component';
import { SampleStandartDetailsComponent } from './samplestandart-details/samplestandart-details.component';

import { SampleStandartFieldCreateComponent } from './samplestandart-field-create/samplestandart-field-create.component';
import { SampleStandartFieldEditComponent } from './samplestandart-field-edit/samplestandart-field-edit.component';

import { SampleStandartContainerCreateComponent } from './samplestandart-container-create/samplestandart-container-create.component';
import { SampleStandartContainerEditComponent } from './samplestandart-container-edit/samplestandart-container-edit.component';

import { SampleStandartPrintModule } from './samplestandart-print/samplestandart-print.module';
import { SampleStandartRoutingModule } from './samplestandart.routing.module';

import { SampleStandartService } from './samplestandart.service';
import { SampleStandartServiceFields } from './samplestandart.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        SampleStandartRoutingModule,
        SampleStandartPrintModule
    ],
    declarations: [
        SampleStandartComponent,
        SampleStandartContainerFilterComponent,
        SampleStandartFieldFilterComponent,
        SampleStandartEditComponent,
        SampleStandartCreateComponent,
        SampleStandartDetailsComponent,
        SampleStandartFieldCreateComponent,
        SampleStandartFieldEditComponent,
        SampleStandartContainerCreateComponent,
        SampleStandartContainerEditComponent
    ],
    providers: [SampleStandartService,SampleStandartServiceFields, ApiService],
	exports: [SampleStandartComponent]
})
export class SampleStandartModule {


}