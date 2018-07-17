import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { SampleDetailComponent } from './sampledetail.component';

import { SampleDetailContainerFilterComponent } from './sampledetail-container-filter/sampledetail-container-filter.component';
import { SampleDetailFieldFilterComponent } from './sampledetail-field-filter/sampledetail-field-filter.component';

import { SampleDetailEditComponent } from './sampledetail-edit/sampledetail-edit.component';
import { SampleDetailCreateComponent } from './sampledetail-create/sampledetail-create.component';
import { SampleDetailDetailsComponent } from './sampledetail-details/sampledetail-details.component';

import { SampleDetailFieldCreateComponent } from './sampledetail-field-create/sampledetail-field-create.component';
import { SampleDetailFieldEditComponent } from './sampledetail-field-edit/sampledetail-field-edit.component';

import { SampleDetailContainerCreateComponent } from './sampledetail-container-create/sampledetail-container-create.component';
import { SampleDetailContainerEditComponent } from './sampledetail-container-edit/sampledetail-container-edit.component';

import { SampleDetailPrintModule } from './sampledetail-print/sampledetail-print.module';
import { SampleDetailRoutingModule } from './sampledetail.routing.module';

import { SampleDetailService } from './sampledetail.service';
import { SampleDetailServiceFields } from './sampledetail.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        SampleDetailRoutingModule,
        SampleDetailPrintModule
    ],
    declarations: [
        SampleDetailComponent,
        SampleDetailContainerFilterComponent,
        SampleDetailFieldFilterComponent,
        SampleDetailEditComponent,
        SampleDetailCreateComponent,
        SampleDetailDetailsComponent,
        SampleDetailFieldCreateComponent,
        SampleDetailFieldEditComponent,
        SampleDetailContainerCreateComponent,
        SampleDetailContainerEditComponent
    ],
    providers: [SampleDetailService,SampleDetailServiceFields, ApiService],
	exports: [SampleDetailComponent]
})
export class SampleDetailModule {


}