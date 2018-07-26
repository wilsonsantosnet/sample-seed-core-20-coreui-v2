import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { SampleProductComponent } from './sampleproduct.component';

import { SampleProductContainerFilterComponent } from './sampleproduct-container-filter/sampleproduct-container-filter.component';
import { SampleProductFieldFilterComponent } from './sampleproduct-field-filter/sampleproduct-field-filter.component';

import { SampleProductEditComponent } from './sampleproduct-edit/sampleproduct-edit.component';
import { SampleProductCreateComponent } from './sampleproduct-create/sampleproduct-create.component';
import { SampleProductDetailsComponent } from './sampleproduct-details/sampleproduct-details.component';

import { SampleProductFieldCreateComponent } from './sampleproduct-field-create/sampleproduct-field-create.component';
import { SampleProductFieldEditComponent } from './sampleproduct-field-edit/sampleproduct-field-edit.component';

import { SampleProductContainerCreateComponent } from './sampleproduct-container-create/sampleproduct-container-create.component';
import { SampleProductContainerEditComponent } from './sampleproduct-container-edit/sampleproduct-container-edit.component';

import { SampleProductPrintModule } from './sampleproduct-print/sampleproduct-print.module';
import { SampleProductRoutingModule } from './sampleproduct.routing.module';

import { SampleProductService } from './sampleproduct.service';
import { SampleProductServiceFields } from './sampleproduct.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        SampleProductRoutingModule,
        SampleProductPrintModule,

    ],
    declarations: [
        SampleProductComponent,
        SampleProductContainerFilterComponent,
        SampleProductFieldFilterComponent,
        SampleProductEditComponent,
        SampleProductCreateComponent,
        SampleProductDetailsComponent,
        SampleProductFieldCreateComponent,
        SampleProductFieldEditComponent,
        SampleProductContainerCreateComponent,
        SampleProductContainerEditComponent
    ],
    providers: [SampleProductService,SampleProductServiceFields, ApiService],
	exports: [SampleProductComponent, SampleProductEditComponent, SampleProductCreateComponent]
})
export class SampleProductModule {


}
